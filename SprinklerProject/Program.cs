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

            var devices = Lepton.CCI.GetDevices();
            var device = devices[0];
            CCI lepton = device.Open();

            lepton.vid.SetVideoOutputFormat(CCI.Vid.VideoOutputFormat.RAW14);  //VideoFormat
            lepton.sys.SetGainMode(CCI.Sys.GainMode.LOW);
            lepton.agc.SetEnableState(CCI.Agc.Enable.DISABLE);
            lepton.agc.SetCalcEnableState(CCI.Agc.Enable.DISABLE);

            //lepton.agc.SetCalcEnableState(CCI.Agc.Enable.DISABLE);

            //lepton.rad.SetEnableState(CCI.Rad.Enable.DISABLE);        //별 차이 없더라
            //lepton.rad.SetTLinearEnableState(CCI.Rad.Enable.ENABLE);
            //lepton.rad.SetTLinearResolution(CCI.Rad.TlinearResolution.RESOLUTION_0_1);        //Auto Resolution
            //lepton.rad.SetTLinearAutoResolution(CCI.Rad.Enable.DISABLE);        //Auto Resolution

            //lepton.agc.SetEnableState(CCI.Agc.Enable.ENABLE);


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());            
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
