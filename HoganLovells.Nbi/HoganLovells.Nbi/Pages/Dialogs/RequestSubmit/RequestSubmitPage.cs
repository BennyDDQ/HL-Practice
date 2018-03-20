#pragma warning disable 0649

using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace HoganLovells.Nbi
{
    public partial class RequestSubmit
    {

        private string title = "SUBMIT";
        

        [FindsBy(How = How.XPath, Using = "//*[@id='mod-request-action-confirmation-1']/div[3]/button[1]")]
        private IWebElement proceedButton;

        [FindsBy(How = How.ClassName, Using = "popup-header")]
        private IWebElement dialogTitle;

        [FindsBy(How = How.XPath, Using = "//*[@id='mod-request-action-confirmation-1']//textarea")]
        private IWebElement commentTextArea;

        public bool IsOnPage()
        {
            bool result = dialogTitle.Text.ToString().Contains(title);
            return result;
        }

        // Optional explicity wait in the event the implicit wait is not enough
        public void Wait()
        {
            Extensions.WaitForCustomPageLoad(dialogTitle, title);

        }


    }
}
