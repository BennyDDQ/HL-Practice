

namespace HoganLovells.Nbi
{
    public partial class Login
    {
        public void SetUsername()
        {
            usernameField.Set(DataManager.GetParamater("Username", @"adslocal\hydesa01"));
        }

        public void SetPassword()
        {
            passwordField.Set(DataManager.GetParamater("Password", "openuser"));  
        }

        public void ClickLogin()
        {
            logInButton.Click2();
        }

    }
}
