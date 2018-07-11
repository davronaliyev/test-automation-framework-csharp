using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.TestCases.PageObjectModel
{
    class PageTemplate
    {
        #region Elements
        // Page Elements
        //static internal By pageHeader = By.XPath("//h11");
        //static internal By pageHeaderB = By.XPath("//h1");
        //static internal By registerButton = By.XPath("//butto[@ng-click='openRegistrationModal()']");
        //static internal By registerButton2 = By.XPath("//button[@ng-click='openRegistrationModal()']");
        //static internal By loginButton = By.XPath("//button[@ng-click='debugLogin()']");
        //static internal By loginButtonX = By.XPath("//button[@ng-click='debugLoginn()']");

        #endregion

        #region Actions

        internal static void VerifyPageElements()
        {
            //Verify.AreEqual("Fee Basis Claims Systemm", pageHeaderB);
            //Verify.AreEqual("Fee Basis Claims System", pageHeader);
            //Verify.IsPresent(registerButton2, "Register button");
            //Verify.IsPresent(registerButton, "Register butto");
            //Verify.IsButtonActive(loginButton);
            //Verify.IsButtonActive(loginButtonX);
        }

        #endregion

        #region Navigations

        internal static void NavigateToPage()
        {

        }

        #endregion
    }
}
