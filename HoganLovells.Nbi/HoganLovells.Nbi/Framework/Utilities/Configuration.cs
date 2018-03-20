using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace HoganLovells.Nbi
{
    public static class Configuration
    {

        public static class DataManager
        {
            public static string Source
            {
                get
                {
                    return ReadSetting("datamanager.source", "default");
                }
            }

            public static string BasePath
            {
                get
                {
                    string basePath = ReadSetting("datamanager.basepath", "");
                    if (basePath.Equals(""))
                    {
                        basePath =String.Concat(SystemInformation.BasePath, @"Data\");
                    }

                    if (basePath.Substring(basePath.Length-1) != @"\")
                    {
                        basePath += @"\";
                    }
                    
                    return basePath;                    

                }
            }


        }




        public static class Global
        {
            public static string BaseUrl
            {
                get
                {
                    return ReadSetting("global.baseUrl", "https://www.google.co.uk");
                }
            }
            public static string Browser
            {
                get
                {
                    return ReadSetting("global.browser", "ie");
                }
            }
            public static string Mode
            {
                get
                {
                    return ReadSetting("global.mode", "release");
                }
            }

            public static string Screenshots
            {
                get
                {
                    return ReadSetting("global.screenshots", "off");
                }
            }
            public static string ScreenshotFormat
            {
                get
                {
                    return ReadSetting("global.screenshots.format", "file");
                }
            }

        }

        public static class Report { 
            public static string Title
            {
                get
                {
                    return ReadSetting("report.title", "SeleniumBase");
                }
            }

        }

                



        private static string ReadSetting(string settingName, string defaultValue)
        {
            try
            {
                string value = ConfigurationManager.AppSettings[settingName];
                if (String.IsNullOrEmpty(value))
                {
                    return defaultValue;
                }
                else
                {
                    return value;
                }
            }
            catch
            {
                return defaultValue;
            }
        }

    }
}
