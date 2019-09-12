using AventStack.ExtentReports.Utils;
using BridgerEye.Framework.Base;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Net;

namespace BridgerEye.Framework.PageObjects.Common
{
    public class LoginPage : PageBase

    {

        #region Page Elements

        // Inputs 
        public readonly By input_ClientID = By.Id("ClientId");
        public readonly By input_UserID = By.Id("UserName");
        public readonly By input_Password = By.Id("Password");
        public readonly By input_Email = By.Id("Email");
        public readonly By input_VerificationCode = By.Id("VerificationCode");
        public readonly By input_SecurityCheckCode = By.Id("SecurityCheckCode");

        // Buttons
        public readonly By button_Next = By.Id("Next");
        public readonly By button_PassNext = By.XPath("//button[contains(text(),'Next')]");
        public readonly By button_Cancel = By.XPath("//input[@value='Cancel']");
        public readonly By button_Signout = By.Id("signout");

        // Labels
        public readonly By label_SignIn = By.XPath("//h2");
        public readonly By label_AlertMessage = By.Id("messText");

        // Links
        public readonly By link_PasswordReset = By.ClassName("passwordreset");
        public readonly By link_ChangeClientAndUser = By.Id("ChangeClientUser");
        public readonly By link_ContactUs = By.LinkText("Contact Us");
        public readonly By link_RiskHome = By.XPath("(//a[@href='http://www.lexisnexis.com/risk/'])[2]");
        public readonly By link_OurSolutions = By.LinkText("Our Solutions");

        // Dropdown
        public readonly By dropdown_Language = By.Id("langSel");
        public readonly By dropdown_LanguageLogon = By.Id("langSelLink");
        public readonly By dropdownOption_English = By.XPath("//ul[@id='langlist']/li[1]");
        public readonly By dropdownOption_Espanol = By.XPath("//ul[@id='langlist']/li[2]");
        public readonly By dropdownOption_Portugues = By.XPath("//ul[@id='langlist']/li[3]");
        public readonly By dropdownOption_Deutsch = By.XPath("//ul[@id='langlist']/li[4]");
        public readonly By dropdownOption_Francais = By.XPath("//ul[@id='langlist']/li[5]");
        public readonly By dropdownOption_Chinese = By.XPath("//ul[@id='langlist']/li[6]");
        public readonly By dropdownOption_Japanese = By.XPath("//ul[@id='langlist']/li[7]");

        #endregion

        public LoginPage ChangeLanguage(string language)
        {
            if (dropdown_Language.IsElementPresent())
            {
                dropdown_Language.Click();
                switch (language)
                {
                    case "English":
                        dropdownOption_English.Click();
                        Assert.That(language, Is.EqualTo(Driver.FindElement(dropdown_Language).Text.Trim()));
                        break;
                    case "Spanish":
                        dropdownOption_Espanol.Click();
                        Assert.That("Español", Is.EqualTo(Driver.FindElement(dropdown_Language).Text.Trim()));
                        break;
                    case "Portugues":
                        dropdownOption_Portugues.Click();
                        Assert.That("Português", Is.EqualTo(Driver.FindElement(dropdown_Language).Text.Trim()));
                        break;
                    case "Deutsch":
                        dropdownOption_Deutsch.Click();
                        Assert.That("Deutsch", Is.EqualTo(Driver.FindElement(dropdown_Language).Text.Trim()));
                        break;
                    case "French":
                        dropdownOption_Francais.Click();
                        Assert.That("Français", Is.EqualTo(Driver.FindElement(dropdown_Language).Text.Trim()));
                        break;
                    case "Chinese":
                        dropdownOption_Chinese.Click();
                        Assert.That("中文", Is.EqualTo(Driver.FindElement(dropdown_Language).Text.Trim()));
                        break;
                    case "Japanese":
                        dropdownOption_Japanese.Click();
                        Assert.That("日本語", Is.EqualTo(Driver.FindElement(dropdown_Language).Text.Trim()));
                        break;
                }
            }
            else if (dropdown_LanguageLogon.IsElementPresent())
            {
                dropdown_LanguageLogon.Click();
                switch (language)
                {
                    case "English":
                        dropdownOption_English.Click();
                        Assert.That(language, Is.EqualTo(Driver.FindElement(dropdown_LanguageLogon).Text.Trim()));
                        break;
                    case "Spanish":
                        dropdownOption_Espanol.Click();
                        Assert.That("Español", Is.EqualTo(Driver.FindElement(dropdown_LanguageLogon).Text.Trim()));
                        break;
                    case "Portugues":
                        dropdownOption_Portugues.Click();
                        Assert.That("Português", Is.EqualTo(Driver.FindElement(dropdown_LanguageLogon).Text.Trim()));
                        break;
                    case "Deutsch":
                        dropdownOption_Deutsch.Click();
                        Assert.That("Deutsch", Is.EqualTo(Driver.FindElement(dropdown_LanguageLogon).Text.Trim()));
                        break;
                    case "French":
                        dropdownOption_Francais.Click();
                        Assert.That("Français", Is.EqualTo(Driver.FindElement(dropdown_LanguageLogon).Text.Trim()));
                        break;
                    case "Chinese":
                        dropdownOption_Chinese.Click();
                        Assert.That("中文", Is.EqualTo(Driver.FindElement(dropdown_LanguageLogon).Text.Trim()));
                        break;
                    case "Japanese":
                        dropdownOption_Japanese.Click();
                        Assert.That("日本語", Is.EqualTo(Driver.FindElement(dropdown_LanguageLogon).Text.Trim()));
                        break;
                }
            }
            return this;
        }

