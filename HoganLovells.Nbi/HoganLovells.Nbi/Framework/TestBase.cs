using NUnit.Framework;

namespace HoganLovells.Nbi
{
    [TestFixture]
    public class TestBase
    {       
        
        [OneTimeSetUp]
        public static void OneTimeSetUp()
        {
            // Initialise the reports
            Reporting.Initialise();
            
        }

        [SetUp]
        public static void TestInitialise()
        {
            Browser.Initialize();

            string testName = TestContext.CurrentContext.Test.Name;
            Reporting.CurrentTest = testName.Substring(0, testName.IndexOf("("));

            string className = TestContext.CurrentContext.Test.ClassName;
            string[] data = className.Split('.');
            Reporting.CurrentSuite = data[data.Length - 1];

            Reporting.TestInitialise();
        }


        [TearDown]
        public static void TestTerminate()
        {
            TestContext.ResultAdapter resultAdapter = TestContext.CurrentContext.Result;            
            Reporting.TestTerminate(resultAdapter);
           //Browser.Terminate();
            
        }
        

        [OneTimeTearDown]
        public static void OneTimeTearDown()
        {
            Reporting.Terminate();
        }

    }
}
