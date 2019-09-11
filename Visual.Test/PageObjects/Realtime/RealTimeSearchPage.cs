using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BridgerEye.Framework.Base;
using BridgerEye.Framework.PageObjects.Common;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace BridgerEye.Framework.PageObjects.Realtime
{
    public class RealTimeSearchPage : PageBase
    {
        public readonly By input_FirstName = By.Id("ind-name-f-name");
        public readonly By input_LastName = By.Id("ind-name-l-name");
        public readonly By button_Search = By.Id("toolbarSubmit");
        public readonly By button_HideAllMatches = By.Id("showHideMatches");
        public readonly By searchResult = By.Id("ind-name-f-name");
        public readonly By alertId = By.Id("alertId");

        public RealTimeSearchPage ListScreening(string firstName, string lastName)
        {
            input_FirstName.Insert(firstName);
            input_LastName.Insert(lastName);
            button_Search.Click();
            //Driver.Insert(input_FirstName, firstName);
            //Driver.Insert(input_LastName, lastName);
            //Driver.Click(button_Search);
            var title = "Alerts View | LexisNexis® Bridger Insight® XG";
            (new WebDriverWait(Driver, TimeSpan.FromSeconds(10))).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(alertId));
            //Assert.AreEqual(title, Driver.Title);
            return this;
        }

        public RealTimeSearchPage HideAllMatches()
        {
            ScrollToTop();
            button_HideAllMatches.Click();
            return this;
        }
    }
}
