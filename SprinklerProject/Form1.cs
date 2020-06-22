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

namespace SprinklerProject
{
    public partial class Form1 : Form
    {
        VideoCapture capture;
        Mat frame, frame_gray, frame_binary, frame_result;
        Bitmap image;
        int isCameraRunning = 0;
        int settingCount = 0;
        int colorMode = 0;
        Point[][] contours;
        
        List<byte[]> spotList = new List<byte[]>();

        CCI lepton;
        
        HierarchyIndex[] hierarchy;
        CCI.Sys.GainModeObj gainModeObj;
        
        private void Init_Camera()
        {
            frame = new Mat();
            frame_gray = new Mat();
            frame_binary = new Mat();
            frame_result = new Mat();

            capture = new VideoCapture();
            capture.Open(0);
            
            if (!capture.IsOpened())
            {
                tbInfo.AppendText("카메라를 연결할 수 없습니다.\r\n");
            }
            else
            {
                tbInfo.AppendText("width : " + capture.FrameWidth + ", height : " + capture.FrameHeight + "\r\n");
            }
        }

        private void Setting(object sender, EventArgs e)
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
                    //GetPolarity
                    if (lepton.vid.GetPolarity().Equals(CCI.Vid.Polarity.BLACK_HOT))
                        cbHotColor.SelectedIndex = 0;
                    if (lepton.vid.GetPolarity().Equals(CCI.Vid.Polarity.WHITE_HOT))
                        cbHotColor.SelectedIndex = 1;
                    else
                        MessageBox.Show(lepton.vid.GetPolarity() + "Format 설정 오류 발생");
                    break;
                default:
                    break;
            }
            settingCount++;
        }

        private void ImageProcess(object sender, EventArgs e)
        {
            this.Invoke(new EventHandler(ImageProcessHandler));
        }

        private void ImageProcessHandler(object sender, EventArgs e)
        {
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

                            if (area > 100 && cbGainMode.Text == "LOW")
                            {
                                Rect boundingRect = Cv2.BoundingRect(p);

                                writeBuffer[0] = Convert.ToByte(boundingRect.X / 4);
                                writeBuffer[1] = Convert.ToByte(boundingRect.Y / 4);
                                writeBuffer[2] = Convert.ToByte((boundingRect.X + boundingRect.Width) / 4);
                                writeBuffer[3] = Convert.ToByte((boundingRect.Y + boundingRect.Height) / 4);

                                Cv2.Rectangle(frame_result, boundingRect, Scalar.Black, 2);

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
            catch (ObjectDisposedException)
            {
                MessageBox.Show("frame load error");
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
            tbInfo.Text = spotList.Count + "\r\n";
            tbInfo.AppendText(listView1.Items.Count + "");
            listView1.EndUpdate();
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

        public Form1()
        {
            InitializeComponent();

            timer_spot.Interval = 1000; //1 sec
            //timer_spot.Tick += new EventHandler(ListViewUpdate);

            timer_ImgProcess.Interval = 100; // 100 milli sec
            timer_ImgProcess.Tick += new EventHandler(ImageProcess);

            timer_Setting.Interval = 300; // 100 milli sec
            timer_Setting.Tick += new EventHandler(Setting);

            //var devices = Lepton.CCI.GetDevices();
            //var device = devices[0];
            //lepton = device.Open();

            /*
            Console.WriteLine("lepton.sys.GetCameraUpTime() : " + lepton.sys.GetCameraUpTime() + "\n\n");

            Console.WriteLine("\n\n==========Before Setting==========");
            Console.WriteLine("vid.VideoOutputFormat : " + lepton.vid.GetVideoOutputFormat());
            Console.WriteLine("vid.Polarity : " + lepton.vid.GetPolarity());

            Console.WriteLine("sys.GainMode : " + lepton.sys.GetGainMode());
            Console.WriteLine("sys.GainModeObj : " + lepton.sys.GetGainModeObj());
            Console.WriteLine("sys.AuxCelsius : " + lepton.sys.GetAuxTemperatureCelsius());
            Console.WriteLine("sys.FpaCelsius : " + lepton.sys.GetFpaTemperatureCelsius());

            Console.WriteLine("agc.EnableState : " + lepton.agc.GetEnableState());
            Console.WriteLine("agc.CalcEnableState : " + lepton.agc.GetCalcEnableState());
            Console.WriteLine("agc.Policy : " + lepton.agc.GetPolicy());

            Console.WriteLine("rad.EnableState : " + lepton.rad.GetEnableState());
            Console.WriteLine("rad.TLinearEnableState : " + lepton.rad.GetTLinearEnableState());
            Console.WriteLine("rad.TLinearResolution : " + lepton.rad.GetTLinearResolution());
            Console.WriteLine("rad.TLinearAutoResolution : " + lepton.rad.GetTLinearAutoResolution());

            //lepton.oem.SetVideoOutputFormat(CCI.Oem.VideoOutputFormat.RAW14);
            lepton.vid.SetVideoOutputFormat(CCI.Vid.VideoOutputFormat.RAW14);           //VideoFormat
            lepton.vid.SetPolarity(CCI.Vid.Polarity.WHITE_HOT);           //VideoFormat

            lepton.sys.SetGainMode(CCI.Sys.GainMode.LOW);

            CCI.Sys.GainModeRoi gainModeRoi = new CCI.Sys.GainModeRoi(0, 0, 159, 119);
            CCI.Sys.GainModeThresholds gainModeThresholds = new CCI.Sys.GainModeThresholds(25, 90, 115, 85, 388, 358);
            gainModeObj = new CCI.Sys.GainModeObj(gainModeRoi, gainModeThresholds, 19200, 0, 8765, 9876);

            lepton.sys.SetGainModeObj(gainModeObj);                                     // RadioMetry Enabled, TLinear Disabled 일때 발생, Auto-Gain모드 

            lepton.agc.SetEnableState(CCI.Agc.Enable.DISABLE);                          //default : DISABLE
            lepton.agc.SetCalcEnableState(CCI.Agc.Enable.DISABLE);                      //default : DISABLE,  원활한 AGC 켜기/끄기를 위해서는 활성화하는 것이 좋음
            lepton.agc.SetPolicy(CCI.Agc.Policy.HEQ);                                   //default : HEQ
            lepton.agc.SetHeqLinearPercent(20);                                         //default : 20
            lepton.agc.SetHeqClipLimitHigh(19200);                                      //0~19200, default : 19,200
                                                                                        //lepton.agc.SetHeqClipLimitLow(512);                                         //0~1024, default:512
            
            lepton.rad.SetEnableState(CCI.Rad.Enable.ENABLE);                          //default : DISABLE, Radiomertic Releases Factory Default : ENABLE
            lepton.rad.SetTLinearEnableState(CCI.Rad.Enable.ENABLE);                   //default : DISABLE, Radiomertic Releases Factory Default : ENABLE
            lepton.rad.SetTLinearResolution(CCI.Rad.TlinearResolution.RESOLUTION_0_1);  //default : 0_1 / 0_01
            lepton.rad.SetTLinearAutoResolution(CCI.Rad.Enable.ENABLE);                //default : DISABLE
            

            Console.WriteLine("\n\n==========After Setting==========");
            Console.WriteLine("vid.VideoOutputFormat : " + lepton.vid.GetVideoOutputFormat());
            Console.WriteLine("vid.Polarity : " + lepton.vid.GetPolarity());

            Console.WriteLine("sys.GainMode : " + lepton.sys.GetGainMode());
            Console.WriteLine("sys.GainModeObj : " + lepton.sys.GetGainModeObj());

            Console.WriteLine("agc.EnableState : " + lepton.agc.GetEnableState());
            Console.WriteLine("agc.CalcEnableState : " + lepton.agc.GetCalcEnableState());
            Console.WriteLine("agc.Policy : " + lepton.agc.GetPolicy());

            Console.WriteLine("rad.EnableState : " + lepton.rad.GetEnableState());
            Console.WriteLine("rad.TLinearEnableState : " + lepton.rad.GetTLinearEnableState());
            Console.WriteLine("rad.TLinearResolution : " + lepton.rad.GetTLinearResolution());
            Console.WriteLine("rad.TLinearAutoResolution : " + lepton.rad.GetTLinearAutoResolution());
            */
        }

        #region CheckBox Event
        private void cbFormat_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFormat.SelectedIndex == 0)
                lepton.vid.SetVideoOutputFormat(CCI.Vid.VideoOutputFormat.RAW14);
            else if (cbFormat.SelectedIndex == 1)
                lepton.vid.SetVideoOutputFormat(CCI.Vid.VideoOutputFormat.RGB888);
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

        private void cbHotColor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbHotColor.SelectedIndex == 0)
                lepton.vid.SetPolarity(CCI.Vid.Polarity.BLACK_HOT);
            else if (cbHotColor.SelectedIndex == 1)
                lepton.vid.SetPolarity(CCI.Vid.Polarity.WHITE_HOT);
        }
        #endregion

        #region Button Event
        private void btnOpen_Click(object sender, EventArgs e)
        {
            if(btnOpen.Text.Equals("Open"))
            {
                var devices = Lepton.CCI.GetDevices();
                try {
                    var device = devices[0];
                    lepton = device.Open();
                    btnOpen.Enabled = false;
                    MessageBox.Show("Device Opened");
                }
                catch (Exception) { MessageBox.Show("Please Connect Camera"); }
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (btnStart.Text.Equals("Start"))
            {
                Init_Camera();
                //SettingsThread();
                btnStart.Text = "Stop";
                isCameraRunning = 1;
                //timer_spot.Enabled = true;
                //timer_spot.Start();
                timer_ImgProcess.Enabled = true;
                timer_ImgProcess.Start();
                timer_Setting.Enabled = true;
                timer_Setting.Start();
                tbInfo.AppendText("Camera 스레드, Setting 스레드 실행\r\n");
            }
            else
            {
                if (capture.IsOpened())
                {
                    capture.Release();
                    frame.Dispose();
                    frame_gray.Dispose();
                    frame_binary.Dispose();
                    frame_result.Dispose();
                    //settings.Abort();
                    tbInfo.AppendText("Camera 스레드, Setting 스레드 종료\r\n");
                }

                timer_spot.Enabled = false;
                timer_spot.Stop();
                timer_ImgProcess.Enabled = false;
                timer_ImgProcess.Stop();
                timer_Setting.Enabled = false;
                timer_Setting.Stop();
                btnStart.Text = "Start";
                isCameraRunning = 0;
            }
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

        private void btnCamTab_Click(object sender, EventArgs e)
        {
            if (Tab_MAIN.TabIndex != 0)
            {
                Tab_MAIN.SelectedIndex = 0;
                btnPortTab.Enabled = true;
                btnCamTab.Enabled = false;
            }
        }

        private void btnMainTab_Click(object sender, EventArgs e)
        {
            if (Tab_MAIN.TabIndex != 1)
            {
                Tab_MAIN.SelectedIndex = 1;
                btnPortTab.Enabled = false;
                btnCamTab.Enabled = true;
            }
        }

        private void btnGetPort_Click(object sender, EventArgs e)
        {
            String[] port = SerialPort.GetPortNames();
            cbCom.Items.Clear();
            cbCom.Items.AddRange(port);
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
            if (rbtnGrayScale.Checked)
                colorMode = 0;
        }

        private void rbtnBinary_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnBinary.Checked)
                colorMode = 1;
        }

        #endregion

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (capture != null)
                capture.Release();
            if (frame != null)
            {
                frame.Dispose();
                frame_gray.Dispose();
                frame_binary.Dispose();
                frame_result.Dispose();
            }
        }
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
*/