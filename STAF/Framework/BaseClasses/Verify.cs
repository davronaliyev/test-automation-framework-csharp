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
                _test.Fail("<span class=\"label white-text red\">Fail</span> &nbsp Expected: &nbsp<b>" + expectedElement + "</b>&nbsp but actual is: &nbsp&nbsp<b>" + element.Text + "</b>",
                MediaEntityBuilder.CreateScreenCaptureFromPath(AppDomain.CurrentDomain.BaseDirectory + ConfigurationManager.AppSettings["ScreenshotPath"] + ScreenshotHelper.TakeScreenshot()).Build());
            }
            catch (NoSuchElementException)
            {
                _test.Fail("<span class=\"label white-text red\">Fail</span>&nbsp Unable to locate <b>" + element.Text + "</b>&nbsp an element.",
                MediaEntityBuilder.CreateScreenCaptureFromPath(AppDomain.CurrentDomain.BaseDirectory + ConfigurationManager.AppSettings["ScreenshotPath"] + ScreenshotHelper.TakeScreenshot()).Build());

            }
        }

        internal static void IsPresent(By locator, string label)
        {
            try
            {
                element = Driver.WaitForElementExists(locator);
                _test.Pass("<span class=\"label white-text green\">Pass</span>&nbsp &nbsp<b>" + label + "</b>&nbsp verified.");
            }
            catch (AssertionException)
            {
                _test.Fail("<span class=\"label white-text red\">Fail</span>&nbsp&nbsp<b>" + label + "</b>&nbsp could <u>not</u> be verified.", MediaEntityBuilder.CreateScreenCaptureFromPath(AppDomain.CurrentDomain.BaseDirectory + ConfigurationManager.AppSettings["ScreenshotPath"] + ScreenshotHelper.TakeScreenshot()).Build());
            }
            catch (NoSuchElementException)
            {
                _test.Fail("<span class=\"label white-text red\">Fail</span>&nbsp Unable to locate <b>" + label + "</b>&nbsp an element.",
                MediaEntityBuilder.CreateScreenCaptureFromPath(AppDomain.CurrentDomain.BaseDirectory + ConfigurationManager.AppSettings["ScreenshotPath"] + ScreenshotHelper.TakeScreenshot()).Build());
            }
        }

        internal static void IsButtonActive(By locator)
        {
            try
            {
                element = Driver.WaitForElementToBeClickable(locator);
                _test.Pass("<span class=\"label white-text green\">Pass</span>&nbsp &nbsp<b>" + element.Text + "</b> &nbsp button is active.");
            }
            catch (AssertionException)
            {
                _test.Fail("<span class=\"label white-text red\">Fail</span>&nbsp&nbsp<b>" + element.Text + "</b> button is <u>not</u> active.", MediaEntityBuilder.CreateScreenCaptureFromPath(AppDomain.CurrentDomain.BaseDirectory + ConfigurationManager.AppSettings["ScreenshotPath"] + ScreenshotHelper.TakeScreenshot()).Build());
            }
            catch (NoSuchElementException)
            {
                _test.Fail("<span class=\"label white-text red\">Fail</span>&nbsp&nbsp Unable to locate <b>" + element.Text + "</b> button.", MediaEntityBuilder.CreateScreenCaptureFromPath(AppDomain.CurrentDomain.BaseDirectory + ConfigurationManager.AppSettings["ScreenshotPath"] + ScreenshotHelper.TakeScreenshot()).Build());
            }
        }
    }
}
