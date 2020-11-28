using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenCvSharp;
using DX.OCR;
using DX.Log;

namespace DX.Service
{
    public class OCRService
    {
        private DXLog logger = DXLog.GetLogger(typeof(OCRService));
        private VideoCapture m_Capture { get; set; }
        private OCRWrapper m_Wrapper { get; set; }

        public void InitOCRService(bool isLorR,string szPath)
        {
            try
            {
                m_Wrapper = new OCRWrapper();
                
                if (isLorR)
                {
                    int index = Convert.ToInt16(szPath);
                    m_Capture = m_Wrapper.ConnectLocalCamera(index);
                    logger.Info("Connected local camera,framewidth:{0}", m_Capture.FrameWidth.ToString());
                }
                else
                {
                    m_Capture = m_Wrapper.ConnectRemoteCamera(szPath);
                    logger.Info("Connected remote camera,framewidth:{0}", m_Capture.FrameWidth.ToString());
                }
            }
            catch(Exception ex)
            {
                logger.Error("Connected init ocr service error, {0}", ex.ToString());
            }
        }
        public void ReleaseOCRService()
        {
            try
            {
                m_Wrapper.Release(m_Capture);
                logger.Info("Disconnected camera");
            }
            catch(Exception ex)
            {
                logger.Error("Release ocrWrapper object,{0}", ex.ToString());
            }
        }
        public void ConsecutiveRead(int fps,bool isShow,string winname)
        {
            try
            {                
                // 进入读取视频每镇的循环
                while (true)
                {
                    Mat frame = m_Wrapper.GetVideoFrame(m_Capture);
                    //判断是否还有没有视频图像 
                    if (frame.Empty())
                        break;                    
                    if (isShow)
                        m_Wrapper.Imshow(frame, winname);
                    frame.Release();
                    Cv2.WaitKey(fps);
                }
            }
            catch(Exception ex)
            {
                logger.Error("Consecutive read frame error, {0}", ex.ToString());
            }
        }
        public Mat GetCurrFrame()
        {
            try
            {
                Mat frame = new Mat();
                frame = m_Wrapper.GetVideoFrame(m_Capture);
                return frame;
            }
            catch(Exception ex)
            {
                logger.Error("Get current frame error, {0}", ex.ToString());
                Console.WriteLine(ex.ToString());
                return null;
            }
        }
        public string StartSkidOCR()
        {
            Mat frame = GetCurrFrame();
            string strOCR = m_Wrapper.skid_ocrrecognize(frame);
            string strname = DateTime.Now.ToString("yyyyMMdd_hhmmss") + "-" + strOCR + ".jpg";
            string strpath = ".//snapimage//" + strname;
            Mat gray = frame.CvtColor(ColorConversionCodes.BGRA2GRAY);//转换为灰度图像，目的是减小存储空间
            gray.SaveImage(strpath);

            return strOCR; 
        }
        public void ShowImage(string winname)
        {
            Mat frame = m_Wrapper.GetVideoFrame(m_Capture);
            //判断是否还有没有视频图像 
            if (frame.Empty())
                return;
            m_Wrapper.Imshow(frame, winname);//不好使
            frame.Release();
        }
        public void SaveToImage(string filename)
        {
            Mat frame = m_Wrapper.GetVideoFrame(m_Capture);
            m_Wrapper.SaveImage(frame, filename);
            frame.Release();
        }
    }
}
