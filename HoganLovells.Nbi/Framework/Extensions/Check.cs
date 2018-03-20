
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

        public static void SetCheckbox(this IWebElement element, bool state)
        {
            if (state == true)
            {
                element.Checked();
            }
            else
            {
                element.Unchecked();
            }
        }

        public static void Checked(this IWebElement element)
        {
            if (!element.Selected)
            {
                element.Click2();
            }
        }

        public static void Unchecked(this IWebElement element)
        {
            if (element.Selected)
            {
                element.Click2();
            }

        }



    }
}
