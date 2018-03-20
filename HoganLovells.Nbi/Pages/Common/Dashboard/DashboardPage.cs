#pragma warning disable 0649

using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace HoganLovells.Nbi
{
    public partial class Dashboard
    {
        private string title = "Dashboard";


        [FindsBy(How = How.Name, Using = "Y$X$A$B$btnCreateRequest")]
        private IWebElement createNewRequestButton;

        public bool IsOnPage()
        {
            bool result = Browser.ApplicationTitle.Contains(title);
            return result;
        }

        // Optional explicity wait in the event the implicit wait is not enough
        private void Wait()
        {
            Extensions.WaitForPageLoad(title);

        }


    }
}
