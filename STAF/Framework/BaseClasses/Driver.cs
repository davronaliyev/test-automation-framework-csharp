using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace STAF.Framework.BaseClasses
{
    class Driver : BaseSetup
    {
        private static IWebElement element;
        private static WebDriverWait wait = new WebDriverWait(Instance, TimeSpan.FromSeconds(20));

        internal static void ClickOn(By locator)
        {
            element = WaitForElementToBeClickable(locator);
            element.Click();
        }
        internal static void InsertText(By locator, string text)
        {
            element = WaitForElementIsVisible(locator);
            element.Clear();
            element.SendKeys(text);
        }
        internal static void SelectFromDropdown(By locator, string option)
        {
            var select = new SelectElement(WaitForElementIsVisible(locator));
            select.SelectByText(option);
        }
        internal static void NavigateToUrl(string url)
        {
            Instance.Navigate().GoToUrl(url);
        }

        // Wait for conditions.
        internal static IWebElement WaitForElementToBeClickable(By locator)
        {
            //     An expectation for checking an element is visible and enabled such that you can click it.
            try
            {
                wait.PollingInterval = TimeSpan.FromSeconds(2);
                wait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(ElementNotVisibleException));
                wait.Until(ExpectedConditions.ElementToBeClickable(locator));
                return Instance.FindElement(locator);
            }
            catch (Exception)
            {
                throw new NoSuchElementException("Unable to find element, locator: \"" + locator.ToString() + "\".");
            }
        }
        internal static IWebElement WaitForElementIsVisible(By locator)
        {
            //     An expectation for checking that an element is present on the DOM of a page and visible. 
            //     Visibility means that the element is not only displayed but also has a height and width that is greater than 0.
            try
            {
                wait.PollingInterval = TimeSpan.FromSeconds(2);
                wait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(ElementNotVisibleException));
                wait.Until(ExpectedConditions.ElementIsVisible(locator));
                return Instance.FindElement(locator);
            }
            catch (Exception)
            {
                throw new NoSuchElementException("Unable to find element, locator: \"" + locator.ToString() + "\".");
            }
        }
    }
}
