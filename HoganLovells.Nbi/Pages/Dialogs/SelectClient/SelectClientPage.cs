
using HoganLovells.Nbi.App.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace HoganLovells.Nbi
{
    public partial class SelectClient
    {
        [FindsBy(How = How.XPath, Using = "//div[@id='Y_X_A_B_ucCreateRequestLightbox_ctl00']")]
        private IWebElement findClientContainer;

        [FindsBy(How = How.XPath, Using = "//div[@id='Y_X_A_B_ucCreateRequestLightbox_ctl00_lkpClientName']")]
        private IWebElement findClientText;

    }
}
