#pragma warning disable 0649

using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace HoganLovells.Nbi
{
    public partial class Login
    {
        private string title = "Please Log In";
        
        [FindsBy(How = How.Id, Using = "X_A_txtUsername")]
        private IWebElement usernameField;

        [FindsBy(How = How.Id, Using = "X_A_txtPassword")]
        private IWebElement passwordField;

        [FindsBy(How = How.Name, Using = "X$A$btnLogin")]
        private IWebElement logInButton;
        

        public bool IsOnPage()
        {
            bool result = Browser.ApplicationTitle.Contains(title);
            return result;
        }

        // Optional explicity wait in the event the implicit wait is not enough
        public void Wait()
        {
            Extensions.WaitForPageLoad(title);
            
        }

    }
}
