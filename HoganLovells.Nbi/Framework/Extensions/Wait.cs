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


        public static void WaitForPageLoad(string browserTitle)
        {
            Containers.LogStep logStep = new Containers.LogStep();

            try
            {
                string checkString = "";
                DefaultWait<string> wait = new DefaultWait<string>(checkString);
                wait.Timeout = TimeSpan.FromSeconds(10); // .FromMinutes(1);
                wait.PollingInterval = TimeSpan.FromMilliseconds(250);

                Func<string, bool> waiter = new Func<string, bool>((string ele) =>
                {
                    String findTitle = Browser.ApplicationTitle;
                    if (findTitle.Contains(browserTitle))
                    {
                        return true;
                    }
                    return false;
                });
                wait.Until(waiter);

                logStep.Source = "WaitForPageLoad";
                logStep.ElementName = browserTitle;
                logStep.Action = "Wait Page";
                logStep.Data = "";

                logStep.Friendly = String.Concat("Wait for Page with title \"", browserTitle, "\" to load");
                logStep.Screenshot = ScreenshotApplication();

                Reporting.LogStep(logStep);
            }
            catch (Exception e)
            {
                logStep.Friendly = e.Message.ToString();
                logStep.Result = "fail";
                logStep.Screenshot = ScreenshotApplication();
                Reporting.LogStep(logStep);
            }

        }

        public static void WaitForCustomPageLoad(IWebElement dialog, string dialogTitle)
        {

            Containers.LogStep logStep = new Containers.LogStep();
            try
            {

                string checkString = "";
                DefaultWait<string> wait = new DefaultWait<string>(checkString);
                wait.Timeout = TimeSpan.FromSeconds(20); // .FromMinutes(1);
                wait.PollingInterval = TimeSpan.FromMilliseconds(250);

                Func<string, bool> waiter = new Func<string, bool>((string ele) =>
                {
                    String findTitle = dialog.Text.ToString();
                    if (findTitle.Contains(dialogTitle))
                    {
                        return true;
                    }
                    return false;
                });
                wait.Until(waiter);

                logStep.Source = "WaitForDialogLoad";
                logStep.ElementName = dialogTitle;
                logStep.Action = "Wait Dialog";
                logStep.Data = "";

                logStep.Friendly = String.Concat("Wait for Dialog/Page with title \"", dialogTitle, "\" to load");
                logStep.Screenshot = ScreenshotApplication();

                Reporting.LogStep(logStep);
            }
            catch (Exception e)
            {
                logStep.Friendly = e.Message.ToString();
                logStep.Screenshot = ScreenshotApplication();
                Reporting.LogStep(logStep);
            }

        }


        public static void WaitByClassName(string elementName, string findBy)
        {
            Containers.LogStep logStep = new Containers.LogStep();
            try
            {
                IWebElement element = Browser.GetDriver.FindElement(By.ClassName(findBy));
                int maxWait = 10000;
                int counter = 0;

                while (element == null && counter < maxWait)
                {
                    element = Browser.GetDriver.FindElement(By.ClassName(findBy));
                    Thread.Sleep(500);
                    counter += 500;
                }

                logStep.Source = "WaitByClassName";
                logStep.ElementName = element.GetLogicalName();
                logStep.Action = "Displayed";
                logStep.Data = element.Displayed.ToString();

                logStep.Friendly = "Wait for \"" + logStep.ElementName + "\" to be displayed on page";

                Reporting.LogStep(logStep);
            }
            catch (Exception e)
            {
                logStep.Friendly = e.Message.ToString();
                logStep.Screenshot = ScreenshotApplication();
                Reporting.LogStep(logStep);
            }

        }
        public static void WaitById(string elementName, string findBy)
        {
            Containers.LogStep logStep = new Containers.LogStep();
            try
            {
                IWebElement element = Browser.GetDriver.FindElement(By.Id(findBy));
                int maxWait = 10000;
                int counter = 0;

                while (element == null && counter < maxWait)
                {
                    element = Browser.GetDriver.FindElement(By.Id(findBy));
                    Thread.Sleep(500);
                    counter += 500;
                }

                logStep.Source = "WaitById";
                logStep.ElementName = elementName;
                logStep.Action = "Displayed";
                logStep.Data = element.Displayed.ToString();

                logStep.Friendly = "Wait for \"" + logStep.ElementName + "\" to be displayed on page";

                Reporting.LogStep(logStep);
            }
            catch (Exception e)
            {
                logStep.Friendly = e.Message.ToString();
                logStep.Screenshot = ScreenshotApplication();
                Reporting.LogStep(logStep);
            }

        }


        public static string WaitForValue(IWebElement element, string expectedValue)
        {
            int maxWait = 10000;
            int counter = 0;
            string actual = element.Text.ToString();
            Containers.LogStep logStep = new Containers.LogStep();

            try
            {
                while (!actual.Equals(expectedValue) && counter < maxWait)
                {
                    Thread.Sleep(100);
                    counter += 100;
                    actual = element.Text.ToString();
                }

                logStep.Source = "WaitForValue";
                logStep.ElementName = element.GetLogicalName();
                logStep.Action = "Wait Value";
                logStep.Data = actual;

                logStep.Friendly = String.Concat("Waited ", (counter / 1000).ToString(), " seconds ",
                    "for \"", logStep.ElementName, "\" to attain value. <br />Expected Value: \"", expectedValue,
                    "\"<br /> Actual Value: \"", actual, "\"");

                Reporting.LogStep(logStep);

                return actual;
            }
            catch (Exception e)
            {
                logStep.Friendly = e.Message.ToString();
                logStep.Screenshot = ScreenshotApplication();
                Reporting.LogStep(logStep);
                return "";
            }

        }


        public static bool WaitForObject(this IWebElement element)
        {
            int maxWait = 10000;
            int counter = 0;
            bool exists = false;
            Containers.LogStep logStep = new Containers.LogStep();

            try
            {
                exists = element.Displayed;
                while (!exists && counter < maxWait)
                {
                    Thread.Sleep(1000);
                    counter += 1000;
                    exists = element.Displayed;
                }

                logStep.Source = "WaitForObject";
                logStep.ElementName = element.GetLogicalName();
                logStep.Action = "Wait Object";
                logStep.Data = element.Displayed.ToString();

                logStep.Friendly = String.Concat("Wait for object to exist: \"", logStep.ElementName, "\"");

                Reporting.LogStep(logStep);

                return exists;
            }
            catch (Exception e)
            {
                logStep.Friendly = e.Message.ToString();
                logStep.Screenshot = ScreenshotApplication();
                Reporting.LogStep(logStep);
                return false;
            }

        }
    }
}
