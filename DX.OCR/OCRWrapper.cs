using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;//使用DllImport需要这个头文件
using OpenCvSharp;
using DX.Log;
using DXSkidImageOCRSharp;
using System.Drawing;
using System.Drawing.Imaging;

namespace DX.OCR
{
    public class OCRWrapper
    {
        private DXLog logger = DXLog.GetLogger(typeof(OCRWrapper));
        //[DllImport("DXSkidImgOCRd.dll")]
        //public static extern int fnDXSkidImgOCR();
        private SkidImageOCREx imageOcr = new SkidImageOCREx();
        public VideoCapture ConnectRemoteCamera(string szPath)
        {
            try
            {
                var videoCapture = new VideoCapture();
                videoCapture.Open(szPath);
                videoCapture.Set(CaptureProperty.BufferSize, 1);
                videoCapture.Set(CaptureProperty.FourCC, 1196444237);//MJPG
                return videoCapture;
            }
            catch (Exception ex)
            {
                logger.Error("Connected remote camera error, {0}", ex.ToString());
                return null;
            }
        }
        public VideoCapture ConnectLocalCamera(int index)
        {
            try
            {
                var videoCapture = new VideoCapture();
                videoCapture.Open(index);
                videoCapture.Set(CaptureProperty.BufferSize, 1);
                videoCapture.Set(CaptureProperty.FourCC, 1196444237);//MJPG

                return videoCapture;
            }
            catch (Exception ex)
            {
                logger.Error("Connected local camera error, {0}", ex.ToString());
                return null;
            }
        }

        public Mat GetVideoFrame(VideoCapture capture)
        {
            try
            {
                var frame = new Mat();
                if (capture.IsOpened())
                {
                    capture.Read(frame);
                }
                return frame;
            }
            catch(Exception ex)
            {
                logger.Error("Get video frame error, {0}", ex.ToString());
                return null;
            }
        }
        public void Imshow(Mat image, string winname)
        {
            using (var window = new Window(winname))
            {
                window.ShowImage(image);
            }
        }
        public void SaveImage(Mat image, string filename)
        {
            Cv2.ImWrite(filename, image);
        }
        public void Release(VideoCapture capture)
        {
            if (capture.IsOpened())
            {
                capture.Release();
            }
        }
        public void ATB(byte[] write)
        {
            IntPtr write_data = Marshal.AllocHGlobal(write.Length);
            Marshal.Copy(write, 0, write_data, write.Length);
            Marshal.FreeHGlobal(write_data);
        }
        public string skid_ocrrecognize(Mat image)
        {            
            string strSnap = "snap.jpg";
            SaveImage(image, strSnap);
            Cv2.WaitKey(100);
            string strNumber = imageOcr.ocr_ResultfromImage_sharp(strSnap);
            return strNumber;
        }
    }
}
