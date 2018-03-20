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
        public static void Select(this IList<IWebElement> radios, string value)
        {
            if (value.Equals("")) { return; }

            foreach (IWebElement radio in radios)
            {
                string radioText = "";
                IWebElement parent = radio.FindElement(By.XPath(".."));
                IWebElement grandParent = parent.FindElement(By.XPath(".."));

                radioText = parent.Text;
                if (parent.Text.Equals(""))
                {
                    radioText = grandParent.Text;
                }
                

                //if (radio.GetAttribute("value").ToString().ToLower().Contains(value.ToLower()))
                if (radioText.ToLower().Contains(value.ToLower()))
                {
                    radio.Click2();
                    break;
                }
            }
        }
    }
}
