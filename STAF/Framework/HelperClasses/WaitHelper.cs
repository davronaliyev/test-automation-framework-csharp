using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using STAF.Framework.BaseClasses;
using System;

namespace STAF.Framework.HelperClasses
{
    class WaitHelper
    {
        // Wait for conditions.
        internal static IWebElement WaitForElementToBeClickable(By locator)
        {
            //     An expectation for checking an element is visible and enabled such that you can click it.
            try
            {
                WebDriverWait wait = new WebDriverWait(BaseSetup.Instance, TimeSpan.FromSeconds(20));
                wait.PollingInterval = TimeSpan.FromSeconds(2);
                wait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(ElementNotVisibleException));
                wait.Until(ExpectedConditions.ElementToBeClickable(locator));
                return BaseSetup.Instance.FindElement(locator);
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
                WebDriverWait wait = new WebDriverWait(BaseSetup.Instance, TimeSpan.FromSeconds(20));
                wait.PollingInterval = TimeSpan.FromSeconds(2);
                wait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(ElementNotVisibleException));
                wait.Until(ExpectedConditions.ElementIsVisible(locator));
                return BaseSetup.Instance.FindElement(locator);
            }
            catch (Exception)
            {
                throw new NoSuchElementException("Unable to find element, locator: \"" + locator.ToString() + "\".");
            }
        }
        internal static IWebElement WaitForElementExists(By locator)
        {
            //  An expectation for checking that an element is present on the DOM of a page. 
            //  This does not necessarily mean that the element is visible.
            try
            {
                WebDriverWait wait = new WebDriverWait(BaseSetup.Instance, TimeSpan.FromSeconds(20));
                wait.PollingInterval = TimeSpan.FromSeconds(2);
                wait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(ElementNotVisibleException));
                wait.Until(ExpectedConditions.ElementExists(locator));
                return BaseSetup.Instance.FindElement(locator);
            }
            catch (Exception)
            {
                throw new NoSuchElementException("Unable to find element, locator: \"" + locator.ToString() + "\".");
            }
        }
    }
}
