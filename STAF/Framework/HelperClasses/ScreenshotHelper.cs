using OpenQA.Selenium;
using STAF.Framework.BaseClasses;
using System;
using System.Configuration;
using System.IO;

namespace STAF.Framework.HelperClasses
{
    class ScreenshotHelper
    {
        internal static string TakeScreenshot()
        {
            var screenshotPath = AppDomain.CurrentDomain.BaseDirectory + ConfigurationManager.AppSettings["ScreenshotPath"];
            Directory.CreateDirectory(screenshotPath);
            string now = DateTime.Now.ToString("MMddyyyhhmm");
            string screenName = now + "Screenshot.png";

            try
            {
                Screenshot ss = ((ITakesScreenshot)BaseSetup.Instance).GetScreenshot();
                ss.SaveAsFile(screenshotPath + screenName, ScreenshotImageFormat.Png);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return screenName;
        }
    }
}
