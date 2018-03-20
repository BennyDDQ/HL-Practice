using NUnit.Framework;

namespace HoganLovells.Nbi
{
    [TestFixture]
    public class SampleTest : TestBase  //inherits the set up tear down stuff
    {

        
        [Test]
        [TestCase (1)]   //[] annotation
        public void MyFirstTest(int row)
        {
            // Must the first statement to set which row must be provided
            DataManager.Initialise(row);

            Pages.Login.VerifyIsOnPage();
            Pages.Login.Authenticate();

            Pages.Dashboard.VerifyIsOnPage();
            //Browser.Navigate("https://nbidev.hoganlovells.com/Open/app/index.html#/requests/831");
            Pages.Dashboard.CreateNewRequest();

            Pages.CreateANewRequest.VerifyIsOnPage();
            Pages.CreateANewRequest.CreateRequest();

            Pages.Request.VerifyIsOnPage();

            Pages.Request.CompleteGeneralInformation();
            Pages.Request.CompleteClientDetails();
            Pages.Request.CompleteMatterDetails();

            //Pages.Request.DebugCheck();

        }


        [Test]
        [TestCase(1), Ignore("Debugging")]       
        public void DebugTest(int row)
        {
            DataManager.Initialise(row);
            Pages.Request.DebugCheck();
        }
    }
}
