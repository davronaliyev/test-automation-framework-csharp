using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System.Configuration;

namespace STAF.Framework.BaseClasses
{
    class BaseSetup
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
            //option.AddArgument("--headless");
            return option;
        }
    }
}
