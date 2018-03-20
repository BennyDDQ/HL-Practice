#pragma warning disable 0649

using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace HoganLovells.Nbi
{
    public partial class Request
    {

        public void ExpandSection(IWebElement sectionElement)
        {

            IWebElement captionElement = sectionElement.FindElement(By.ClassName("section-caption"));
            string caption = captionElement.Text;
            bool isDisplayed = true;

            switch (caption)
            {
                case "General Information":
                    isDisplayed = Pages.GeneralInformationRequest.IsDisplayed();
                    break;

                case "Client Details":
                    isDisplayed = Pages.ClientDetailsRequest.IsDisplayed();
                    break;

                case "Matter Details":
                    isDisplayed = Pages.MatterDetailsRequest.IsDisplayed();
                    break;

            }

            if (isDisplayed == false)
            {
                IWebElement titleElement = Browser.GetDriver.FindElement(By.XPath(
                    string.Concat("//span[contains(text(),'",
                    caption,
                    "') and @class='section-caption']")
                    ));

                sectionElement.ScrollIntoView();
                Thread.Sleep(500);
                titleElement.Click2();
                Thread.Sleep(500);
            }

            /*
            //bool foundSection = false;
            bool sectionCollapsed = false;
            string sectionCaption = "";

            ////IList<IWebElement> sections = Browser.GetDriver.FindElements(By.ClassName("collapsify-marker"));
            ////IList<IWebElement> sections = Browser.GetDriver.FindElements(By.ClassName("section-caption"));
            IList<IWebElement> sections = sectionElement.FindElements(By.ClassName("section-collapse-expand"));
            
            //int x = sections.Count;

            foreach (IWebElement section in sections)
            {
                sectionCaption = "";
                var sectionState = "";

                IList<IWebElement> spans = section.FindElements(By.TagName("span"));

                foreach (IWebElement span in spans)
                {
                    string spanClass = span.GetAttribute("class");
                    switch (spanClass)
                    {
                        case "section-caption":
                            sectionCaption = span.Text;
                            break;
                        case "collapsify-marker":
                            sectionState = span.Text;

                            if (sectionState.Equals("►"))
                            {
                                sectionCollapsed = true;
                            }

                            break;
                    }
                }

                if (caption.ToLower().Equals(sectionCaption.ToLower()))
                {
                    foundSection = true;
                    break;
                }

            }

            // Check if supposed to be visible to end-user
            if (sectionCollapsed == true)
            {
                IWebElement sectionElement = Browser.GetDriver.FindElement(By.XPath( 
                    string.Concat("//span[contains(text(),'" ,
                    sectionCaption ,
                    "') and @class='section-caption']")
                    ));

                sectionElement.ScrollIntoView();
                Thread.Sleep(500);
                sectionElement.Click2();
                Thread.Sleep(500);
            }

    */

        }



    }
}
