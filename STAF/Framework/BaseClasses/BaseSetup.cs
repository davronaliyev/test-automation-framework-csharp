using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using STAF.Framework.HelperClasses;
using System;
using System.Configuration;

namespace STAF.Framework.BaseClasses
{
    class BaseSetup
    {
        protected ExtentReports _extent;
        protected ExtentTest _test;






        [OneTimeSetUp]
        protected void Setup()
        {
            var dir = TestContext.CurrentContext.TestDirectory + ConfigurationManager.AppSettings["ReportPath"];
            //var now = DateTime.Now.ToString("MM-dd-yyyy H-mm ");
            //var fileName = this.GetType().ToString() + now + "Test Report.html";
            var htmlReporter = new ExtentHtmlReporter(dir + DateTime.Now.ToString("MM-dd-yyyy H-mm ") + "Test Report.html");



            // theme - standard, dark
            htmlReporter.Configuration().Theme = Theme.Standard;


            // report title
            htmlReporter.Configuration().ReportName = "Automation Report";



            _extent = new ExtentReports();
            _extent.AttachReporter(htmlReporter);
        }

        [OneTimeTearDown]
        protected void TearDown()
        {
            _extent.Flush();
        }




        internal static IWebDriver Instance { get; set; }
        [SetUp]
        public void BaseInitialize()
        {
            _test = _extent.CreateTest(TestContext.CurrentContext.Test.Name);



            switch (ConfigurationManager.AppSettings["Browser"].ToString())
            {
                case "Chrome":
                    Instance = new ChromeDriver(GetChromeOptions());
                    Instance.Navigate().GoToUrl(ConfigurationManager.AppSettings["URL"]);

                    // Screenshot
                    string screenName = ScreenshotHelper.TakeScreenshot();
                    _test.Pass("Chrome browser is open.").AddScreenCaptureFromPath(@"C:\Users\daliyev\OneDrive - DSS\Projects\Git\STA-framework-with-csharp\Reports\screenshots\" + screenName);





                    break;









                case "Firefox":
                    Instance = new FirefoxDriver();
                    Instance.Manage().Window.Maximize();
                    Instance.Navigate().GoToUrl(ConfigurationManager.AppSettings["URL"]);
                    break;












                case "IE":
                    Instance = new InternetExplorerDriver(IEOptions);
                    Instance.Manage().Window.Maximize();
                    Instance.Navigate().GoToUrl(ConfigurationManager.AppSettings["URL"]);
                    break;
            }






        }
        [TearDown]
        public void BaseCleanUp()
        {

            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var stacktrace = string.IsNullOrEmpty(TestContext.CurrentContext.Result.StackTrace)
                    ? ""
                    : string.Format("{0}", TestContext.CurrentContext.Result.StackTrace);
            Status logstatus;

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

            _test.Log(logstatus, "Test ended with " + logstatus + stacktrace);
            _extent.Flush();

            Instance.Close();
            Instance.Quit();




        }
        private static InternetExplorerOptions IEOptions
        {
            get
            {
                InternetExplorerOptions options = new InternetExplorerOptions
                {
                    IntroduceInstabilityByIgnoringProtectedModeSettings = true,
                    IgnoreZoomLevel = true,
                    EnablePersistentHover = false,
                    EnableNativeEvents = false
                };
                return options;
            }
        }
        private static ChromeOptions GetChromeOptions()
        {
            ChromeOptions option = new ChromeOptions();
            option.AddArgument("start-maximized");
            option.AddArgument("--headless");
            return option;
        }
    }
}
