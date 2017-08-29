using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using STAF.Framework.BaseClasses;

namespace STAF.Framework.HelperClasses
{
    class MouseHelper
    {
        internal static void DragAndDrop(By drag, By drop)
        {
            try
            {
                IWebElement source = Driver.WaitForElementToBeClickable(drag);
                IWebElement target = Driver.WaitForElementToBeClickable(drop);
                Actions actions = new Actions(BaseSetup.Instance);

                actions.ClickAndHold(source).MoveToElement(target).Release(target).Build().Perform();

                //if (Verify.IsPresent(By.XPath(drop.ToString().Substring(10) + drag.ToString().Substring(10))))
                //{
                //    //ReportHelper.PassLog("Drag and Drop was successful. <br>" + "Drag Element: " + drag.ToString() + "<br>" + "Drop Element:" + drop.ToString());
                //}
                //else
                //{
                //    //ReportHelper.WarningLog("Drag and Drop Failed. <br>" + "Drag Element: " + drag.ToString() + "<br>" + "Drop Element:" + drop.ToString());
                //}

            }
            catch (NoSuchElementException)
            {
                //ReportHelper.WarningLog("Exception occurred during Drag and Drop. Expected element is not present: <br>" + e.Message);
            }
            //catch (Exception e)
            //{
            //    //ReportHelper.WarningLog("Exception occurred during Drag and Drop: <br>" + e.Message);
            //}
        }
    }
}
