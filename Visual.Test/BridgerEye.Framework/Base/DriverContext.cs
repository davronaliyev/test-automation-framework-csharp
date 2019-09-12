using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using OpenQA.Selenium.Support.Extensions;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace BridgerEye.Framework.Base
{
    public static class DriverContext
    {
        public static void Click(this By locator)
        {
            PageBase.Element = _waitUntilElementToBeClickable(locator);
            PageBase.Element.Click();
        }

        public static void Insert(this By locator, string text)
        {
            PageBase.Element = _waitUntilElementIsVisible(locator);
            PageBase.Element.Clear();
            PageBase.Element.SendKeys(text);
        }

        public static bool IsElementPresent(this By locator)
        {
            try
            {
                PageBase.Driver.FindElement(locator);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        private static IWebElement _waitUntilElementToBeClickable(By locator)
        {
            var wait = new WebDriverWait(PageBase.Driver, TimeSpan.FromSeconds(10))
            {
                PollingInterval = TimeSpan.FromSeconds(2)
            };
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(ElementNotVisibleException));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(locator));
            return PageBase.Driver.FindElement(locator);
        }

        private static IWebElement _waitUntilElementIsVisible(By locator)
        {
            try
            {
                var wait = new WebDriverWait(PageBase.Driver, TimeSpan.FromSeconds(10))
                {
                    PollingInterval = TimeSpan.FromSeconds(2)
                };
                wait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(ElementNotVisibleException));
                wait.Until(ExpectedConditions.ElementIsVisible(locator));
                return PageBase.Driver.FindElement(locator);
            }
            catch (Exception)
            {

                throw new NoSuchElementException("Element is not visible <b>" + locator.ToString());
            }
        }
    }
}
