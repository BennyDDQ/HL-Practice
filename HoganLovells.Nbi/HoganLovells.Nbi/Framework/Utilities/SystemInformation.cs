using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoganLovells.Nbi
{
    public static class SystemInformation
    {
        public static string ReportPath
        {
            get {
                string folder = BasePath;
                folder += @"Results\";

                if (!Directory.Exists(folder))
                {
                    Directory.CreateDirectory(folder);
                }

                return folder;
            }
        }

        public static string BasePath
        {
            get
            {
                string folder = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
                folder += @"\";
                return folder;
            }
        }

        



    }
}
