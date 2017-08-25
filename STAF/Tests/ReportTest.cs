using AventStack.ExtentReports;
using NUnit.Framework;
using STAF.Framework.BaseClasses;
using STAF.Framework.HelperClasses;
using STAF.Framework.Pages;
using System;
using System.Configuration;

namespace STAF.Tests
{
    [TestFixture]
    class ReportTest : BaseSetup
    {
        //[Test]
        public void DemoTest()
        {
            _test.Info("<span class=\"label white-text blue\">" +
                "Step 1: </span> Enter valid user name.");
            _test.Pass("Able to enter user name.");
            _test.Info("<span class=\"label white-text blue\">" +
                "Step 2: </span> Enter valid password.");
            _test.Warning("Able to enter password.");
            _test.Info("<span class=\"label white-text blue\">" +
                "Step 3: </span> Click Login button.");
            _test.Fail("Able to click the button.", MediaEntityBuilder.CreateScreenCaptureFromPath(AppDomain.CurrentDomain.BaseDirectory + ConfigurationManager.AppSettings["ScreenshotPath"] + ScreenshotHelper.TakeScreenshot()).Build());

            //Driver.InsertText(By.XPath("//input[@ng-model='user.firstName']"), "Test123");
            //Instance.FindElement(By.XPath("//input[@ng-model='user.firstName']")).SendKeys("Test123");
        }

        [Test]
        public void TestCase_01()
        {
            TestStep("Step 1", "Verify the page header.");
            Verify.AreEqual("Fee Basis Claims Systemm", PageClassTemplate.pageHeader);
            TestStep("Step 2", "Verify the page header again.");
            Verify.AreEqual("Fee Basis Claims System", PageClassTemplate.pageHeader);
        }
        [Test]
        public void TestCase_02()
        {
            // Step 1: Do something!
            TestStep("Step 1", "Do something!");
            // Step 2: Do something!
            TestStep("Step 2", "Do something!");
            // Step 3: Do something!
            TestStep("Step 3", "Click login button.");
            // Step 4: Do something!
            TestStep("Step 4", "Click login button.");
        }
        [Test]
        public void TestCase_03()
        {
            // Step 1: Do something!
            TestStep("Step 1", "Do something!");
            // Step 2: Do something!
            TestStep("Step 2", "Do something!");
            // Step 3: Do something!
            TestStep("Step 3", "Click login button.");
            // Step 4: Do something!
            TestStep("Step 4", "Click login button.");
        }


    }
}
