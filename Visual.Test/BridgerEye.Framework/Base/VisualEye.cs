using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using AventStack.ExtentReports;
using BridgerEye.Framework.Helpers;
using BridgerEye.Framework.Utilities;
using NUnit.Framework;
using NUnit.Framework.Internal;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace BridgerEye.Framework.Base
{
    public class VisualEye: PageBase
    {
        private static readonly ComparisonOptions _options = new ComparisonOptions();
        internal static By versionNumberLogon = By.Id("logonfooter");
        internal static By versionNumber = By.Id("footer");
        internal static By alertId = By.Id("alertId");

        public void Scan()
        {
            string baseImage = Regex.Replace(TestContext.CurrentContext.Test.Name, @"(\[|""|\])", "");
            string _baseImage = baseImage + "_BaseImage.png";
            string _baseImageDir = AppDomain.CurrentDomain.BaseDirectory + ConfigurationManager.AppSettings["BaseImagesDirectory"];
            string _actualImage = new Randomizer().Next() + ".png";
            _options.ShowCellValues = true;

            IWebElement element = Driver.FindElement(By.XPath("(//title[contains(.,'Lexis')])[1]"));
            var actions = new Actions(Driver);
            actions.MoveToElement(element).Click().Perform();

            // Cover version number

            if (IsElementPresent(alertId))
            {
                // alertId
                SeleniumDriver.CoverVersionBySelector(Driver, "alertId");
                _options.Threshold = 20;
            }
            else if (IsElementPresent(versionNumber))
            {
                // Footer
                SeleniumDriver.CoverVersionBySelector(Driver, "footer");
                _options.Threshold = 20;
            }

            // Compare
            var result = Compare.Differences(_baseImage, Driver);

            if (!result.Match)
            {
                result.DifferenceImage.Save(AppDomain.CurrentDomain.BaseDirectory + ConfigurationManager.AppSettings["ScreenshotPath"] + _actualImage);
                TestLog.Warning(baseImage + " <span class=\"label white-text orange\">&nbsp; Visual Warning &nbsp;</span>",
                    MediaEntityBuilder.CreateScreenCaptureFromPath(AppDomain.CurrentDomain.BaseDirectory + ConfigurationManager.AppSettings["ScreenshotPath"] + _actualImage).Build());
            }
            else
            {
                TestLog.Pass(baseImage + " <span class=\"label white-text green\">&nbsp; Visual Test Pass &nbsp;</span>");
            }

            // Accessibility Scan
            AxeHelper.PageScan(baseImage + " Page");
        }

        public void Scan(string baseImageName)
        {
            string baseImage = Regex.Replace(TestContext.CurrentContext.Test.Name, @"(\[|""|\])", "");
            string _baseImage = baseImage + baseImageName + "_BaseImage.png";



            string _baseImageDir = AppDomain.CurrentDomain.BaseDirectory + ConfigurationManager.AppSettings["BaseImagesDirectory"];
            string _actualImage = new Randomizer().Next() + ".png";
            _options.ShowCellValues = true;

            IWebElement element = Driver.FindElement(By.XPath("(//title[contains(.,'Lexis')])[1]"));
            var actions = new Actions(Driver);
            actions.MoveToElement(element).Click().Perform();

            // Cover version number
            if (IsElementPresent(alertId))
            {
                // alertId
                SeleniumDriver.CoverVersionBySelector(Driver, "alertId");
                _options.Threshold = 20;
            }
            //else if (IsElementPresent(versionNumber))
            //{
            //    // Footer
            //    SeleniumDriver.CoverDynamicElementBySelector(Driver, "footer");
            //    _options.Threshold = 20;
            //}

            // Compare
            var result = Compare.Differences(_baseImage, Driver);

            if (!result.Match)
            {
                result.DifferenceImage.Save(AppDomain.CurrentDomain.BaseDirectory + ConfigurationManager.AppSettings["ScreenshotPath"] + _actualImage);
                TestLog.Warning(_baseImage + " <span class=\"label white-text orange\">&nbsp; Visual Warning &nbsp;</span>",
                    MediaEntityBuilder.CreateScreenCaptureFromPath(AppDomain.CurrentDomain.BaseDirectory + ConfigurationManager.AppSettings["ScreenshotPath"] + _actualImage).Build());
            }
            else
            {
                TestLog.Pass(_baseImage + " <span class=\"label white-text green\">&nbsp; Visual Test Pass &nbsp;</span>");
            }

            // Accessibility Scan
            AxeHelper.PageScan(_baseImage + " Page");
        }

        public void Scan(string baseImage, string elementHide)
        {
            string _baseImage = baseImage + "_BaseImage.png";
            //string _baseImageDir = "TestDataDirectory";
            string _actualImage = new Randomizer().Next() + ".png";
            _options.ShowCellValues = true;

            IWebElement _element = Driver.FindElement(By.XPath("(//title[contains(.,'Lexis')])[1]"));
            var actions = new Actions(Driver);
            actions.MoveToElement(_element).Click().Perform();

            // Check if base image exist
            //if (!File.Exists(AppDomain.CurrentDomain.BaseDirectory + ConfigurationManager.AppSettings[_baseImageDir] + _baseImage))
            //{
            //    SeleniumDriver.CreateBaseImage(_baseImage, Driver);
            //}


            // Cover version number
            if (IsElementPresent(versionNumberLogon))
            {
                // Logon footer
                SeleniumDriver.CoverDynamicElementBySelector(Driver, "logonfooter");
                _options.Threshold = 20;
            }
            else if (IsElementPresent(versionNumber))
            {
                // Footer
                SeleniumDriver.CoverDynamicElementBySelector(Driver, "footer");
                _options.Threshold = 20;
            }
            SeleniumDriver.CoverDynamicElementBySelector(Driver, elementHide);
            _options.Threshold = 20;



            // Compare
            var result = Compare.Differences(_baseImage, Driver, _options);

            if (!result.Match)
            {
                result.DifferenceImage.Save(AppDomain.CurrentDomain.BaseDirectory + ConfigurationManager.AppSettings["ScreenshotPath"] + _actualImage);
                TestLog.Warning("<span class=\"label white-text orange\">" + baseImage + " page || Visual Warning</span>",
                    MediaEntityBuilder.CreateScreenCaptureFromPath(AppDomain.CurrentDomain.BaseDirectory + ConfigurationManager.AppSettings["ScreenshotPath"] + _actualImage).Build());
            }
            else
            {
                TestLog.Pass("<span class=\"label white-text green\"> " + baseImage + " page || Visual Test Pass</span>");
            }

            // Accessibility Scan
            //AxeHelper.PageScan(baseImage + " Page");
        }

        internal void CreatePageBaseImage(string baseImageName)
        {
            SeleniumDriver.CreateBaseImage(baseImageName, Driver);
        }

        private bool IsElementPresent(By locator)
        {
            try
            {
                Driver.FindElement(locator);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
    }
}
