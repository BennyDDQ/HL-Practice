
#pragma warning disable IDE0017  // Initialization can be simplified 
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HoganLovells.Nbi.App.Helpers
{
    public static class ControlHelper
    {        


        

        public static void SelectAutoComplete(IWebElement parent, IWebElement element, string searchValue, string fullValue)
        {
            // ignore blank data
            if (searchValue.Equals("") || fullValue.Equals("")) { return; }

            try
            {
                element.Set(searchValue);

                int maxWait = 10000;
                int stopWait = 0;

                IList<IWebElement> items = parent.FindElements(By.XPath("//div[@class='item']"));
                while (items.Count.Equals(0) && stopWait < maxWait)
                {
                    Thread.Sleep(500);
                    stopWait += 500;
                    items = parent.FindElements(By.XPath("//div[@class='item']"));
                }

                if (items.Count > 0)
                {
                    Thread.Sleep(2000);
                    element.SendKeys(Keys.Return);
                    parent.Click();
                }

                Thread.Sleep(2000);
                IWebElement check = parent.FindElement(By.XPath("//div[@class='item']"));

                if (!check.Text.ToString().ToLower().Contains(fullValue.ToLower()))
                {
                    //throw new Exception("Unable to verify value has been set");
                }
            }
            catch
            {
                throw new Exception("Unable to execute auto complete");
            }


        }


    }
}
