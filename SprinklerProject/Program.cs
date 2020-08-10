using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenCvSharp;
using Lepton;
using Lepton.Unit;

namespace SprinklerProject
{
    static class Program
    {
        /// <summary>
        /// 해당 응용 프로그램의 주 진입점입니다.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Sprinkler());            
        }
        /*
        static private int ShowCamera()
        {
            VideoCapture video = new VideoCapture(0);
            Mat frame = new Mat();

            if(!video.IsOpened())
            {
                MessageBox.Show("카메라를 열 수 없습니다.");
                return 0;
            }

            while (Cv2.WaitKey(33) != 'q')
            {
                video.Read(frame);
                Cv2.ImShow("frame", frame);
            }

            frame.Dispose();
            video.Release();
            Cv2.DestroyAllWindows();

            return 0;
        }
        */
    }
}
