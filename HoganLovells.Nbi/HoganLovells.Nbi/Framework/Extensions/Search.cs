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


        public static bool Exists(this IWebElement element)
        {
            Containers.LogStep logStep = new Containers.LogStep();
            try
            {
                bool result = element.Displayed;

                logStep.Source = "Exists";
                logStep.ElementName = element.GetLogicalName();
                logStep.Action = "Exists";
                logStep.Data = element.Displayed.ToString();

                logStep.Friendly = String.Concat("Check if \"", logStep.ElementName, "\" exists");

                Reporting.LogStep(logStep);

                return result;
            }
            catch (Exception e)
            {
                logStep.Friendly = e.Message.ToString();
                logStep.Result = "fail";
                Reporting.LogStep(logStep);
                return false;
            }

        }


        public static IWebElement FindLinkByText(string partialText)
        {
            IList<IWebElement> all = Browser.Driver.FindElements(By.PartialLinkText(partialText));

            if (all.Count.Equals(1))
            {
                return all[0];
            }
            else
            {
                return null;
            }
            /* String[] allText = new String[all.Count];
             int i = 0;
             foreach (IWebElement element in all)
             {
                 allText[i++] = element.Text;
             }*/


        }


        public static void ScrollIntoView(this IWebElement element)
        {
            Containers.LogStep logStep = new Containers.LogStep();
            try
            {
                //var element = driver.FindElement(By.id("element-id"));
                /*Actions actions = new Actions(Browser.GetDriver);
                actions.MoveToElement(element);
                actions.Perform();*/


                logStep.Source = "ScrollIntoView";
                logStep.ElementName = element.GetLogicalName();
                logStep.Action = "Scroll Into View";
                logStep.Data = "";

                logStep.Friendly = String.Concat("Scroll \"", logStep.ElementName, "\" into view");

                IWebDriver driver = Browser.GetDriver;
                IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                js.ExecuteScript("arguments[0].scrollIntoView()", element);

                //Reporting.LogStep(logStep);
            }
            catch (Exception e)
            {
                logStep.Friendly = e.Message.ToString();
                logStep.Result = "fail";
                Reporting.LogStep(logStep);
                throw new Exception("Element.ScrollIntoView: " + e.Message.ToString());
            }

        }


    }
}
