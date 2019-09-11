using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System.Configuration;
using AventStack.ExtentReports;


namespace BridgerEye.Framework.Base
{
    public class PageBase
    {
        private readonly string _browser = ConfigurationManager.AppSettings["Browser"];
        private readonly string _headless = ConfigurationManager.AppSettings["Headless"];
        protected readonly string _baseUrl = ConfigurationManager.AppSettings["BaseURL"];
        protected readonly string _clientId = ConfigurationManager.AppSettings["ClientID"];
        protected readonly string _userId = ConfigurationManager.AppSettings["UserID"];
        protected readonly string _password = ConfigurationManager.AppSettings["Password"];
        protected readonly string _verificationCode = ConfigurationManager.AppSettings["VerificationCode"];

        public static IWebDriver Driver { get; set; }
        public static IWebElement Element { get; set; }
        public static ExtentTest TestLog { get; set; }

        protected void Initialize()
        {
            switch (_browser)
            {
                case "Chrome":
                    Driver = new ChromeDriver(_chromeOptions());
                    break;
                case "Firefox":
                    Driver = new FirefoxDriver(_firefoxOptions());
                    Driver.Manage().Window.Maximize();
                    break;
                case "IE":
                    Driver = new InternetExplorerDriver(_ieOptions);
                    Driver.Manage().Window.Maximize();
                    break;
                default:
                    Driver = new ChromeDriver(_chromeOptions());
                    break;
            }
        }
        
        #region Browser options
        private ChromeOptions _chromeOptions()
        {
            ChromeOptions options = new ChromeOptions();

            options.AddArgument("start-maximized");
            if (_headless[0] != 'Y' && _headless[0] != 'y') return options;
            options.AddArgument("--headless");
            options.AddArgument("--window-size=1920,1080");
            return options;
        }
        private FirefoxOptions _firefoxOptions()
        {
            FirefoxOptions options = new FirefoxOptions();
            if (_headless[0] != 'Y' && _headless[0] != 'y') return options;
            options.AddArgument("--headless");
            return options;
        }
        private InternetExplorerOptions _ieOptions
        {
            get
            {
                var options = new InternetExplorerOptions
                {
                    IntroduceInstabilityByIgnoringProtectedModeSettings = true,
                    IgnoreZoomLevel = true,
                    EnablePersistentHover = false,
                    EnableNativeEvents = false
                };
                return options;
            }
        }

        #endregion

        public static void ScrollToTop()
        {
            ((IJavaScriptExecutor)Driver).ExecuteScript("scroll(0, -250);");
        }
    }
}
