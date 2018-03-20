

namespace HoganLovells.Nbi
{
    public partial class Dashboard
    {

        public void CreateNewRequest()
        {
            ClickCreateNewRequest();
        }


        public void VerifyIsOnPage()
        {
            Wait();
            Verify.AssertIsTrue(IsOnPage());
        }


    }
}
