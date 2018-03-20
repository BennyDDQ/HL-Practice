#pragma warning disable 0649

using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using HoganLovells.Nbi.App.Helpers;
using System.Collections.Generic;
using System;

namespace HoganLovells.Nbi
{
    public partial class Request
    {

        public class ClientDetails
        {

            /* ------------------------------------------------------------------------------------------
            Unnamed section at top of page
            ------------------------------------------------------------------------------------------*/
            [FindsBy(How = How.XPath, Using = "//div[@id='1487fa38d24-25f-10c9d1555fd']//select")]
            private IWebElement clientTypeSelect;

            [FindsBy(How = How.XPath, Using = "//*[@id='148f5f37a6a-2ad-1146a59a134']/div[2]/input")]
            private IWebElement clientNameText;

            [FindsBy(How = How.XPath, Using = "//*[@id='1487fa20ba9-25a-19d1d807ab']/div[2]/input")]
            private IWebElement parentCompanyNameText;

            private string isAnyCompanyRadioId = "148ea81fae9-29e-ff7cd7caa4";

            [FindsBy(How = How.XPath, Using = "//div[@id='148ea835024-2a1-12ddab05368']")]
            private IWebElement existingClientContainer;

            [FindsBy(How = How.XPath, Using = "//div[@id='148ea835024-2a1-12ddab05368']//input")]
            private IWebElement existingClientText;


            // Individual - Hidden 
            [FindsBy(How = How.XPath, Using = "//div[@id='15a86b38216-3ad-19128333a']")]
            private IWebElement clientTitleContainer;

            [FindsBy(How = How.XPath, Using = "//div[@id='15a86b38216-3ad-19128333a']//input")]
            private IWebElement clientTitleText;

            [FindsBy(How = How.XPath, Using = "//*[@id='15a3ed30aa7-3a9-deea792b41']")]
            private IWebElement clientFirstNameText;


            [FindsBy(How = How.XPath, Using = "//*[@id='15b3e7840f4-3cc-5e63a92bf1']")]
            private IWebElement clientMiddleNameText;


            [FindsBy(How = How.XPath, Using = "//*[@id='15a3ed14751-39c-2cb6bfb879']")]
            private IWebElement clientLastNameText;


            [FindsBy(How = How.XPath, Using = "//*[@id='15a86b7e686-3ba-ed9efa0a26']")]
            private IWebElement clientSuffixContainer;

            [FindsBy(How = How.XPath, Using = "//div[@id='15a86b7e686-3ba-ed9efa0a26']//input")]
            private IWebElement clientSuffixText;


            #region Client Address Declaration
            [FindsBy(How = How.XPath, Using = "//*[@id='15c9d3fb2ed-3c6-108557b7db8']//input")]
            private IWebElement clientContactNameText;

            [FindsBy(How = How.XPath, Using = "//*[@id='14e63251e48-34f-3c3819ed80']//input")]
            private IWebElement streetAddressLine1Text;

            [FindsBy(How = How.XPath, Using = "//*[@id='14e63279854-356-61449e3d19']//input")]
            private IWebElement streetAddressLine2Text;

            [FindsBy(How = How.XPath, Using = "//*[@id='14e6327a10c-357-1074e0615a9']//input")]
            private IWebElement streetAddressLine3Text;

            [FindsBy(How = How.XPath, Using = "//*[@id='14e6327ab31-358-36f68fc861']//input")]
            private IWebElement streetAddressLine4Text;

            [FindsBy(How = How.XPath, Using = "//*[@id='14b54731a31-313-ba2c19278']//input")]
            private IWebElement cityText;

            [FindsBy(How = How.XPath, Using = "//*[@id='14b54729863-311-62c002dd95']//select")]
            private IWebElement countrySelect;

            [FindsBy(How = How.XPath, Using = "//*[@id='15c9dbd284e-3d2-103620813d7']//input")]
            private IWebElement stateProvinceText;

            [FindsBy(How = How.XPath, Using = "//*[@id='14b547362f3-315-f9db23da6f']//input")]
            private IWebElement zipPostCodeText;

            //   [FindsBy(How = How.XPath, Using = "//*[@id='15b57f6c27b-3ce-ab74e47a74']//input")]
            // private IWebElement verifyAddressCheckbox;

            [FindsBy(How = How.XPath, Using = "//*[@id='14b547df405-329-fd3ed81142']//input")]
            private IWebElement phoneText;

            [FindsBy(How = How.XPath, Using = "//*[@id='14b547e4fe5-32a-9cf72307b0']//input")]
            private IWebElement faxText;

            [FindsBy(How = How.XPath, Using = "//*[@id='14b54728172-310-7dc4a7717']//input")]
            private IWebElement websiteText;

            [FindsBy(How = How.XPath, Using = "//*[@id='15a44338748-3a5-6737134e00']//input")]
            private IWebElement clientContactEmailText;
            #endregion


            #region Client Billing Requirements Declaration

            private string requireEbillingRadioId = "15a3ef13f76-3d3-7ce338f934";
            private string requireTaskRadioId = "155933368e1-426-8aefbb9b15";

            #endregion


