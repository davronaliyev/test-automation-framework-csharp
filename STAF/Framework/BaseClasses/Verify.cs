using NUnit.Framework;
using OpenQA.Selenium;

namespace STAF.Framework.BaseClasses
{
    class Verify : BaseSetup
    {

        internal static void AreEqual(string expectedElement, By locator)
        {
            try
            {
                Driver.WaitForElementIsVisible(locator);
                Assert.AreEqual(expectedElement, Instance.FindElement(locator).Text.Trim());
            }
            catch (AssertionException)
            {
                throw;
            }
        }
    }
}
