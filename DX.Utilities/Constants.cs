using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DX.Utilities
{
    public class Constants
    {
        //OCR
        public static String SERVICENAME = Configurations.Get("SERVICENAME");
        public static String SERVICDESCRIPTION = Configurations.Get("SERVICDESCRIPTION");
        public static String SERVICESTATERUNING = Configurations.Get("SERVICESTATERUNING");//2020-04-25
        public static String SERVICESTATESTOPED = Configurations.Get("SERVICESTATESTOPED");//2020-04-25
        public static String SERVICEINSTALL = Configurations.Get("SERVICEINSTALL");//2020-04-25
        public static String SERVICEUNINSTALL = Configurations.Get("SERVICEUNINSTALL");//2020-04-25
        public static String CAMERAPATH = Configurations.Get("CAMERAPATH"); 
        public static String LOGPATH = Configurations.Get("LOGPATH");
        public static String SNAPIMAGEPATH = Configurations.Get("SNAPIMAGEPATH");
        public static String BKIMAGE = Configurations.Get("BKIMAGE");
        //PLC
        public static String PLCIP = Configurations.Get("PLCIP");
        public static String Rack = Configurations.Get("Rack");
        public static String Slot = Configurations.Get("Slot");

    }        
}
