using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using HoganLovells.Nbi.App.Helpers;
using System.Collections.Generic;
using System;

namespace HoganLovells.Nbi
{
    public partial class Request
    {

        public class SubmitForm
        {

            [FindsBy(How = How.XPath, Using = "//*[@class='request-actions-footer-button']")]
            private IWebElement submitButton;

            public void SubmitFormButton()
            {
                submitButton.Click();
            }
        }
    }


}

