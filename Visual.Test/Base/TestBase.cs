using System;
using System.Configuration;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using BridgerEye.Framework.PageObjects.Common;
using BridgerEye.Framework.PageObjects.Realtime;
using NUnit.Framework;
using NUnit.Framework.Interfaces;

namespace BridgerEye.Framework.Base
{
    public class TestBase : PageBase
    {
        protected internal LoginPage LoginPage = new LoginPage();
        protected internal RealTimeSearchPage Search = new RealTimeSearchPage();
        protected internal VisualEye VisualEye = new VisualEye();
        private readonly string _time = DateTime.Now.ToString(" MM-dd-yyyy hh-mm tt");
        private static ExtentReports _htmlReport { get; set; }

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            // Initializes html report
            var reportPath = AppDomain.CurrentDomain.BaseDirectory + ConfigurationManager.AppSettings["ReportPath"];
            ExtentHtmlReporter _html = new ExtentHtmlReporter(reportPath + "Test Report - " + _time + "/");
            _htmlReport = new ExtentReports();
            _htmlReport.AttachReporter(_html);
            // Initializes web driver
            Initialize();
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            Driver?.Quit();
            _htmlReport.Flush();
        }

        [SetUp]
        public void SetUp()
        {
            TestLog = _htmlReport.CreateTest(TestContext.CurrentContext.Test.Name);
            Driver.Navigate().GoToUrl(_baseUrl + "/XGAuth/");
            TestLog.Pass("Successfully navigated to <b>" + _baseUrl + "/XGAuth/");
        }

        [TearDown]
        public void TearDown()
        {
            LoginPage.Signout();

            // Gets status of test
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var stacktrace = string.IsNullOrEmpty(TestContext.CurrentContext.Result.StackTrace)
                ? ""
                : $"{TestContext.CurrentContext.Result.StackTrace}";
            Status logstatus;

            // Prints status to test report
            switch (status)
            {
                case TestStatus.Failed:
                    logstatus = Status.Fail;
                    break;
                case TestStatus.Inconclusive:
                    logstatus = Status.Warning;
                    break;
                case TestStatus.Skipped:
                    logstatus = Status.Skip;
                    break;
                default:
                    logstatus = Status.Pass;
                    break;
            }
            // Ends test in test report
            TestLog.Log(logstatus, "Test ended with " + logstatus);
        }
    }
}
