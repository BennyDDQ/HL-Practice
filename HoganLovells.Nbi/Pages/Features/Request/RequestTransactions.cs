

using OpenQA.Selenium;
using System.Collections.Generic;

namespace HoganLovells.Nbi
{
    public partial class Request
    {

        public void VerifyIsOnPage()
        {
            Wait();
            Verify.AssertIsTrue(IsOnPage());
        }

        public void DebugCheck()
        {
            string x = DataManager.GetParamater("RequestingPartner", "Not Found");


        }


        public void CompleteGeneralInformation()
        {
            ExpandSection(sectionGeneralInformation);

            Pages.GeneralInformationRequest.RequestingPartner();
            Pages.GeneralInformationRequest.OthersUpdateRequest();
            Pages.GeneralInformationRequest.OtherStatusUpdates();

            Pages.GeneralInformationRequest.PriorityLevel();
            Pages.GeneralInformationRequest.UrgencyReason();
            Pages.GeneralInformationRequest.ConflictsReport();

            Pages.GeneralInformationRequest.MatterSupervisingPartner();
            Pages.GeneralInformationRequest.MatterLlp();
            Pages.GeneralInformationRequest.SupervisingFeeEarner();
        }


        public void CompleteClientDetails()
        {

            ExpandSection(sectionClientDetails);

            Pages.ClientDetailsRequest.ClientType();
            Pages.ClientDetailsRequest.ClientName();

            Pages.ClientDetailsRequest.ParentCompanyName();
            Pages.ClientDetailsRequest.IsAnyCompany();
            Pages.ClientDetailsRequest.ExistingClient();

            //  Typically Hidden
            Pages.ClientDetailsRequest.ClientTitle();
            Pages.ClientDetailsRequest.ClientFirstName();
            Pages.ClientDetailsRequest.ClientMiddleName();
            Pages.ClientDetailsRequest.ClientLastName();
            Pages.ClientDetailsRequest.ClientSuffix();

            // Client Address
            Pages.ClientDetailsRequest.ClientContactName();
            Pages.ClientDetailsRequest.StreetAddressLine1();
            Pages.ClientDetailsRequest.StreetAddressLine2();
            Pages.ClientDetailsRequest.StreetAddressLine3();
            Pages.ClientDetailsRequest.StreetAddressLine4();
            Pages.ClientDetailsRequest.City();
            Pages.ClientDetailsRequest.Country();
            Pages.ClientDetailsRequest.StateProvince();
            Pages.ClientDetailsRequest.ZipPostCode();
            //    Pages.ClientDetailsRequest.VerifyAddress();
            Pages.ClientDetailsRequest.Phone();
            Pages.ClientDetailsRequest.Fax();
            Pages.ClientDetailsRequest.Website();
            Pages.ClientDetailsRequest.ClientContactEmail();


            Pages.ClientDetailsRequest.RequireEbilling();
            Pages.ClientDetailsRequest.RequireTask();


        }


        public void CompleteMatterDetails()
        {
            ExpandSection(sectionMatterDetails);

            // Matter Information
            Pages.MatterDetailsRequest.MatterName();
            Pages.MatterDetailsRequest.MatterDescription();
            Pages.MatterDetailsRequest.IsThisMatter();
            Pages.MatterDetailsRequest.IsThisACitizanship();
            Pages.MatterDetailsRequest.AdditionalInfo();
            Pages.MatterDetailsRequest.DoesTheMatterInvolve();
            Pages.MatterDetailsRequest.MatterPracticeArea();
            Pages.MatterDetailsRequest.MatterWorkType();
            Pages.MatterDetailsRequest.MatterIndustrySector();
            Pages.MatterDetailsRequest.WasThisMatter();

            Pages.MatterDetailsRequest.Sanctions();

            Pages.MatterDetailsRequest.IsPharmaceuricals();
            Pages.MatterDetailsRequest.AreThereAnyProspective();
            Pages.MatterDetailsRequest.PleaseExplain();

            Pages.MatterDetailsRequest.MatterFeeArranagementType();
            Pages.MatterDetailsRequest.StandardBillingRates();
            Pages.MatterDetailsRequest.DescribeArrangement();
            Pages.MatterDetailsRequest.MatterCurrency();
            Pages.MatterDetailsRequest.ExpectedFees();
            Pages.MatterDetailsRequest.ExpectedFeesRadio();
            Pages.MatterDetailsRequest.PricingTeamConsult();
            Pages.MatterDetailsRequest.LegalProjectManagement();
            //  Pages.MatterDetailsRequest.ArrangementApproved();
            Pages.MatterDetailsRequest.InvoiceLanguage();
            Pages.MatterDetailsRequest.FirmLawyerOwns();
            Pages.MatterDetailsRequest.TakingRepresentation();
            Pages.MatterDetailsRequest.ExplainNeeds();
            Pages.SubmitFormRequest.SubmitFormButton();

        }





    }
}
