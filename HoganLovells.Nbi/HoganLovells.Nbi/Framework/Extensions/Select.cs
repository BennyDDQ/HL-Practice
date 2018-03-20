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

        public static void Select(this IWebElement element, string selectText)
        {
            if (selectText.Equals("")) { return; }

            Containers.LogStep logStep = new Containers.LogStep();
            try
            {
                logStep.Source = "Select";
                logStep.ElementName = element.GetLogicalName();
                logStep.Action = "Select";
                logStep.Data = selectText;

                logStep.Friendly = String.Concat("Select \"", selectText, "\" from \"", logStep.ElementName, "\"");

                element.Click();
                Thread.Sleep(100);
                SelectElement select = new SelectElement(element);
                //select.SelectByValue(selectText);
                select.SelectByText(selectText);
                //new SelectElement(element).SelectByText(selectText); 
                Thread.Sleep(100);
                

                Reporting.LogStep(logStep);

            }
            catch (Exception e)
            {
                logStep.Friendly = e.Message.ToString();
                logStep.Result = "fail";
                Reporting.LogStep(logStep);
                throw new Exception("Element.Select: " + e.Message.ToString());
            }


        }
    }
}