        public HomePage Signin()
        {
            if (!button_Signout.IsElementPresent())
            {
                if (!Driver.Url.Equals(_baseUrl + "/XGAuth/"))
                {
                    Driver.Navigate().GoToUrl(_baseUrl + "/XGAuth/");
                }
                input_ClientID.Insert(_clientId);
                input_UserID.Insert(_userId);
                button_Next.Click();
                input_Password.Insert(_password);
                button_Next.Click();
                if (input_VerificationCode.IsElementPresent())
                {
                    input_VerificationCode.Insert(_verificationCode);
                    button_Next.Click();
                }
                TestLog.Pass("Successfully logged in.");
            }
            return new HomePage(new NavigateTo(), new Menubar());
        }
        public void Signout()
        {
            if (!button_Signout.IsElementPresent()) return;
            button_Signout.Click();
            TestLog.Pass("Successfully signed out.");
        }

        public void LinkChecker(int expectedLinks)
        {
            IList<IWebElement> results = Driver.FindElements(By.TagName("a"));
            TestLog.Pass("<b>" + results.Count + "</b> links found");
            foreach (IWebElement result in results)
            {
                var url = result.GetAttribute("href");
                var linkText = result.Text;

                try
                {
                    if (url.IsNullOrEmpty() || url != "mailto:customereducation@lexisnexis.com")
                    {
                        TestLog.Pass("Connecting to: " + url);
                        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

                        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                        response.Close();
                        TestLog.Pass("Status Code: <b>" + response.StatusCode);
                    }
                }
                catch (Exception e)
                {
                    TestLog.Fail("Cannot connect to: " + url + e);
                    throw;
                }
                if (!linkText.IsNullOrEmpty())
                {
                    TestLog.Pass("<b>" + linkText + "</b> - Link Verified");
                }
            }
            Assert.AreEqual(expectedLinks, results.Count);
            TestLog.Pass("All <b>" + results.Count + "</b> links are verified");

            // -- Use this for to get html response code
            //if (totalLinks == results.Count)
            //{
            //    Console.WriteLine("Total " + results.Count + " links verified");
            //}

            //if (response.StatusCode == HttpStatusCode.OK)
            //{
            //    Stream receiveStream = response.GetResponseStream();
            //    StreamReader readStream = null;

            //    if (response.CharacterSet == null)
            //    {
            //        readStream = new StreamReader(receiveStream);
            //    }
            //    else
            //    {
            //        readStream = new StreamReader(receiveStream, Encoding.GetEncoding(response.CharacterSet));
            //    }

            //    string data = readStream.ReadToEnd();

            //    response.Close();
            //    readStream.Close();
            //}
        }
    }
}
