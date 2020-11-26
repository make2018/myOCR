using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using DX.Log;

namespace DX.Utilities
{
    public class Configurations
    {
        public static String Get(string key)
        {
            try
            {
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                return config.AppSettings.Settings[key].Value;
            }
            catch (Exception e)
            {
                return "";
            }
        }
    }
}
