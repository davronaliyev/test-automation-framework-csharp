using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using STAF.Framework.HelperClasses;
using System.Configuration;

namespace STAF.Framework.BaseClasses
{
    class BaseSetup : ReportLog.Base
    {
        internal static IWebDriver Instance { get; set; }
        [SetUp]
        public void BaseInitialize()
        {
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
