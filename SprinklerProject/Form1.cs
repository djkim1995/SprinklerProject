﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenCvSharp;
using OpenCvSharp.Extensions;
using System.Threading;
using System.Diagnostics;
using FFmpeg;
using Lepton;
using Lepton.Unit;
using Point = OpenCvSharp.Point;
using System.IO.Ports;
using IR16Filters;

namespace SprinklerProject
{
    public partial class Sprinkler : Form
    {
        VideoCapture capture;
        Bitmap image;
        int settingCount = 0;
        int colorMode = 0;
        Point[][] contours;
        int timerCount_Setting = 0;
        int countzz = 50;
        
        List<byte[]> spotList = new List<byte[]>();

        CCI lepton;
        
        HierarchyIndex[] hierarchy;
        CCI.Sys.GainModeObj gainModeObj;

        private void Setting(object sender, EventArgs e)
        {
            if(timerCount_Setting == 6) //350, 650, 950 ...(sec)
            {
                switch (settingCount)
                {
                    case 0:
                        //GetVideoOutputFormat
                        if (lepton.vid.GetVideoOutputFormat().Equals(CCI.Vid.VideoOutputFormat.RAW14))
                            cbFormat.SelectedIndex = 0;
                        else if (lepton.vid.GetVideoOutputFormat().Equals(CCI.Vid.VideoOutputFormat.RGB888))
                            cbFormat.SelectedIndex = 1;
                        else
                            MessageBox.Show(lepton.vid.GetVideoOutputFormat() + "Format 설정 오류 발생");
                        break;

                    case 1:
                        //GetGainMode
                        if (lepton.sys.GetGainMode().Equals(CCI.Sys.GainMode.LOW))
                            cbGainMode.SelectedIndex = 0;
                        else if (lepton.sys.GetGainMode().Equals(CCI.Sys.GainMode.HIGH))
                            cbGainMode.SelectedIndex = 1;
                        else
                            MessageBox.Show(lepton.sys.GetGainMode() + "Format 설정 오류 발생");
                        break;

                    case 2:
                        //GetEnableState
                        if (lepton.agc.GetEnableState().Equals(CCI.Agc.Enable.DISABLE))
                            cbAgcEnable.SelectedIndex = 0;
                        else if (lepton.agc.GetEnableState().Equals(CCI.Agc.Enable.ENABLE))
                            cbAgcEnable.SelectedIndex = 1;
                        else
                            MessageBox.Show(lepton.agc.GetEnableState() + "Format 설정 오류 발생");
                        break;

                    case 3:
                        //GetCalcEnableState
                        if (lepton.agc.GetCalcEnableState().Equals(CCI.Agc.Enable.DISABLE))
                            cbAgcCalcEnable.SelectedIndex = 0;
                        else if (lepton.agc.GetCalcEnableState().Equals(CCI.Agc.Enable.ENABLE))
                            cbAgcCalcEnable.SelectedIndex = 1;
                        else
                            MessageBox.Show(lepton.agc.GetCalcEnableState() + "Format 설정 오류 발생");
                        break;

                    case 4:
                        //GetEnableState
                        if (lepton.rad.GetEnableState().Equals(CCI.Rad.Enable.DISABLE))
                            cbRadEnable.SelectedIndex = 0;
                        else if (lepton.rad.GetEnableState().Equals(CCI.Rad.Enable.ENABLE))
                            cbRadEnable.SelectedIndex = 1;
                        else
                            MessageBox.Show(lepton.rad.GetEnableState() + "Format 설정 오류 발생");
                        break;

                    case 5:
                        //GetTLinearEnableState
                        if (lepton.rad.GetTLinearEnableState().Equals(CCI.Rad.Enable.DISABLE))
                            cbTLinearEnable.SelectedIndex = 0;
                        else if (lepton.rad.GetTLinearEnableState().Equals(CCI.Rad.Enable.ENABLE))
                            cbTLinearEnable.SelectedIndex = 1;
                        else
                            MessageBox.Show(lepton.rad.GetTLinearEnableState() + "Format 설정 오류 발생");
                        break;
                        
                    case 6:
                        timer_Setting.Enabled = false;
                        timer_Setting.Stop();
                        MessageBox.Show("Get Setting Complete");
                        break;

                    default:
                        break;
                }
                settingCount++;
                settingCount = settingCount % 7;

                timerCount_Setting = 0;
            }
            timerCount_Setting++;
        }

        private void ImageProcess(object sender, EventArgs e)
        {
            this.Invoke(new EventHandler(ImageProcessHandler));
        }

