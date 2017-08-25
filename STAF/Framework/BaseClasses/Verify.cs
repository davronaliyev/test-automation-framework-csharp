using AventStack.ExtentReports;
using NUnit.Framework;
using OpenQA.Selenium;
using STAF.Framework.HelperClasses;
using System;
using System.Configuration;

namespace STAF.Framework.BaseClasses
{
    class Verify : BaseSetup
    {
        private static IWebElement element;
        internal static void AreEqual(string expectedElement, By locator)
        {
            try
            {
                element = Driver.WaitForElementIsVisible(locator);
                Assert.AreEqual(expectedElement, Instance.FindElement(locator).Text.Trim());
                _test.Pass("<span class=\"label white-text green\">Pass</span>&nbsp Expected result &nbsp<b>" + expectedElement + "</b>&nbsp is equal to &nbsp<b>" + element.Text + "</b>&nbsp actual result.");
            }
            catch (AssertionException)
            {
                string actualElement = Instance.FindElement(locator).Text.Trim();
                _test.Fail("<span class=\"label white-text red\">Fail</span> &nbsp Expected: &nbsp<b>" + expectedElement + "</b>&nbsp&nbsp-&nbsp&nbsp Actual: &nbsp<b>" + element.Text + "</b>.",
                    MediaEntityBuilder.CreateScreenCaptureFromPath(AppDomain.CurrentDomain.BaseDirectory + ConfigurationManager.AppSettings["ScreenshotPath"] + ScreenshotHelper.TakeScreenshot()).Build());
            }
        }

        internal static void IsPresent(By locator, string label)
        {
            try
            {
                element = Driver.WaitForElementExists(locator);
                _test.Pass("<span class=\"label white-text green\">Pass</span>&nbsp &nbsp<b>" + label + "</b> verified.");
            }
            catch (Exception)
            {
                _test.Fail("<span class=\"label white-text red\">Fail</span>&nbsp&nbsp<b>" + label + "</b> could <u>not</u> be verified.",
                MediaEntityBuilder.CreateScreenCaptureFromPath(AppDomain.CurrentDomain.BaseDirectory + ConfigurationManager.AppSettings["ScreenshotPath"] + ScreenshotHelper.TakeScreenshot()).Build());

            }
        }
    }
}
