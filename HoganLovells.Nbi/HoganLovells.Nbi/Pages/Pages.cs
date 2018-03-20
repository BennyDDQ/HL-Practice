using OpenQA.Selenium.Support.PageObjects;


namespace HoganLovells.Nbi
{
    public static class Pages
    {
        private static T GetPage<T>() where T : new()
        {
            var page = new T();
            PageFactory.InitElements(Browser.Driver, page);
            return page;
        }

        public static Login Login
        {
            get { return GetPage<Login>(); }
        }

        public static Dashboard Dashboard
        {
            get { return GetPage<Dashboard>(); }
        }

        public static CreateANewRequest CreateANewRequest
        {
            get { return GetPage<CreateANewRequest>(); }
        }

        /*   public static SelectClient.SearchClient SearchClient
           {
               get { return GetPage<SelectClient.SearchClient>(); }
           } */

        public static SelectClient SelectClient
        {
            get { return GetPage<SelectClient>(); }
        }

        public static Request Request
        {
            get { return GetPage<Request>(); }
        }

        public static Request.GeneralInformation GeneralInformationRequest
        {
            get { return GetPage<Request.GeneralInformation>(); }
        }

        public static Request.ClientDetails ClientDetailsRequest
        {
            get { return GetPage<Request.ClientDetails>(); }
        }

        public static Request.MatterDetails MatterDetailsRequest
        {
            get { return GetPage<Request.MatterDetails>(); }
        }

        public static Request.SubmitForm SubmitFormRequest
        {
            get { return GetPage<Request.SubmitForm>(); }
        }


       /* public static Temp1.Temp2 Temp2
        {
            get { return GetPage<Temp1.Temp2>(); }
        }*/

    }
}