        private void ImageProcessHandler(object sender, EventArgs e)
        {
            Mat frame = new Mat(new OpenCvSharp.Size(160, 122), MatType.CV_16UC1);
            Mat frame_gray = new Mat(new OpenCvSharp.Size(160, 122), MatType.CV_16UC1);
            Mat frame_binary = new Mat(new OpenCvSharp.Size(160, 122), MatType.CV_16UC1);
            Mat frame_result = new Mat(new OpenCvSharp.Size(160, 122), MatType.CV_16UC1);
            try
            {
                byte[] writeBuffer = new byte[4];

                capture.Read(frame);
                Cv2.PyrUp(frame, frame);            //영상 크기 2배
                Cv2.PyrUp(frame, frame);            //영상 크기 2배(총 4배)


                if (colorMode == 0)
                {
                    Cv2.CvtColor(frame, frame_gray, ColorConversionCodes.BGR2GRAY);
                    //threshold(src, dst, threshold값, 픽셀값이 threshold값보다 클 경우 이미지의 값, thresholding 타입)
                    //Cv2.Threshold(frame_gray, frame_binary, 0, 255, ThresholdTypes.BinaryInv | ThresholdTypes.Otsu);
                    //Cv2.AdaptiveThreshold(frame_gray, frame_binary, 255, AdaptiveThresholdTypes.MeanC, ThresholdTypes.Otsu, 15, 2);
                    Cv2.Threshold(frame_gray, frame_binary, 200, 255, ThresholdTypes.BinaryInv);
                    frame_result = frame_gray.Clone();

                    //★★★여러가지 모드 테스트 필요
                    Cv2.FindContours(frame_binary, out contours, out hierarchy, RetrievalModes.List, ContourApproximationModes.ApproxSimple);
                    
                    SpotRemove();

                    try
                    {
                        foreach (Point[] p in contours)
                        {
                            double area = Cv2.ContourArea(p, true);

                            if (area > 100 && cbGainMode.Text == "HIGH")
                            {
                                Rect boundingRect = Cv2.BoundingRect(p);

                                writeBuffer[0] = Convert.ToByte(boundingRect.X / 4);
                                writeBuffer[1] = Convert.ToByte(boundingRect.Y / 4);
                                writeBuffer[2] = Convert.ToByte((boundingRect.X + boundingRect.Width) / 4);
                                writeBuffer[3] = Convert.ToByte((boundingRect.Y + boundingRect.Height) / 4);

                                Cv2.Rectangle(frame_result, boundingRect, Scalar.Black, 2);

                                if (PB_FIRE.Visible == true)
                                    SpotCheck(writeBuffer);     // 좌표 비교 및 alive 비교
                            }
                        }
                        ListViewUpdate();
                    }
                    catch (NullReferenceException) { MessageBox.Show("Empty Datatable"); }
                    catch (IndexOutOfRangeException) { MessageBox.Show("Empty Datatable"); }
                }
                else if (colorMode == 1)
                {
                    Cv2.CvtColor(frame, frame_gray, ColorConversionCodes.BGR2GRAY);
                    Cv2.Threshold(frame_gray, frame_binary, 200, 255, ThresholdTypes.Binary);
                    frame_result = frame_binary;
                }
                else if (colorMode == 2)
                {
                    frame_result = frame;
                }

                if (!frame.Empty())
                {
                    image = BitmapConverter.ToBitmap(frame_result);    //Mat 형식을 Bitmap 형식으로, Format8bppIndexed

                    AverageTemp(image);                                 //평균 온도 측정

                    pictureBox1.Image = image;
                }
                image = null;   //다시 비워줌

            }
            catch (Exception)
            {
                Disconnect_Cam();
            }
        }

        private void SpotRemove()
        {
            int count = spotList.Count;
            for (int i = 0; i < count; i++)
            {
                spotList.RemoveAt(0);
            }
        }

        private void SpotCheck(byte[] writeBuffer)
        {
            spotList.Add(new byte[4]);      //[startX, startY, endX, endY, aliveCheck]
            for (int i = 0; i < 4; i++)
            {
                spotList[spotList.Count - 1][i] = writeBuffer[i];
            }
            /*
            if (spotList.Count == 0)
            {
                spotList.Add(new byte[5]);      //[startX, startY, endX, endY, aliveCheck]
                for (int i = 0; i < 4; i++)
                {
                    spotList[spotList.Count - 1][i] = writeBuffer[i];
                }
                spotList[spotList.Count - 1][4] = 1;
            }
            else
            {
                int flag_ditect = 0;

                //겹치면 확장
                for (int i = 0; i < spotList.Count; i++)
                {
                    //일단 aliveCheck 내림
                    spotList[i][4] = 0;

                    //두 사각형이 겹치는 조건
                    if (writeBuffer[0] <= spotList[i][2] && writeBuffer[1] <= spotList[i][3] &&
                       writeBuffer[2] >= spotList[i][0] && writeBuffer[3] >= spotList[i][1])
                    {
                        if (writeBuffer[0] < spotList[i][0])
                            spotList[i][0] = writeBuffer[0];
                        if (writeBuffer[1] < spotList[i][1])
                            spotList[i][1] = writeBuffer[1];
                        if (writeBuffer[2] > spotList[i][2])
                            spotList[i][2] = writeBuffer[2];
                        if (writeBuffer[3] > spotList[i][3])
                            spotList[i][3] = writeBuffer[3];

                        spotList[i][4] = 1;     //aliveCheck 올림
                        flag_ditect = 1;
                    }
                    else
                        flag_ditect = 0;
                }

                //기존에 없었다면 신규 생성
                if (flag_ditect == 0)
                {
                    spotList.Add(new byte[5]);
                    for (int i = 0; i < 4; i++)
                    {
                        spotList[spotList.Count - 1][i] = writeBuffer[i];
                    }
                    spotList[spotList.Count - 1][4] = 1;    //aliveCheck 올림
                }
            }
            //aliveCheck 검사
            int count = spotList.Count;
            for (int i = 0; i < count; i++)
            {
                if(spotList[count - (i + 1)][4] == 0)
                {
                    spotList.RemoveAt(i);
                }
            }
            */
        }
        
