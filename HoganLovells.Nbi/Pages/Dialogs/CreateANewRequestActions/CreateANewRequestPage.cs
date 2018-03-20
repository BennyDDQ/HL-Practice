#pragma warning disable 0649

using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace HoganLovells.Nbi
{
    public partial class CreateANewRequest
    {
        private string title = "Create a new request";

        [FindsBy(How = How.Name, Using = "Y$X$A$B$btnCreateRequest")]   
        private IWebElement createRequestButton;

        [FindsBy(How = How.ClassName, Using = "create-request-lightbox")]
        private IWebElement dialogTitle;
        
        public bool IsOnPage()
        {
            bool result = dialogTitle.Text.ToString().Contains(title);
            return result;
        }

        // Optional explicity wait in the event the implicit wait is not enough
        public void Wait()
        {
            Extensions.WaitForCustomPageLoad(dialogTitle, title);    //explicit wait

        }




    }
}
