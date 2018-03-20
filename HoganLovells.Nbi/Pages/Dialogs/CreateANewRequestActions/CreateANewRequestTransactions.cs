

namespace HoganLovells.Nbi
{
    public partial class CreateANewRequest
    {

        public void VerifyIsOnPage()
        {
            Wait();
            Verify.AssertIsTrue(IsOnPage());
        }

        public void CreateRequest()
        {
            ClickCreateRequest();
        }
    }
}
