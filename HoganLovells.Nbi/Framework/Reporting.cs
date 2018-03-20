using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Drawing.Imaging;
using System.Drawing;
using NUnit.Framework;

namespace HoganLovells.Nbi
{
    public static class Reporting
    {

        private static string reportPath = "";
        private static string currentSuite = "";
        private static string currentTest = "";
        private static string prefix = "";
        private static string basePath = "";

        private static string testStart;
        private static string testEnd;

        private static string captureScreenshot = "";
        private static string screenshotFormat = "";

        public static string ReportPath
        {
            get { return reportPath; }
        }


        public static string CurrentSuite
        {
            get { return currentSuite; }
            set { currentSuite = value; }
        }

        public static string CurrentTest
        {
            get { return currentTest; }
            set { currentTest = value; }
        }

        public static string Prefix
        {
            get { return prefix; }
        }


        public static void Initialise()
        {
            prefix = DateTime.Now.ToString("yyyyMMdd-HHmmss");  
            basePath = SystemInformation.ReportPath;
            reportPath = String.Concat(basePath, prefix, "-", "Steps.html");
            captureScreenshot = Configuration.Global.Screenshots;
            screenshotFormat = Configuration.Global.ScreenshotFormat;

            if (File.Exists(reportPath)) { File.Delete(reportPath); }
                       

            string step = "<tr>";
            step += "<th>Timestamp</th>";

            if (Configuration.Global.Mode.ToLower().Equals("debug")) {
                step += String.Concat("<th>Source</th>"); 
                step += "<th>Control</th>";
                step += "<th>Action</th>";
                step += "<th>Data</th>";
            }
            step += "<th>Friendly</th>";
            step += "<th>Screenshot</th>";
            step += "</tr>";

            using (StreamWriter sw = File.AppendText(reportPath))
            {
                sw.WriteLine(Header(Configuration.Report.Title));
                sw.WriteLine("<table id='results'>");
                sw.WriteLine(step);
            }

        }

        public static void TestInitialise()
        {
            testStart = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }

        public static void TestTerminate(TestContext.ResultAdapter resultAdapter)
        {
            StringBuilder value = Verify.ErrorMessages;
            testEnd = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            // Close off the test case, collect all additional information
        }
 

        public static void Terminate()
        {

        }

        public static void LogStep(Containers.LogStep logStep)
        {
            using (StreamWriter sw = File.AppendText(reportPath))
            {
                string step = "<tr>";
                step += String.Concat("<td>", DateTime.Now.ToString("HH:mm:ss"), "</td>");

                if (Configuration.Global.Mode.ToLower().Equals("debug")) {
                    step += String.Concat("<td>", logStep.Source, "</td>"); 

                    step += String.Concat("<td>", logStep.ElementName, "</td>");
                    step += String.Concat("<td>", logStep.Action, "</td>");
                    step += String.Concat("<td>", logStep.Data, "</td>");
                }

                step += String.Concat("<td>", logStep.Friendly, "</td>");

                if (captureScreenshot.ToLower().Equals("off") || captureScreenshot.ToLower().Equals(""))
                {
                    step += String.Concat("<td>&nbsp;</td>");
                }
                else
                { 
                    switch (screenshotFormat)
                    {
                        case "base64":
                            step += String.Concat("<td>&nbsp;</td>");
                            break;

                        default:
                            step += String.Concat("<td><img width='600' height='400' alt='' src='", logStep.Screenshot, "' /></td>");
                            break;
                    }
                    
                }

                step += "</tr>";

                sw.WriteLine(step);
            }
        }

        public static void LogDebug(string data)
        {
            string path = String.Concat(SystemInformation.ReportPath, "debug.txt");
            using (StreamWriter sw = File.AppendText(path))
            {
                sw.WriteLine(data);
            }
        }


        public static void CaptureScreenShot (IWebElement element)
        {

        }

        private static string Header(string title)
        {
            string header = "<html>";

            header += "<head><style>";
            header += "#results {";
            header += "font-family: 'Trebuchet MS', Arial, Helvetica, sans-serif;";
            header += "border-collapse: collapse;";
            header += "width: 100%;";
            header += "}";

            header += "#results td, #results th {";
            header += "border: 1px solid #ddd;";
            header += "padding: 8px;";
            header += "}";

            header += "#results tr:nth-child(even){background-color: #99000;}";

            header += "#results tr:hover {background-color: #ddd;}";

            header += "#results th {";
            header += "padding-top: 12px;";
            header += "padding-bottom: 12px;";
            header += "text-align: left;";
            header += "background-color: black;";
            header += "color: white;";
            header += "}";

            header += "</style></head>";

            header +=  String.Concat("<title>", title, "</title>");
            header += "<body background-color:peachpuff>";

            header += "<font color ='black' face='Microsoft Tai le'>";
            header += String.Concat("<h1>", title, "</h1>");
            header += "</font>";

            return header;
        }



    }
}
