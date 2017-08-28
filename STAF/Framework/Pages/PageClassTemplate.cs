using OpenQA.Selenium;
using STAF.Framework.BaseClasses;

namespace STAF.Framework.Pages
{
    class PageClassTemplate
    {
        #region Elements
        // Page Elements
        static internal By pageHeader = By.XPath("//h11");
        static internal By pageHeaderB = By.XPath("//h1");
        static internal By registerButton = By.XPath("//butto[@ng-click='openRegistrationModal()']");
        static internal By registerButton2 = By.XPath("//button[@ng-click='openRegistrationModal()']");
        static internal By loginButton = By.XPath("//button[@ng-click='debugLogin()']");
        static internal By loginButtonX = By.XPath("//button[@ng-click='debugLoginn()']");

        #endregion

        #region Actions

        internal static void VerifyPageElements()
        {
            Verify.AreEqual("Fee Basis Claims Systemm", pageHeaderB);
            Verify.AreEqual("Fee Basis Claims System", pageHeader);
            Verify.IsPresent(registerButton2, "Register button");
            Verify.IsPresent(registerButton, "Register butto");
            Verify.IsButtonActive(loginButton);
            Verify.IsButtonActive(loginButtonX);
        }

        #endregion

        #region Navigations

        internal static void NavigateToPage()
        {

        }

        #endregion
    }
}
