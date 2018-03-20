using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Safari;
using System;
using System.Collections.Generic;
using System.IO;

namespace HoganLovells.Nbi
{
    public static class Browser
    {
        private static IWebDriver webDriver;    

        public static void Initialize()
        {
            string browser = Configuration.Global.Browser;
            string url = Configuration.Global.BaseUrl;            

            switch (browser)
            {
                case "chrome":
                    //webDriver = new ChromeDriver();
                    ChromeOptions options = new ChromeOptions();
                    options.AddArguments("start-maximized");
                    options.AddArguments("disable-infobars");
                    webDriver = new ChromeDriver(options);
                    break;

                case "firefox":
                    webDriver = new FirefoxDriver();
                    break;
                case "edge":
                    webDriver = new EdgeDriver();
                    break;
                case "safari":
                    webDriver = new SafariDriver();
                    break;
                default:
                    webDriver = new InternetExplorerDriver();
                    break;
            }

            webDriver.Manage().Timeouts().ImplicitWait = new TimeSpan(0, 0, 10);
            Navigate(url);
        }


        public static void Terminate()
        {
            //Browser.Close();
            Close();
        }

        public static string Title
        {
            get { return webDriver.Title; }
        }

        public static string ApplicationTitle
        {
            get
            {
                IWebElement titleElement = Browser.GetDriver.FindElement(By.ClassName("wilco-page-header-title"));

                return titleElement.Text.ToString();
            }
        }

        public static ISearchContext Driver
        {
            get { return webDriver; }
        }

        public static IWebDriver GetDriver
        {
            get { return webDriver; }
        }

        public static void Navigate(string url)
        {
            webDriver.Manage().Window.Maximize();            
            webDriver.Url = url;
        }

        private static void Close()
        {
            webDriver.Close();
        }

      


    }
}