        private void ListViewUpdate()
        {
            listView1.BeginUpdate();
            ListViewItem item;

            int count_listview = listView1.Items.Count; // ex) 기존 : 10개 [0],[1],[2]
            int count_spotlist = spotList.Count;        // ex) 신규 : 7개 [0],[1]
            //Remove Spots
            for (int i = count_spotlist; i < count_listview; i++)   // (기존 - 신규) 만큼 반복 삭제
            {
                listView1.Items.RemoveAt(0);   // ex) 1개 삭제
            }
            //Add Spots
            for (int i = count_listview; i < count_spotlist; i++)   // (신규 - 기존) 만큼 반복 생성
            {
                item = new ListViewItem("No." + (i + 1));
                item.SubItems.Add("");
                item.SubItems.Add("");
                listView1.Items.Add(item);
            }

            //revise Spots
            for (int i = 0; i < count_spotlist; i++)    // 7번 반복 (신규)
            {
                listView1.Items[i].SubItems[1].Text = "(" + spotList[i][0] + ", " + spotList[i][1] + ")";
                listView1.Items[i].SubItems[2].Text = "(" + spotList[i][2] + ", " + spotList[i][3] + ")";
            }
            tbInfo.Text = spotList.Count + "\r\n";              //★★★
            tbInfo.AppendText(listView1.Items.Count + "");      //★★★

            listView1.EndUpdate();
        }

