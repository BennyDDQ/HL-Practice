#pragma warning disable 0649

using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace HoganLovells.Nbi
{
    public partial class Request
    {
        // TITLE
        private string title = "Request";

        [FindsBy(How = How.ClassName, Using = "editable-title-text")]
        private IWebElement pageTitle;


        [FindsBy(How = How.Id, Using = "148d24ad913-163-b4c5d604f0")]
        private IWebElement sectionGeneralInformation;

        [FindsBy(How = How.Id, Using = "14ee3477193-37b-361b94a8f9")]
        private IWebElement sectionClientDetails;

        [FindsBy(How = How.Id, Using = "14ee34b6e74-3e2-a610e131c1")]
        private IWebElement sectionMatterDetails;


        [FindsBy(How = How.XPath, Using = "//button[contains(text(), 'Submit')]")]
        private IWebElement submitButton;

        public bool IsOnPage()
        {
            bool result = pageTitle.Text.ToString().Contains(title);
            return result;
        }

        // Optional explicity wait in the event the implicit wait is not enough
        public void Wait()
        {
            Extensions.WaitForCustomPageLoad(pageTitle, title);

        }

        public void Submit()
        {
            submitButton.Click2();
        }


    }
}
