using BridgerEye.Framework.Base;
using NUnit.Framework;

namespace BridgerEye.Tests.TestSuite
{
    [TestFixture()]
    public class DemoTest : TestBase
    {
        [TestCase("English")]
        //[TestCase("Spanish")]
        //[TestCase("Portugues")]
        //[TestCase("Deutsch")]
        //[TestCase("French")]
        //[TestCase("Chinese")]
        //[TestCase("Japanese")]
        public void RealTimeSearch_DemoTestCase(string language)
        {
            LoginPage.LinkChecker(19);

            //// Arrange
            //LoginPage
            //    .ChangeLanguage(language)
            //    .Signin();

            //// Act
            //Search
            //    .ListScreening("DAVID", "WASHINGTON")
            //    .HideAllMatches();

            //// Assert
            //VisualEye.Scan("Results");
        }
    }
}
