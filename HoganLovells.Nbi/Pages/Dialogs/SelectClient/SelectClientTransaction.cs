using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using HoganLovells.Nbi.App.Helpers;

namespace HoganLovells.Nbi
{
    public partial class SelectClient
    {

        public void FindSelectClient()
        {
            //  SearchClient FiCliSe = new SearchClient();
            // SearchClient FiCli = new SearchClient();
            string search = DataManager.GetParamater("FindClientSearch", FindingClientSearch);
            string full = DataManager.GetParamater("FindingClient", FindingClient);

            findClientText.Set(search);
            ControlHelper.SelectAutoComplete(findClientContainer, findClientText, search, full);

            findClientText.Click();
        }



    }
}

