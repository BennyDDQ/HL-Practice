#pragma warning disable IDE0017  // Initialization can be simplified 

using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;

namespace HoganLovells.Nbi
{
    public static partial class Extensions
    {
        
        public static void Set(this IWebElement element, string typeText)
        {
            // ignore blank data
            if (typeText.Equals("")) { return; }
            
            Containers.LogStep logStep = new Containers.LogStep();
            try
            {
                logStep.Source = "Set";
                logStep.ElementName = element.GetLogicalName();
                logStep.Action = "Set";
                logStep.Data = typeText;

                logStep.Friendly = String.Concat("Type \"", typeText, "\" into \"", logStep.ElementName, "\"");

                element.Clear();
                element.Click();
                element.SendKeys(typeText);

                Reporting.LogStep(logStep);

            }
            catch (Exception e)
            {
                logStep.Friendly = e.Message.ToString();
                logStep.Result = "fail";
                Reporting.LogStep(logStep);
                throw new Exception("Element.Set: " + e.Message.ToString());
            }
        }



    }
}
