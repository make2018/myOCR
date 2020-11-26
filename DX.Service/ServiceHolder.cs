using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using DX.Utilities;
using DX.Log;

namespace DX.Service
{
    public class ServiceHolder
    {

        private string[] strStates = new string[7];//读出状态        

        private DXLog logger = DXLog.GetLogger(typeof(ServiceHolder));
        private OCRService ocrService = new OCRService();

        public void Run()
        {            
            ThreadPool.QueueUserWorkItem(new WaitCallback(CameraListener));
        }


        //相机线程:刷新相机缓存
        private void CameraListener(object obj)
        {
            try
            {
                ocrService.InitOCRService(false, Constants.CAMERAPATH);
                ocrService.ConsecutiveRead(1, false, "capture");
            }
            catch(Exception ex)
            {
                logger.Error("Camera listener failed, {0}", ex.ToString());
            }
        }
    }
}