            /* ------------------------------------------------------------------------------------------
            Transactions
            ------------------------------------------------------------------------------------------*/
            #region Section
            public bool IsDisplayed()
            {
                try
                {
                    return clientNameText.Displayed;
                }
                catch
                {
                    return false;
                }
            }
            #endregion

            #region Client Basics
            public void ClientType()
            {
                clientTypeSelect.Select(DataManager.GetParamater("ClientType", DataGenerator.ClientDetails.ClientType));
            }

            public void ClientName()
            {
                clientNameText.Set(DataManager.GetParamater("ClientName", DataGenerator.ClientDetails.ClientName));
            }

            public void ParentCompanyName()
            {
                parentCompanyNameText.Set(DataManager.GetParamater("ParentCompanyName", DataGenerator.ClientDetails.ParentCompanyName));
            }


            public void IsAnyCompany()
            {
                IList<IWebElement> radios = Browser.GetDriver.FindElements(By.Name(isAnyCompanyRadioId));
                radios.Select(DataManager.GetParamater("IsAnyCompany", DataGenerator.ClientDetails.IsAnyCompany));

            }


            public void ExistingClient()
            {
                string search = DataManager.GetParamater("SearchExistingClient", DataGenerator.Empty);
                string full = DataManager.GetParamater("ExistingClient", DataGenerator.Empty);

                existingClientText.Set(search);
                ControlHelper.SelectAutoComplete(existingClientContainer, existingClientText, search, full);
            }
            #endregion

            #region Hidden when Client <> Individual
            public void ClientTitle()
            {
                string search = DataManager.GetParamater("SearchClientTitle", "");
                string full = DataManager.GetParamater("ClientTitle", "");

                clientTitleText.Set(search);
                ControlHelper.SelectAutoComplete(clientTitleContainer, clientTitleText, search, full);
            }

            public void ClientFirstName()
            {
                clientFirstNameText.Set(DataManager.GetParamater("ClientFirstName", ""));
            }
            public void ClientMiddleName()
            {
                clientMiddleNameText.Set(DataManager.GetParamater("ClientMiddleName", ""));
            }
            public void ClientLastName()
            {
                clientLastNameText.Set(DataManager.GetParamater("ClientLastName", ""));
            }

            public void ClientSuffix()
            {
                string search = DataManager.GetParamater("SearchClientSuffix", "");
                string full = DataManager.GetParamater("ClientSuffix", "");

                clientSuffixText.Set(search);
                ControlHelper.SelectAutoComplete(clientSuffixContainer, clientSuffixText, search, full);
            }

            #endregion


            #region Client Address

            public void ClientContactName()
            {
                clientContactNameText.Set(DataManager.GetParamater("clientContactName", DataGenerator.ClientDetails.ClientContactName));
            }
            public void StreetAddressLine1()
            {
                streetAddressLine1Text.Set(DataManager.GetParamater("StreetAddressLine1", DataGenerator.ClientDetails.StreetAddressLine1));
            }
            public void StreetAddressLine2()
            {
                streetAddressLine2Text.Set(DataManager.GetParamater("StreetAddressLine2", DataGenerator.Empty));
            }
            public void StreetAddressLine3()
            {
                streetAddressLine3Text.Set(DataManager.GetParamater("StreetAddressLine3", DataGenerator.Empty));
            }
            public void StreetAddressLine4()
            {
                streetAddressLine4Text.Set(DataManager.GetParamater("StreetAddressLine4", DataGenerator.Empty));
            }
            public void City()
            {
                cityText.Set(DataManager.GetParamater("City", DataGenerator.ClientDetails.City));
            }

            public void Country()
            {
                countrySelect.Select(DataManager.GetParamater("Country", DataGenerator.ClientDetails.Country));
            }

            public void StateProvince()
            {
                stateProvinceText.Set(DataManager.GetParamater("StateProvince", DataGenerator.ClientDetails.Province));
            }

            public void ZipPostCode()
            {
                zipPostCodeText.Set(DataManager.GetParamater("ZipPostCode", DataGenerator.Empty));
            }

            /*  public void VerifyAddress()
              {
                  verifyAddressCheckbox.Checked();
              } */

            public void Phone()
            {
                phoneText.Set(DataManager.GetParamater("Phone", DataGenerator.Empty));
            }

            public void Fax()
            {
                faxText.Set(DataManager.GetParamater("Fax", DataGenerator.Empty));
            }

            public void Website()
            {
                websiteText.Set(DataManager.GetParamater("Website", DataGenerator.Empty));
            }

            public void ClientContactEmail()
            {
                clientContactEmailText.Set(DataManager.GetParamater("ClientContactEmail", DataGenerator.Empty));
            }


            #endregion


            #region Client Billing Requirements
            public void RequireEbilling()
            {
                IList<IWebElement> radios = Browser.GetDriver.FindElements(By.Name(requireEbillingRadioId));
                radios.Select(DataManager.GetParamater("RequireEbilling", DataGenerator.No));
            }

            public void RequireTask()
            {
                IList<IWebElement> radios = Browser.GetDriver.FindElements(By.Name(requireTaskRadioId));
                radios.Select(DataManager.GetParamater("RequireTask", DataGenerator.No));
            }




            #endregion  

        }

    }
}