        private void CheckSpot(object sender, EventArgs e)
        {
            //if (lblState.Text.Equals("READY") && (PB_FIRE.Visible == true))   //★★★
            if (lblState.Text.Equals("READY"))
            {
                if (listView1.Items.Count > 0)
                {
                    if (SerialPort.IsOpen)
                    {
                        try
                        {
                            byte[] packet = Packaging_DetectedSpot();
                            SerialPort.Write(packet, 0, packet.Length); //USB : 64byte
                            //MessageBox.Show("Write : [" + packet.Length + "] bytes\r\n" + "stopbits : " + SerialPort.StopBits + "\r\nBaud rate : " + SerialPort.BaudRate);
                            lblState.Text = "WAITING";
                            lblState.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(202)))), ((int)(((byte)(201)))));
                            PictureBox_Icon.Image = global::SprinklerProject.Properties.Resources.icon_waiting;
                        }
                        catch (ArgumentNullException) { MessageBox.Show("Empty Argument", "System Message"); }
                        catch (InvalidOperationException) { MessageBox.Show("COM Port was Not Opened", "System Message"); }
                        catch (TimeoutException) { MessageBox.Show("Time out! Pleasy retry", "System Message"); }
                    }
                }
            }
        }

        private byte[] Packaging_DetectedSpot()
        {
            List<byte> TXpacket = new List<byte>();
            List<byte> readSpot = new List<byte>();
            int checksum = 0;
            int count = 0;      //UART Option
            string string_temp = "";
            string[] string_split;

            TXpacket.Add(Convert.ToByte('S'));
            TXpacket.Add(0x10); //Spot Write Command

            for (int i = 0; i < listView1.Items.Count; i++)
            {
                string_temp = listView1.Items[i].SubItems[1].Text;
                string_split = string_temp.Substring(1, string_temp.Length - 2).Split(',');
                readSpot.Add(Convert.ToByte(string_split[0]));
                readSpot.Add(Convert.ToByte(string_split[1]));

                string_temp = listView1.Items[i].SubItems[2].Text;
                string_split = string_temp.Substring(1, string_temp.Length - 2).Split(',');
                readSpot.Add(Convert.ToByte(string_split[0]));
                readSpot.Add(Convert.ToByte(string_split[1]));
            }

            int num = readSpot.Count;
            byte[] readSpotArr = readSpot.ToArray();

            //Check Range of Spot , checksum data
            for (int i = 0; i < listView1.Items.Count; i++)
            {
                if (readSpotArr[(i * 4) + 0] > 160 || readSpotArr[(i * 4) + 1] > 120)
                {
                    MessageBox.Show("No." + i + " StartPoint : Out of range");
                }
                if (readSpotArr[(i * 4) + 2] > 160 || readSpotArr[(i * 4) + 3] > 120)
                {
                    MessageBox.Show("No." + i + " EndPoint : Out of range");
                }

                int buf = 0;

                buf = 's';
                checksum = checksum ^ buf;                  //checksum XOR buf
                buf = Convert.ToInt32(readSpotArr[(i * 4) + 0]);
                checksum = checksum ^ buf;
                buf = Convert.ToInt32(readSpotArr[(i * 4) + 1]);
                checksum = checksum ^ buf;

                buf = 'e';
                checksum = checksum ^ buf;
                buf = Convert.ToInt32(readSpotArr[(i * 4) + 2]);
                checksum = checksum ^ buf;
                buf = Convert.ToInt32(readSpotArr[(i * 4) + 3]);
                checksum = checksum ^ buf;

                TXpacket.Add(Convert.ToByte('s'));
                TXpacket.Add(readSpotArr[(i * 4) + 0]);
                TXpacket.Add(readSpotArr[(i * 4) + 1]);
                TXpacket.Add(Convert.ToByte('e'));
                TXpacket.Add(readSpotArr[(i * 4) + 2]);
                TXpacket.Add(readSpotArr[(i * 4) + 3]);
            }
            //UART Option
            //MessageBox.Show(TXpacket.Count + "");
            count = TXpacket.Count;
            for (int i = 0; i < (62 - count); i++)
            {
                TXpacket.Add(0x00);
            }

            TXpacket.Add(Convert.ToByte(checksum));
            TXpacket.Add(Convert.ToByte('T'));
            byte[] TXpacketarr = TXpacket.ToArray();
            
            return TXpacketarr;
        }
        
        private void SerialWrite(byte[] writeBuffer)
        {
            try
            {
                if(SerialPort.IsOpen)
                {
                    SerialPort.Write(writeBuffer, 0, 3);
                }
            }
            catch(InvalidOperationException)
            {
                MessageBox.Show("COM Port was Not Opened", "System Message");
            }            
        }

        private void AverageTemp(Bitmap img)
        {
            Rectangle rect = new Rectangle(0, 0, img.Width, img.Height);
            System.Drawing.Imaging.BitmapData bmpData = img.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadWrite, img.PixelFormat);

            //Get the address of th first line
            IntPtr ptr = bmpData.Scan0;
            
            //Declare an array to hold the bytes of the bitmap
            int bytes = Math.Abs(bmpData.Stride) * img.Height;
            byte[] rgbValues = new byte[bytes];
            int temperature = 0, minTemp = 255, maxTemp = 0;

            System.Runtime.InteropServices.Marshal.Copy(ptr, rgbValues, 0, bytes);

            int numBytes = 0;

            for (int y = 0; y < img.Height; y++)
            {
                for (int x = 0; x < img.Width; x++)
                {
                    numBytes = (y * (img.Width * 1)) + (x * 1);     //if RGBA : *1 => *4

                    temperature += (int)rgbValues[numBytes];

                    if ((int)rgbValues[numBytes] < minTemp && y > 5 && y < img.Height - 5)
                        minTemp = (int)rgbValues[numBytes];

                    if (maxTemp < (int)rgbValues[numBytes])
                        maxTemp = (int)rgbValues[numBytes];

                    /*
                    if (rgbValues[numBytes] > 125)
                        rgbValues[numBytes] = 0;
                    */
                }
            }

            temperature = temperature / (img.Width * img.Height);
            tbMinTemp.Text = minTemp + "";  //℃
            tbAvgTemp.Text = temperature + "";
            tbMaxTemp.Text = maxTemp + "";

            // Copy the RGB values back to the bitmap
            //System.Runtime.InteropServices.Marshal.Copy(rgbValues, 0, ptr, bytes);

            // Unlock the bits.
            img.UnlockBits(bmpData);
        }

        public Sprinkler()
        {
            InitializeComponent();
            
            Tab_MAIN.Appearance = TabAppearance.Buttons;
            Tab_MAIN.SizeMode = TabSizeMode.Fixed;
            Tab_MAIN.ItemSize = new System.Drawing.Size(0, 1);

            timer_SendSpot.Interval = 1000; //1 sec
            timer_SendSpot.Tick += new EventHandler(CheckSpot);

            timer_ImgProcess.Interval = 200; // 200 milli sec
            timer_ImgProcess.Tick += new EventHandler(ImageProcess);

            timer_Setting.Interval = 50; // 50 milli sec
            timer_Setting.Tick += new EventHandler(Setting);

            btnStart.Enabled = false;

            PictureBox_Icon.Parent = lblState;
            PictureBox_Icon.BringToFront();
        }

        private void Sprinkler_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (capture != null)
                capture.Release();
        }

        #region CheckBox Event
        private void cbFormat_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFormat.SelectedIndex == 0)
            {
                lepton.oem.SetVideoOutputFormat(CCI.Oem.VideoOutputFormat.RAW14);
                SetVoSPIData();
            }                
            else if (cbFormat.SelectedIndex == 1)
                lepton.oem.SetVideoOutputFormat(CCI.Oem.VideoOutputFormat.RGB888);
        }

        private void cbGainMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbGainMode.SelectedIndex == 0)
                lepton.sys.SetGainMode(CCI.Sys.GainMode.LOW);
            else if (cbGainMode.SelectedIndex == 1)
                lepton.sys.SetGainMode(CCI.Sys.GainMode.HIGH);
        }

        private void cbAgcEnable_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbAgcEnable.SelectedIndex == 0)
                lepton.agc.SetEnableState(CCI.Agc.Enable.DISABLE);
            else if (cbAgcEnable.SelectedIndex == 1)
                lepton.agc.SetEnableState(CCI.Agc.Enable.ENABLE);
        }

        private void cbAgcCalcEnable_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbAgcCalcEnable.SelectedIndex == 0)
                lepton.agc.SetCalcEnableState(CCI.Agc.Enable.DISABLE);
            else if (cbAgcCalcEnable.SelectedIndex == 1)
                lepton.agc.SetCalcEnableState(CCI.Agc.Enable.ENABLE);
        }

        private void cbRadEnable_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbRadEnable.SelectedIndex == 0)
                lepton.rad.SetEnableState(CCI.Rad.Enable.DISABLE);
            else if (cbRadEnable.SelectedIndex == 1)
                lepton.rad.SetEnableState(CCI.Rad.Enable.ENABLE);
        }

        private void cbTLinearEnable_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbTLinearEnable.SelectedIndex == 0)
                lepton.rad.SetTLinearEnableState(CCI.Rad.Enable.DISABLE);
            else if (cbTLinearEnable.SelectedIndex == 1)
                lepton.rad.SetTLinearEnableState(CCI.Rad.Enable.ENABLE);
        }
        #endregion

        #region Button Event
        private void btnCamTab_Click(object sender, EventArgs e)
        {
            if (Tab_MAIN.TabIndex != 0)
            {
                Tab_MAIN.SelectedIndex = 0;
                btnCamTab.Enabled = false;
                btnPortTab.Enabled = true;
                btnCamTab.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(199)))), ((int)(((byte)(207)))));
                btnPortTab.BackColor = SystemColors.ControlDarkDark;
            }
        }

        private void btnMainTab_Click(object sender, EventArgs e)
        {
            if (Tab_MAIN.TabIndex != 1)
            {
                Tab_MAIN.SelectedIndex = 1;
                btnCamTab.Enabled = true;
                btnPortTab.Enabled = false;
                btnCamTab.BackColor = SystemColors.ControlDarkDark;
                btnPortTab.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(199)))), ((int)(((byte)(207)))));
            }
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            if(btnOpen.Text.Equals("OPEN"))
            {
                var devices = Lepton.CCI.GetDevices();
                try {
                    
                    for (int i = 0; i < devices.Count; i++)
                    {
                        if (devices[i].Name.Equals("PureThermal (fw:v1.3.0)"))
                        {
                            var device = devices[i];
                            //device.Open().vid.SetVideoOutputFormat(Lepton.CCI.Vid.VideoOutputFormat.RAW14);
                            //device.Open().sys.SetTelemetryEnableState(Lepton.CCI.Sys.TelemetryEnableState.TELEMETRY_ENABLED);
                            //device.Open().oem.SetVideoOutputFormat(Lepton.CCI.Oem.VideoOutputFormat.RAW14);
                            lepton = device.Open();
                            //lepton.oem.SetVideoOutputSource(CCI.Oem.VideoOutputSource.RAW);
                            BTN_GET_SETTING.Enabled = true;
                            btnOpen.Enabled = false;
                            MessageBox.Show("Device Opened");
                        }
                    }
                    if(btnOpen.Enabled == true)
                    {
                        MessageBox.Show("Please Check Device", "System Message");
                    }                    
                }
                catch (Exception) { MessageBox.Show("Please Connect Camera"); }
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (btnStart.Text.Equals("START"))
            {
                btnStart.Text = "STOP";
                btnStart.BackColor = SystemColors.ActiveCaption;
                Panel_Cam.SendToBack();
                timer_SendSpot.Enabled = true;
                timer_SendSpot.Start();
                timer_ImgProcess.Enabled = true;
                timer_ImgProcess.Start();
                //timer_Setting.Enabled = true;
                //timer_Setting.Start();
            }
            else
            {
                btnStart.Text = "START";
                btnStart.BackColor = SystemColors.ActiveCaption;
                timer_SendSpot.Enabled = false;
                timer_SendSpot.Stop();
                timer_ImgProcess.Enabled = false;
                timer_ImgProcess.Stop();
                timer_Setting.Enabled = false;
                timer_Setting.Stop();
            }
        }

        private void btnGetPort_Click(object sender, EventArgs e)
        {
            GetAvailablePort();
        }

        private void btnGetCam_Click(object sender, EventArgs e)
        {
            GetAvailableCam();
        }

        private void BTN_Conn_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbCom.Text == "")
                {
                    MessageBox.Show("Please Select the Availabe ports", "System Message");
                }
                else
                {
                    try
                    {
                        SerialPort.PortName = cbCom.Text;
                        SerialPort.BaudRate = 115200;
                        SerialPort.StopBits = StopBits.One;
                        SerialPort.DataReceived += new SerialDataReceivedEventHandler(SerialPort_DataReceived);
                        SerialPort.Open();

                        if (SerialPort.IsOpen)
                        {
                            TB_Com.Text = cbCom.Text;
                            BTN_Conn_Com.Enabled = false;
                            BTN_Disconn_Com.Enabled = true;

                            cbCom.Enabled = false;

                            PB_Port_OFF.Visible = false;
                            PB_Port_ON.Visible = true;
                            MessageBox.Show("COM Port Open", "System Message");

                            //timer_wtdg.Enabled = true;
                            //timer_wtdg.Start();
                        }
                    }
                    catch (System.IO.IOException ex)
                    {
                        MessageBox.Show("Error: " + ex.ToString(), "ERROR");
                    }
                }
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show("Un authorized Access!!");
            }
        }

        private void BTN_Disconn_Click(object sender, EventArgs e)
        {
            if (SerialPort.IsOpen)
            {
                SerialPort.DiscardInBuffer();
                SerialPort.DiscardOutBuffer();
                SerialPort.Close();

                if (!SerialPort.IsOpen)
                {
                    BTN_Conn_Com.Enabled = true;
                    BTN_Disconn_Com.Enabled = false;

                    cbCom.Enabled = true;
                    PB_Port_OFF.Visible = true;
                    PB_Port_ON.Visible = false;

                    MessageBox.Show("COM Port Closed", "System Message");
                }
                GetAvailablePort();
            }
        }

        private void BTN_Conn_Cam_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbCam.Text == "")
                {
                    MessageBox.Show("Please Select the Availabe cam", "System Message");
                }
                else
                {
                    try
                    {
                        capture.Open(Convert.ToInt32(cbCam.Text));
                        if (capture.IsOpened())
                        {
                            btnStart.Enabled = true;
                            TB_CAM.Text = cbCam.Text;
                            BTN_Conn_Cam.Enabled = false;
                            BTN_Disconn_Cam.Enabled = true;

                            cbCam.Enabled = false;

                            PB_Cam_OFF.Visible = false;
                            PB_Cam_ON.Visible = true;

                            MessageBox.Show("CAM Open", "System Message");
                        }
                    }
                    catch (System.IO.IOException ex)
                    {
                        MessageBox.Show("Error: " + ex.ToString(), "ERROR");
                    }
                }
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show("Un authorized Access!!");
            }
        }

        private void BTN_Disconn_Cam_Click(object sender, EventArgs e)
        {
            Disconnect_Cam();
        }

        private void BTN_RESET_STATE_Click(object sender, EventArgs e)
        {
            /*
            lblState.Text = "READY";
            lblState.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            */
            switch (lblState.Text)
            {
                case "READY":
                    lblState.Text = "WAITING";
                    lblState.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(202)))), ((int)(((byte)(201)))));
                    PictureBox_Icon.Image = global::SprinklerProject.Properties.Resources.icon_waiting;
                    break;
                case "WAITING":
                    lblState.Text = "MOVING";
                    lblState.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(255)))), ((int)(((byte)(169)))));
                    PictureBox_Icon.Image = global::SprinklerProject.Properties.Resources.icon_moving;
                    break;
                case "MOVING":
                    lblState.Text = "SHOOT";
                    lblState.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(255)))), ((int)(((byte)(171)))));
                    PictureBox_Icon.Image = global::SprinklerProject.Properties.Resources.icon_shoot;
                    break;
                case "SHOOT":
                    lblState.Text = "MOVING_";
                    lblState.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(255)))), ((int)(((byte)(169)))));
                    PictureBox_Icon.Image = global::SprinklerProject.Properties.Resources.icon_moving;
                    break;
                case "MOVING_":
                    lblState.Text = "READY";
                    lblState.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
                    PictureBox_Icon.Image = global::SprinklerProject.Properties.Resources.icon_ready;
                    break;
            }

        }

        private void BTN_GET_SETTING_Click(object sender, EventArgs e)
        {
            timer_Setting.Enabled = true;
            timer_Setting.Start();
        }

        private void btnGainModeObj_Click(object sender, EventArgs e)
        {
            lepton.sys.SetGainModeObj(gainModeObj);
            /*
            textBox2.Text = "sys.GainModeObj : " + lepton.sys.GetGainModeObj() + "\r\n\r\n";

            textBox2.AppendText("oem.CalStatus : " + lepton.oem.GetCalStatus() + "\r\n");
            textBox2.AppendText("oem.BadPixel : " + lepton.oem.GetBadPixelReplaceControl() + "\r\n");
            textBox2.AppendText("oem.PixelNoise : " + lepton.oem.GetPixelNoiseSettings() + "\r\n");
            */

            CCI.Oem.PixelNoiseSettings pixelNoiseSettings;
            pixelNoiseSettings = new CCI.Oem.PixelNoiseSettings(CCI.Oem.State.DISABLE);
            lepton.oem.SetPixelNoiseSettings(pixelNoiseSettings);
        }

        #endregion

        #region RadioButton Event
        private void rbtnRGB_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnRGB.Checked)
                colorMode = 2;
        }

        private void rbtnGrayScale_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnGray.Checked)
                colorMode = 0;
        }

        private void rbtnBinary_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnBinary.Checked)
                colorMode = 1;
        }

        #endregion

        #region UART Communication
        private void GetAvailablePort()
        {
            String[] port = SerialPort.GetPortNames();
            cbCom.Items.Clear();
            cbCom.Items.AddRange(port);
        }
        
        private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            this.Invoke(new EventHandler(MySerialReceived));
        }

        private void MySerialReceived(object sender, EventArgs e)
        {
            if (SerialPort.IsOpen)
            {
                int NumOfRcvs = SerialPort.BytesToRead;
                if (NumOfRcvs == 64)
                {
                    byte[] buf = new byte[NumOfRcvs];
                    SerialPort.Read(buf, 0, NumOfRcvs);
                    if ((Convert.ToChar(buf[0]) == 'S') && (Convert.ToChar(buf[63]) == 'T'))
                    {
                        if (buf[1] == 0x01)         // Spot Send Response [0x01]
                        {
                            lblState.Text = "MOVING";
                            lblState.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(255)))), ((int)(((byte)(169)))));
                            PictureBox_Icon.Image = global::SprinklerProject.Properties.Resources.icon_moving;
                            //MessageBox.Show("Send Message Complete", "System Message");
                        }
                        else if (buf[1] == 0x02)    // Move End [0x02]
                        {
                            byte[] packet;

                            if (PB_FIRE.Visible == true)
                            {
                                lblState.Text = "SHOOT";
                                lblState.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(255)))), ((int)(((byte)(171)))));
                                PictureBox_Icon.Image = global::SprinklerProject.Properties.Resources.icon_shoot;

                                packet = Packaging_Spray_Start();
                                SerialPort_MCU.Write(packet, 0, packet.Length); //USB : 64byte

                                packet = Packaging_MotionMoving();
                                SerialPort.Write(packet, 0, packet.Length); //USB : 64byte
                            }
                            else
                            {
                                lblState.Text = "MOVING";
                                lblState.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(255)))), ((int)(((byte)(169)))));
                                PictureBox_Icon.Image = global::SprinklerProject.Properties.Resources.icon_moving;
                                packet = Packaging_MoveHome();
                                SerialPort.Write(packet, 0, packet.Length); //USB : 64byte
                            }
                        }
                        else if (buf[1] == 0x03)    // Motion Moving End [0x03]
                        {
                            lblState.Text = "MOVING";
                            lblState.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(255)))), ((int)(((byte)(169)))));
                            PictureBox_Icon.Image = global::SprinklerProject.Properties.Resources.icon_moving;

                            byte[] packet = Packaging_Spray_Stop();
                            SerialPort_MCU.Write(packet, 0, packet.Length); //USB : 64byte

                            packet = Packaging_MoveHome();
                            SerialPort.Write(packet, 0, packet.Length); //USB : 64byte
                        }
                        else if (buf[1] == 0x04)    // Move to Home End [0x04]
                        {
                            lblState.Text = "READY";
                            lblState.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
                            PictureBox_Icon.Image = global::SprinklerProject.Properties.Resources.icon_ready;
                        }
                        else if (buf[1] == 0x05)    // Recall
                        {
                            MessageBox.Show("Data Transmit Fail", "System Message");
                        }
                    }
                }
            }
        }

        //Send to MCX514 0x30
        private byte[] Packaging_MoveHome()
        {
            List<byte> TXpacket = new List<byte>();
            List<byte> readSpot = new List<byte>();

            TXpacket.Add(Convert.ToByte('S'));
            TXpacket.Add(0x30);         //Move to Home Command
            for (int i = 0; i < (64 - 4); i++)
            {
                TXpacket.Add(0x00);
            }
            TXpacket.Add(0);            //checksum
            TXpacket.Add(Convert.ToByte('T'));

            byte[] TXpacketarr = TXpacket.ToArray();

            return TXpacketarr;
        }

        //Send to MCX514 0x20
        private byte[] Packaging_MotionMoving()
        {
            List<byte> TXpacket = new List<byte>();
            List<byte> readSpot = new List<byte>();

            TXpacket.Add(Convert.ToByte('S'));
            TXpacket.Add(0x20);         //SprayCall Command
            for (int i = 0; i < (64 - 4); i++)
            {
                TXpacket.Add(0x00);
            }
            TXpacket.Add(0);            //checksum
            TXpacket.Add(Convert.ToByte('T'));

            byte[] TXpacketarr = TXpacket.ToArray();

            return TXpacketarr;
        }

        //Send to MCU 0x20
        private byte[] Packaging_Spray_Stop()
        {
            List<byte> TXpacket = new List<byte>();
            List<byte> readSpot = new List<byte>();

            TXpacket.Add(Convert.ToByte('S'));
            TXpacket.Add(0x20);         //Spray Clear Command
            for (int i = 0; i < (64 - 4); i++)
            {
                TXpacket.Add(0x00);
            }
            TXpacket.Add(0);            //checksum
            TXpacket.Add(Convert.ToByte('T'));

            byte[] TXpacketarr = TXpacket.ToArray();

            return TXpacketarr;
        }

        //Send to MCU 0x10
        private byte[] Packaging_Spray_Start()
        {
            List<byte> TXpacket = new List<byte>();
            List<byte> readSpot = new List<byte>();

            TXpacket.Add(Convert.ToByte('S'));
            TXpacket.Add(0x10);         //Spray Call Command
            for (int i = 0; i < (64 - 4); i++)
            {
                TXpacket.Add(0x00);
            }
            TXpacket.Add(0);            //checksum
            TXpacket.Add(Convert.ToByte('T'));

            byte[] TXpacketarr = TXpacket.ToArray();

            return TXpacketarr;
        }
        #endregion

        private void GetAvailableCam()
        {
            int device_count = 0;
            List<String> cam_list = new List<String>();

            capture = new VideoCapture();

            while (true)
            {
                if (capture.Open(device_count))       //확인 필수
                {
                    cam_list.Add(Convert.ToString(device_count));
                }
                capture.Release();
                device_count++;

                if (device_count == 5)
                {
                    if (cam_list.Count == 0)
                        MessageBox.Show("Please Check Camera", "System Message");
                    break;
                }
            }
            String[] cam;
            cam = cam_list.ToArray();

            cbCam.Items.Clear();
            cbCam.Items.AddRange(cam);
        }

        private void Disconnect_Cam()
        {
            try
            {
                if (capture.IsOpened())
                {
                    capture.Release();
                    btnStart.Enabled = false;

                    if (btnStart.Text.Equals("Stop"))
                    {
                        timer_SendSpot.Enabled = false;
                        timer_SendSpot.Stop();
                        timer_ImgProcess.Enabled = false;
                        timer_ImgProcess.Stop();
                        timer_Setting.Enabled = false;
                        timer_Setting.Stop();
                        btnStart.Text = "Start";
                    }

                    if (!capture.IsOpened())
                    {
                        BTN_Conn_Cam.Enabled = true;
                        BTN_Disconn_Cam.Enabled = false;

                        cbCam.Enabled = true;

                        PB_Cam_OFF.Visible = true;
                        PB_Cam_ON.Visible = false;

                        MessageBox.Show("CAM Closed", "System Message");
                    }
                    GetAvailablePort();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("CAM doesn't connected", "System Message");
            }
        }

        #region Lepton
        private void SetVoSPIData()
        {
            // >>>>> Check Telemetry
            lepton.sys.SetTelemetryEnableState(CCI.Sys.TelemetryEnableState.TELEMETRY_ENABLED);
            lepton.oem.SetVideoOutputSource(CCI.Oem.VideoOutputSource.RAW);
        }

        private void btnFormat_Click(object sender, EventArgs e)
        {
            MessageBox.Show(lepton.vid.GetVideoOutputFormat() + "");
        }

        private void btn_telemetry_Click(object sender, EventArgs e)
        {
            MessageBox.Show(lepton.sys.GetTelemetryEnableState() + "");
        }

        //???
        private void btn_set_Click(object sender, EventArgs e)
        {
            timer_Setting.Enabled = true;
            timer_Setting.Start();
        }
        #endregion

        #region MCU Port, ★★★나중에 삭제★★★
        private void GetAvailablePort_MCU()
        {
            String[] port = SerialPort.GetPortNames();
            cbCom_MCU.Items.Clear();
            cbCom_MCU.Items.AddRange(port);
        }
        private void btnGetPort_MCU_Click(object sender, EventArgs e)
        {
            GetAvailablePort_MCU();
        }

        private void BTN_Conn_Com_MCU_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbCom_MCU.Text == "")
                {
                    MessageBox.Show("Please Select the Availabe ports", "System Message");
                }
                else
                {
                    try
                    {
                        SerialPort_MCU.PortName = cbCom_MCU.Text;
                        SerialPort_MCU.BaudRate = 115200;
                        SerialPort_MCU.StopBits = StopBits.One;
                        SerialPort_MCU.DataReceived += new SerialDataReceivedEventHandler(SerialPort_MCU_DataReceived);
                        SerialPort_MCU.Open();

                        if (SerialPort_MCU.IsOpen)
                        {
                            TB_Com_MCU.Text = cbCom_MCU.Text;
                            BTN_Conn_Com_MCU.Enabled = false;
                            BTN_Disconn_Com_MCU.Enabled = true;

                            cbCom_MCU.Enabled = false;

                            PB_Port_OFF_MCU.Visible = false;
                            PB_Port_ON_MCU.Visible = true;
                            MessageBox.Show("MCU Port Open", "System Message");

                            //timer_wtdg.Enabled = true;
                            //timer_wtdg.Start();
                        }
                    }
                    catch (System.IO.IOException ex)
                    {
                        MessageBox.Show("Error: " + ex.ToString(), "ERROR");
                    }
                }
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show("Un authorized Access!!");
            }
        }

        private void SerialPort_MCU_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            this.Invoke(new EventHandler(MySerialMCUReceived));
        }

        private void MySerialMCUReceived(object sender, EventArgs e)
        {
            if(SerialPort_MCU.IsOpen)
            {
                int NumOfRcvs = SerialPort_MCU.BytesToRead;
                if(NumOfRcvs == 64)
                {
                    byte[] buf = new byte[NumOfRcvs];
                    SerialPort_MCU.Read(buf, 0, NumOfRcvs);
                    if((Convert.ToChar(buf[0]) == 'S') && (Convert.ToChar(buf[63]) == 'T'))
                    {
                        if(buf[1] == 0x01)          // Fire Detection [0x01]
                        {
                            if (buf[2] == 0x01)
                                PB_FIRE.Visible = true;
                            else if (buf[2] == 0x00)
                                PB_FIRE.Visible = false;
                            //MessageBox.Show("Send Message Complete", "System Message");
                        }
                    }
                }
            }
        }

        private void BTN_Disconn_Com_MCU_Click(object sender, EventArgs e)
        {
            if (SerialPort_MCU.IsOpen)
            {
                SerialPort_MCU.DiscardInBuffer();
                SerialPort_MCU.DiscardOutBuffer();
                SerialPort_MCU.Close();

                if (!SerialPort_MCU.IsOpen)
                {
                    BTN_Conn_Com_MCU.Enabled = true;
                    BTN_Disconn_Com_MCU.Enabled = false;

                    cbCom_MCU.Enabled = true;
                    PB_Port_OFF_MCU.Visible = true;
                    PB_Port_ON_MCU.Visible = false;

                    MessageBox.Show("COM Port Closed", "System Message");
                }
                GetAvailablePort();
            }
        }
        #endregion


    }
}


/*
Stopwatch sw = new Stopwatch();
sw.Start();
sw.Stop();
MessageBox.Show(sw.ElapsedMilliseconds.ToString() + "ms");
*/
/*
 * 해야할 것
 * Timer 오프셋 줘서 안겹치게하기
 * Initiating state에서 워치독 확인되면 Ready단계로 변경
*/



 /* 추가한 기능 목록
  * RESET버튼 눌러서 STATE 초기화
  * UART
  * UART 수신에 따른 STATE 변화
  * PB_FIRE추가함, PB_FIRE.Visible이 true 일 때만 ImageProcess 실행
  * getSetting을 시작시 자동이 아닌, 버튼이벤트로 변경
  * 프로세스 중 사각형 유지
  * BoundingRect를 전역변수로 변경 //취소함
 */