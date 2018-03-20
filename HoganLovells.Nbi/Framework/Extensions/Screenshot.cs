#pragma warning disable IDE0017  // Initialization can be simplified 

using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Threading;

namespace HoganLovells.Nbi
{
    public static partial class Extensions
    {
        public static void Screenshot(this IWebElement element)
        {

        }

        public static string ScreenshotApplication()
        {
            string captureScreenshot = Configuration.Global.Screenshots;

            if (captureScreenshot.ToLower().Equals("off") || captureScreenshot.ToLower().Equals(""))
            {
                return "";
            }
            string basePath = SystemInformation.ReportPath;
            string screenshotFormat = Configuration.Global.ScreenshotFormat;

            Screenshot ss = ((ITakesScreenshot)Browser.GetDriver).GetScreenshot();

            //Use it as you want now
            string encodeScreenshot = ss.AsBase64EncodedString;
            byte[] screenshotAsByteArray = ss.AsByteArray;

            string filename = String.Concat(basePath, Reporting.Prefix, Reporting.CurrentTest, "-", DateTime.Now.ToString("HHmmss"), ".png");

            ss.SaveAsFile(filename, ScreenshotImageFormat.Png); //use any of the built in image formating
                                                                //return encodeScreenshot; // ss.ToString();//same as string screenshot = ss.AsBase64EncodedString;

            if (screenshotFormat.Equals("file"))
            {
                return filename;
            }
            else
            {
                return encodeScreenshot;
            }


        }




        /*
        private static string CreateBase64Image(byte[] fileBytes)
        {
            Image streamImage;

            using (MemoryStream ms = new MemoryStream(fileBytes))
            {
                // Create a new image, saved as a scaled version of the original 
                streamImage = ScaleImage(Image.FromStream(ms));
            }
            using (MemoryStream ms = new MemoryStream())
            {
                // Convert this image back to a base64 string 
                streamImage.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                return Convert.ToBase64String(ms.ToArray());
            }
        }*/

    }
}
