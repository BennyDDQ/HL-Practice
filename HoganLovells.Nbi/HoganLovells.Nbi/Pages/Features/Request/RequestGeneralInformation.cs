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

        public class GeneralInformation
        {

            #region Request Details Declaration

            [FindsBy(How = How.XPath, Using = "//div[@id='1521ddf1662-22d-66fd6c7c9e']")]
            private IWebElement requestingPartnerContainer;

            [FindsBy(How = How.XPath, Using = "//div[@id='1521ddf1662-22d-66fd6c7c9e']//input")]
            private IWebElement requestingPartnerText;


            [FindsBy(How = How.XPath, Using = "//div[@id='15878efd9dc-399-27cc0455cf']")]
            private IWebElement otherUpdateRequestContainer;

            [FindsBy(How = How.XPath, Using = "//div[@id='15878efd9dc-399-27cc0455cf']//input")]
            private IWebElement otherUpdateRequestText;


            [FindsBy(How = How.XPath, Using = "//div[@id='148d250e298-1a1-d3f949a0a6']")]
            private IWebElement otherStatusUpdatesContainer;

            [FindsBy(How = How.XPath, Using = "//div[@id='148d250e298-1a1-d3f949a0a6']//input")]
            private IWebElement otherStatusUpdatesText;


            [FindsBy(How = How.XPath, Using = "//div[@id='148d24e8785-187-8cf96638d9']//textarea")]
            private IWebElement urgencyReasonTextArea;


            private string priorityLevelRadioId = "148d24e2f5d-182-107861b94ef";

            [FindsBy(How = How.XPath, Using = "//div[@id='148d251abe8-1a4-11a115c9116']//input")]
            private IWebElement seeConflictsReportCheckbox;

            #endregion

            #region Involved Fee Earners - Declarations
            [FindsBy(How = How.XPath, Using = "//div[@id='148c9cfa298-366-ee0f58925c']")]
            private IWebElement matterSupervisingPartnerContainer;

            [FindsBy(How = How.XPath, Using = "//div[@id='148c9cfa298-366-ee0f58925c']//input")]
            private IWebElement matterSupervisingPartnerText;


            [FindsBy(How = How.XPath, Using = "//div[@id='14a33c4e227-2e9-ebef321828']")]
            private IWebElement matterLlpContainer;

            [FindsBy(How = How.XPath, Using = "//div[@id='14a33c4e227-2e9-ebef321828']//input")]
            private IWebElement matterLlpText;


            [FindsBy(How = How.XPath, Using = "//div[@id='148c9d054c5-36d-78637268e3']")]
            private IWebElement supervisingFeeEarnerContainer;

            [FindsBy(How = How.XPath, Using = "//div[@id='148c9d054c5-36d-78637268e3']//input")]
            private IWebElement supervisingFeeEarnerText;

            #endregion


            /* ------------------------------------------------------------------------------------------
            Transactions
            ------------------------------------------------------------------------------------------*/
            public bool IsDisplayed()
            {
                try
                {
                    return requestingPartnerText.Displayed;
                }
                catch
                {
                    return false;
                }

            }

            public void RequestingPartner()
            {
                string search = DataManager.GetParamater("RequestingPartnerSearch", DataGenerator.GeneralInformation.RequestingPartnerSearch);
                string full = DataManager.GetParamater("RequestingPartner", DataGenerator.GeneralInformation.RequestingPartner);

                requestingPartnerText.Set(search);
                ControlHelper.SelectAutoComplete(requestingPartnerContainer, requestingPartnerText, search, full);
            }


            public void OthersUpdateRequest()
            {
                string search = DataManager.GetParamater("OtherUpdateRequestSearch", "Therese Goldsmith");
                string full = DataManager.GetParamater("OtherUpdateRequest", "Therese Goldsmith (workfloweval@hoganlovells.com)");

                otherUpdateRequestText.Set(search);
                ControlHelper.SelectAutoComplete(otherUpdateRequestContainer, otherUpdateRequestText, search, full);
            }


            public void OtherStatusUpdates()
            {
                string search = DataManager.GetParamater("OtherStatusUpdatesSearch", "Carol Licko");
                string full = DataManager.GetParamater("OtherStatusUpdates", "Carol Licko (workfloweval@hoganlovells.com)");

                otherStatusUpdatesText.Set(search);
                ControlHelper.SelectAutoComplete(otherStatusUpdatesContainer, otherStatusUpdatesText, search, full);
            }



            public void PriorityLevel()
            {
                IList<IWebElement> radios = Browser.GetDriver.FindElements(By.Name(priorityLevelRadioId));
                radios.Select(DataManager.GetParamater("PriorityLevel", "Normal"));

            }

            public void UrgencyReason()
            {
                string data = DataManager.GetParamater("UrgencyReason", DataGenerator.Empty);
                urgencyReasonTextArea.Set(data);
            }

            public void Deadline()
            {
                throw new Exception("Not Implemented");
            }


            public void ConflictsReport()
            {
                seeConflictsReportCheckbox.Checked();
            }



            public void MatterSupervisingPartner()
            {
                string search = DataManager.GetParamater("MatterSupervisingPartnerSearch", "Breed");
                string full = DataManager.GetParamater("MatterSupervisingPartner", "Breed, Logan (05146)");

                matterSupervisingPartnerText.Set(search);
                ControlHelper.SelectAutoComplete(matterSupervisingPartnerContainer, matterSupervisingPartnerText, search, full);
            }


            public void MatterLlp()
            {
                string search = DataManager.GetParamater("MatterLlp", "Alicante");
                string full = DataManager.GetParamater("MatterLlp", "Alicante");

                matterLlpText.Set(search);
                ControlHelper.SelectAutoComplete(matterLlpContainer, matterLlpText, search, full);
            }


            public void SupervisingFeeEarner()
            {
                string search = DataManager.GetParamater("SupervisingFeeEarnerSearch", "Boswell");
                string full = DataManager.GetParamater("SupervisingFeeEarner", "Boswell, Donna (00285)");

                supervisingFeeEarnerText.Set(search);
                ControlHelper.SelectAutoComplete(supervisingFeeEarnerContainer, supervisingFeeEarnerText, search, full);
            }




        }


    }
}
