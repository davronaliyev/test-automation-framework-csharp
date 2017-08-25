using NUnit.Framework;
using OpenQA.Selenium;

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
                //_test.Info("<span class=\"label white-text green\">Expected</span>" + expectedElement);
                _test.Pass("<span class=\"label white-text green\">Pass</span>&nbsp Expected result &nbsp<b>" + expectedElement + "</b>&nbsp is equal to &nbsp<b>" + element.Text + "</b>&nbsp actual result.");
            }
            catch (AssertionException)
            {
                string actualElement = Instance.FindElement(locator).Text.Trim();
                _test.Fail("<span class=\"label white-text red\">Fail</span> &nbsp Expected: &nbsp<b>" + expectedElement + "</b>&nbsp-&nbsp Actual: &nbsp<b>" + element.Text + "</b>&nbsp.");
            }
        }
    }
}
