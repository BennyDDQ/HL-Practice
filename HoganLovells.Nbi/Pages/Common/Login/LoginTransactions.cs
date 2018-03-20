

namespace HoganLovells.Nbi
{
    public partial class Login
    {
        public void Authenticate()
        {
            SetUsername();
            SetPassword();
            ClickLogin();           
        }

        public void VerifyIsOnPage()
        {
            Wait();
            Verify.AssertIsTrue(IsOnPage());
        }

    }
}
