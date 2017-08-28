using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using STAF.Framework.BaseClasses;

namespace STAF.Framework.HelperClasses
{
    class KeysHelper
    {
        private static IWebElement element;
        internal static void PressEnter(By locator)
        {
            element = Driver.WaitForElementExists(locator);
            element.SendKeys(Keys.Enter);

        }
        internal static void PressTab(By locator)
        {
            element = Driver.WaitForElementExists(locator);
            element.SendKeys(Keys.Tab);

        }
        internal static void HoldCtrl(By locator, string key)
        {
            element = Driver.WaitForElementExists(locator);
            element.SendKeys(Keys.Control + key);

        }
        // presses control button + key
        internal static void CtrlShortcut(string key)
        {
            Actions action = new Actions(BaseSetup.Instance);
            action.KeyDown(Keys.Control).SendKeys(key).KeyUp(Keys.Control).Perform();

        }
    }
}
