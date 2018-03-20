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

        public class MatterDetails
        {

            #region Matter Information Declaration

            [FindsBy(How = How.XPath, Using = "//*[@id='1487fc8be25-2a2-cea437db0']//input")]
            private IWebElement matterNameText;

            [FindsBy(How = How.XPath, Using = "//*[@id='1487fce612d-2aa-13deb238530']//textarea")]
            private IWebElement matterDescriptionTextArea;

            private string isThisMatterRadioId = "1487fcef44f-2b1-b8d2a04e0a";

            private string isThisACitizenshipRadioId = "1487fd0c65b-2b5-73168a093d";

            private string additionalInfoRadioId = "148c9aafbe2-2ab-4719a607b6";

            private string doesTheMatterInvolveRadioId = "148c98f3a07-26a-12868abbf0d";

            [FindsBy(How = How.XPath, Using = "//*[@id='1487fd6609c-2bc-1195db9a6ce']//select")]
            private IWebElement matterPracticeAreaSelect;

            [FindsBy(How = How.XPath, Using = "//*[@id='1487fd657bc-2bb-125b1995293']//select")]
            private IWebElement matterWorkTypeSelect;

            [FindsBy(How = How.XPath, Using = "//*[@id='148eae0193e-2cc-148576c94e4']//select")]
            private IWebElement matterIndustrySectorSelect;

            private string wasThisMatterRadioId = "148c99b78c3-288-66a5c8ffc";

            #endregion


            #region Sanctions Declaration

            private string sanctionsRadioId = "148d25acd9f-1af-168f9f7829";

            #endregion

            #region Related Parties Declaration

            private string isPharmaceuricalsRadioId = "148c9a7e0e7-29d-edfda99371";

            private string areThereAnyProspectiveRadioId = "148c9b54888-2b3-123ad4066ca";


            [FindsBy(How = How.XPath, Using = "//*[@id='148c9b84c9f-2bb-f095ed7f64']//textarea")]
            private IWebElement pleaseExplainTextArea;

            #endregion

            #region Matter Financials Declaration
            [FindsBy(How = How.XPath, Using = "//*[@id='148f6cb725a-2c8-b703808471']//select")]
            private IWebElement matterFeeArranagementTypeSelect;


            private string standardBillingRatesRadioId = "14a2ebe1c95-2e9-db0666f348";


            [FindsBy(How = How.XPath, Using = "//*[@id='148f6ce6b4a-2d1-add892309a']//textarea")]
            private IWebElement describeArrangementTextArea;

            [FindsBy(How = How.XPath, Using = "//*[@id='148f6d2f2d6-2e0-121f2f3bc43']//select")]
            private IWebElement matterCurrencySelect;

            [FindsBy(How = How.XPath, Using = "//*[@id='148f6d18c2b-2d7-4f4c0c7ce3']//input")]
            private IWebElement expectedFeesTextArea;

            private string expectedFeesRadioId = "15cd58c5040-3ce-4d84b462f6";

            private string pricingTeamConsultedRadioId = "15cd18eada6-3c5-5d58a48ace";

            private string legalProjectRadioId = "15cd5f311fa-3bf-1202f1b6fcd";

            //private string arrangementApprovedRadioId = "148f6ccee6c-2ce-6a9e6e7574";

            [FindsBy(How = How.XPath, Using = "//*[@id='148f6d4ff86-2e5-ce4a283140']//select")]
            private IWebElement invoiceLanguageSelect;

            #endregion


            #region Special Approvals Declaration
            [FindsBy(How = How.XPath, Using = "//*[@id='14a3027230c-2f2-14223ff6ba3']//input")]
            private IWebElement firmLawyerOwnsCheckbox;

            [FindsBy(How = How.XPath, Using = "//*[@id='14a302a5190-2f9-c0e15c7714']//input")]
            private IWebElement takingRepresentationCheckbox;


            [FindsBy(How = How.XPath, Using = "//*[@id='14a33aa9338-2ec-148157ed4d8']//textarea")]
            private IWebElement explainNeedsTextArea;


            #endregion



            /* ------------------------------------------------------------------------------------------
            Transactions
            ------------------------------------------------------------------------------------------*/
            #region Section
            public bool IsDisplayed()
            {
                try
                {
                    return matterNameText.Displayed;
                }
                catch
                {
                    return false;
                }

            }

            #endregion

            #region Matter Information
            public void MatterName()
            {
                matterNameText.Set(DataManager.GetParamater("MatterName", DataGenerator.MatterDetails.Name));
            }

            public void MatterDescription()
            {
                matterDescriptionTextArea.Set(DataManager.GetParamater("MatterDescription", DataGenerator.MatterDetails.Description));
            }

            public void IsThisMatter()
            {
                IList<IWebElement> radios = Browser.GetDriver.FindElements(By.Name(isThisMatterRadioId));
                radios.Select(DataManager.GetParamater("IsThisMatter", DataGenerator.No));
            }


            public void IsThisACitizanship()
            {
                IList<IWebElement> radios = Browser.GetDriver.FindElements(By.Name(isThisACitizenshipRadioId));
                radios.Select(DataManager.GetParamater("IsThisACitizanship", DataGenerator.No));
            }

            public void AdditionalInfo()
            {
                IList<IWebElement> radios = Browser.GetDriver.FindElements(By.Name(additionalInfoRadioId));
                radios.Select(DataManager.GetParamater("AdditionalInfo", DataGenerator.No));
            }

            public void DoesTheMatterInvolve()
            {
                IList<IWebElement> radios = Browser.GetDriver.FindElements(By.Name(doesTheMatterInvolveRadioId));
                radios.Select(DataManager.GetParamater("DoesTheMatterInvolve", DataGenerator.No));
            }


            public void MatterPracticeArea()
            {
                matterPracticeAreaSelect.Select(DataManager.GetParamater("MatterPracticeArea", DataGenerator.MatterDetails.MatterPracticeArea));
            }

            public void MatterWorkType()
            {
                matterWorkTypeSelect.Select(DataManager.GetParamater("MatterWorkType", DataGenerator.MatterDetails.MatterWorkType));
            }

            public void MatterIndustrySector()
            {
                matterIndustrySectorSelect.Select(DataManager.GetParamater("MatterIndustrySector", DataGenerator.MatterDetails.MatterIndustryType));
            }


            public void WasThisMatter()
            {
                IList<IWebElement> radios = Browser.GetDriver.FindElements(By.Name(wasThisMatterRadioId));
                radios.Select(DataManager.GetParamater("wasThisMatterRadio", DataGenerator.No));
            }


            #endregion


            #region Sanctions 
            public void Sanctions()
            {
                IList<IWebElement> radios = Browser.GetDriver.FindElements(By.Name(sanctionsRadioId));
                radios.Select(DataManager.GetParamater("Sanctions", DataGenerator.No));

            }

            #endregion

            #region Related Parties 

            public void IsPharmaceuricals()
            {
                IList<IWebElement> radios = Browser.GetDriver.FindElements(By.Name(isPharmaceuricalsRadioId));
                radios.Select(DataManager.GetParamater("IsPharmaceuricals", DataGenerator.No));

            }

            public void AreThereAnyProspective()
            {
                IList<IWebElement> radios = Browser.GetDriver.FindElements(By.Name(areThereAnyProspectiveRadioId));
                radios.Select(DataManager.GetParamater("AreThereAnyProspective", DataGenerator.No));

            }

            public void PleaseExplain()
            {
                pleaseExplainTextArea.Set(DataManager.GetParamater("PleaseExplain", DataGenerator.MatterDetails.PleaseExplain));
            }




            #endregion

            #region Matter Financials

            public void MatterFeeArranagementType()
            {
                matterFeeArranagementTypeSelect.Select(DataManager.GetParamater("MatterFeeArranagementType", DataGenerator.MatterDetails.MatterFeeArranagementType));
            }


            public void StandardBillingRates()
            {
                IList<IWebElement> radios = Browser.GetDriver.FindElements(By.Name(standardBillingRatesRadioId));
                radios.Select(DataManager.GetParamater("StandardBillingRates", DataGenerator.Yes));

            }


            public void DescribeArrangement()
            {
                describeArrangementTextArea.Set(DataManager.GetParamater("DescribeArrangement", DataGenerator.MatterDetails.DescribeArrangement));
            }

            public void MatterCurrency()
            {
                matterCurrencySelect.Select(DataManager.GetParamater("MatterCurrency", DataGenerator.MatterDetails.MatterCurrency));

            }

            public void ExpectedFees()
            {
                expectedFeesTextArea.Set(DataManager.GetParamater("ExpectedFees", DataGenerator.MatterDetails.ExpectedFees));
            }

            public void ExpectedFeesRadio()
            {
                IList<IWebElement> radios = Browser.GetDriver.FindElements(By.Name(expectedFeesRadioId));
                radios.Select(DataManager.GetParamater("ExpectedFeesRadio", DataGenerator.No));
            }

            public void PricingTeamConsult()
            {
                IList<IWebElement> radios = Browser.GetDriver.FindElements(By.Name(pricingTeamConsultedRadioId));
                radios.Select(DataManager.GetParamater("PricingTeamConsult", DataGenerator.No));
            }

            public void LegalProjectManagement()
            {
                IList<IWebElement> radios = Browser.GetDriver.FindElements(By.Name(legalProjectRadioId));
                radios.Select(DataManager.GetParamater("LegalProjectManagement", DataGenerator.No));
            }

            /*  public void ArrangementApproved()
              {
                  IList<IWebElement> radios = Browser.GetDriver.FindElements(By.Name(arrangementApprovedRadioId));
                  radios.Select(DataManager.GetParamater("ArrangementApproved", DataGenerator.Yes));

              } */

            public void InvoiceLanguage()
            {
                invoiceLanguageSelect.Select(DataManager.GetParamater("InvoiceLanguage", DataGenerator.MatterDetails.InvoiceLanguage));

            }

            #endregion


            #region Special Approvals 

            public void FirmLawyerOwns()
            {
                firmLawyerOwnsCheckbox.Checked();
                // Set(DataManager.GetParamater("FirmLawyerOwns", DataGenerator.));
            }

            public void TakingRepresentation()
            {
                takingRepresentationCheckbox.Checked();
                //Set(DataManager.GetParamater("TakingRepresentation", DataGenerator.Empty));
            }


            public void ExplainNeeds()
            {
                explainNeedsTextArea.Set(DataManager.GetParamater("ExplainNeeds", DataGenerator.MatterDetails.ExplainNeeds));
            }

            #endregion















        }
    }
}
