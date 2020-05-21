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

namespace SprinklerProject
{
    public partial class Form1 : Form
    {
        VideoCapture capture;
        Mat frame, frame_gray, frame_binary, frame_result;
        Bitmap image;
        private Thread camera;
        int isCameraRunning = 0;
        int colorMode = 0;
        Point[][] contours;
        HierarchyIndex[] hierarchy;
        Point2d[] vertices = new Point2d[4];


        private void CaptureCamera()
        {
            camera = new Thread(new ThreadStart(CaptureCameraCallback));
            camera.Start();
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
                textBox1.AppendText("카메라를 연결할 수 없습니다.\r\n");
            }
            else
            {
                textBox1.AppendText("width : " + capture.FrameWidth + ", height : " + capture.FrameHeight + "\r\n");
            }

            while (isCameraRunning == 1)
            {
                ImageProcess();
            }
        }

        private void ImageProcess()
        {
            capture.Read(frame);
            Cv2.PyrUp(frame, frame);            //영상 크기 2배
            Cv2.PyrUp(frame, frame);            //영상 크기 2배

            if (colorMode == 0)
            {
                Cv2.CvtColor(frame, frame_gray, ColorConversionCodes.BGR2GRAY);
                Cv2.Threshold(frame_gray, frame_binary, 0, 255, ThresholdTypes.BinaryInv | ThresholdTypes.Otsu);
                frame_result = frame_gray.Clone();
                
                //★★★여러가지 모드 테스트 필요
                Cv2.FindContours(frame_binary, out contours, out hierarchy, RetrievalModes.List, ContourApproximationModes.ApproxSimple);

                foreach (Point[] p in contours)
                {
                    double area = Cv2.ContourArea(p, true);

                    if (area > 50)
                    {
                        Rect boundingRect = Cv2.BoundingRect(p);
                        vertices[0].X = boundingRect.X;
                        vertices[0].Y = boundingRect.Y + boundingRect.Height;
                        vertices[1].X = boundingRect.X;
                        vertices[1].Y = boundingRect.Y;
                        vertices[2].X = boundingRect.X + boundingRect.Width;
                        vertices[2].Y = boundingRect.Y;
                        vertices[3].X = boundingRect.X + boundingRect.Width;
                        vertices[3].Y = boundingRect.Y + boundingRect.Height;

                        Cv2.Rectangle(frame_result, boundingRect, Scalar.Green, 2);
                    }
                }

            }
            else if(colorMode == 1)
            {
                Cv2.CvtColor(frame, frame_result, ColorConversionCodes.BGR2RGB);
            }

            if (!frame.Empty())
            {
                image = BitmapConverter.ToBitmap(frame_result);    //Mat 형식을 Bitmap 형식으로
                //image = BitmapConverter.ToBitmap(frame_binary);    //Mat 형식을 Bitmap 형식으로
                Color pixelColor = new Color();
                /*
                for (int i = 10; i < 100; i++)
                {
                    pixelColor = image.GetPixel(i, i);
                    textBox2.AppendText("[" + i + "]" + pixelColor.ToString() + "\r\n");
                }
                */
                pictureBox1.Image = image;
            }
            image = null;   //다시 비워줌

        }

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(button1.Text.Equals("Start"))
            {
                CaptureCamera();
                button1.Text = "Stop";
                isCameraRunning = 1;
            }
            else
            {
                if(capture.IsOpened())
                {
                    camera.Abort();
                    capture.Release();
                }

                button1.Text = "Start";
                isCameraRunning = 0;
            }
        }

        private void rbtnRGB_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnRGB.Checked)
                colorMode = 1;
        }

        private void rbtnGrayScale_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnGrayScale.Checked)
                colorMode = 0;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (capture != null)
                capture.Release();
            if(camera != null)
                camera.Abort();
            if(frame != null)
                frame.Dispose();
        }
    }
}
