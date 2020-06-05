using System;
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
        private Thread camera;
        public Thread settings;
        int isCameraRunning = 0;
        int settingCount = 0;
        int colorMode = 0;
        Point[][] contours;
        Point2d[] vertices = new Point2d[4];
        CCI lepton;
        
        HierarchyIndex[] hierarchy;
        CCI.Sys.GainModeObj gainModeObj;


        private void CaptureCamera()
        {
            camera = new Thread(new ThreadStart(CaptureCameraCallback));
            camera.Start();
        }

        private void SettingsThread()
        {
            settings = new Thread(new ThreadStart(SettingsCallback));
            settings.Start();
        }

        private void CaptureCameraCallback()
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

            while (isCameraRunning == 1)
            {
                ImageProcess();
                //textBox2.AppendText("isCameraRunning = " + isCameraRunning + "\r\n");
            }
        }


        private void SettingsCallback()
        {
            settingCount = 0;
            int tempflag = 0;
            this.Invoke(new Action(delegate ()
            {
                tempflag =isCameraRunning;
            }));

            while (tempflag == 1)
            {
                //textBox2.AppendText("isCameraRunning = " + isCameraRunning + ", count : " + settingCount + "\r\n");
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
                Thread.Sleep(1000);
            }
        }

        private void ImageProcess()
        {
            byte[] writeBuffer = new byte[4];
            int i = 0;
            DataTable table = new DataTable();
            table.Columns.Add("No.", typeof(string));
            table.Columns.Add("Start", typeof(string));
            table.Columns.Add("End", typeof(string));

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

                foreach (Point[] p in contours)
                {
                    double area = Cv2.ContourArea(p, true);

                    if (area > 50)
                    {
                        Rect boundingRect = Cv2.BoundingRect(p);
                        //나중에 지우기
                        vertices[0].X = boundingRect.X;
                        vertices[0].Y = boundingRect.Y + boundingRect.Height;
                        vertices[1].X = boundingRect.X;
                        vertices[1].Y = boundingRect.Y;
                        vertices[2].X = boundingRect.X + boundingRect.Width;
                        vertices[2].Y = boundingRect.Y;
                        vertices[3].X = boundingRect.X + boundingRect.Width;
                        vertices[3].Y = boundingRect.Y + boundingRect.Height;
                        //여기까지

                        writeBuffer[0] = Convert.ToByte(boundingRect.X / 4);
                        writeBuffer[1] = Convert.ToByte(boundingRect.Y / 4);
                        writeBuffer[2] = Convert.ToByte((boundingRect.X + boundingRect.Width) / 4);
                        writeBuffer[3] = Convert.ToByte((boundingRect.Y + boundingRect.Height) / 4);

                        Cv2.Rectangle(frame_result, boundingRect, Scalar.Green, 2);

                        table.Rows.Add(i+1, "(" + writeBuffer[0] + ", " + writeBuffer[1] + ")", "(" + writeBuffer[2] + ", " + writeBuffer[3] + ")");
                        dataGridView1.DataSource = table;
                        i++;

                        /*
                        textBox2.AppendText("start X : " + writeBuffer[0] + "\r\n");
                        textBox2.AppendText("start Y : " + writeBuffer[1] + "\r\n");
                        textBox2.AppendText("end X : " + writeBuffer[2] + "\r\n");
                        textBox2.AppendText("end Y : " + writeBuffer[3] + "\r\n");
                        */

                        SerialWrite(writeBuffer);
                    }
                }
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

            var devices = Lepton.CCI.GetDevices();
            var device = devices[0];
            lepton = device.Open();


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
        private void btnStart_Click(object sender, EventArgs e)
        {
            if (btnStart.Text.Equals("Start"))
            {
                CaptureCamera();
                SettingsThread();
                btnStart.Text = "Stop";
                isCameraRunning = 1;
                tbInfo.AppendText("Camera 스레드, Setting 스레드 실행\r\n");
            }
            else
            {
                if (capture.IsOpened())
                {
                    camera.Abort();
                    capture.Release();
                    frame.Dispose();
                    frame_gray.Dispose();
                    frame_binary.Dispose();
                    frame_result.Dispose();
                    settings.Abort();
                    tbInfo.AppendText("Camera 스레드, Setting 스레드 종료\r\n");
                }

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
        #endregion

        #region RadioButton Event
        private void rbtnRGB_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnRGB.Checked)
                colorMode = 2;
        }

        private void btnGetPort_Click(object sender, EventArgs e)
        {
            String[] port = SerialPort.GetPortNames();
            cbCom.Items.Clear();
            cbCom.Items.AddRange(port);
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
            if (camera != null)
                camera.Abort();
            if (frame != null)
            {
                frame.Dispose();
                frame_gray.Dispose();
                frame_binary.Dispose();
                frame_result.Dispose();
            }
            if (settings != null)
                settings.Abort();
        }
    }
}
