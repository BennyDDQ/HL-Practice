
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

        public static IWebElement Parent(this IWebElement element)
        {
            return element.FindElement(By.XPath(".."));
        }
                

        public static void Click2(this IWebElement element)
        {
            Containers.LogStep logStep = new Containers.LogStep();

            try
            {

                logStep.Source = "Click2";
                logStep.ElementName = element.GetLogicalName();
                logStep.Action = "Click";
                logStep.Data = "";

                logStep.Friendly = String.Concat("Click \"", logStep.ElementName, "\"");

                element.ScrollIntoView();
                element.Click();

                Reporting.LogStep(logStep);
            }
            catch (Exception e)
            {
                logStep.Friendly = e.Message.ToString();
                logStep.Result = "fail";
                Reporting.LogStep(logStep);
                throw new Exception("Element.Click: " + e.Message.ToString());
            }

        }
        


        private static string GetLogicalName(this IWebElement element)
        {
            string elementName = "";

            try { elementName = element.GetAttribute("placeholder").ToString(); } catch { }
            if (elementName.Equals("")) try { elementName = element.GetAttribute("name").ToString(); } catch { }
            if (elementName.Equals("")) try { elementName = element.GetAttribute("id").ToString(); } catch { }
            if (elementName.Equals("")) try { elementName = element.Text.ToString(); } catch { }
            if (elementName.Equals("")) try { elementName = element.GetAttribute("class").ToString(); } catch { }

            
            return elementName;

        }

        



    }
}
