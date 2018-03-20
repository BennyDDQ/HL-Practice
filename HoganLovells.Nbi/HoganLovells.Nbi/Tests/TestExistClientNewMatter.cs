using NUnit.Framework;

namespace HoganLovells.Nbi
{
    // [TestFixture]
    public class TestExistClientNewMatter : TestBase
    {
        [Test]
        [TestCase(1)]
        public void MyFirstTest(int row)
        {
            // Must the first statement to set which row must be provided
            DataManager.Initialise(row);

            Pages.Dashboard.VerifyIsOnPage();
            Pages.Dashboard.CreateNewRequest();

            Pages.CreateANewRequest.VerifyIsOnPage();
            Pages.SelectClient.FindSelectClient();
            Pages.CreateANewRequest.CreateRequest();

            Pages.Request.VerifyIsOnPage();

            Pages.Request.CompleteGeneralInformation();
            Pages.Request.CompleteMatterDetails();
        }
    }
}
