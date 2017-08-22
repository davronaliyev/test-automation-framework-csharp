﻿using OpenQA.Selenium;
using STAF.Framework.BaseClasses;
using System;

namespace STAF.Framework.HelperClasses
{
    class ScreenshotHelper
    {
        internal static string TakeScreenshot()
        {



            string screenshotPath = @"C:\Users\daliyev\OneDrive - DSS\Projects\Git\STA-framework-with-csharp\Reports\screenshots\";
            string now = DateTime.Now.ToString("MMddyyyhhmm");
            string screenName = now + "Screenshot.png";
            //string screenName = "Screenshot.png";
            try
            {
                Screenshot ss = ((ITakesScreenshot)BaseSetup.Instance).GetScreenshot();

                ss.SaveAsFile(screenshotPath + screenName, ScreenshotImageFormat.Png);
                //ss.SaveAsFile(screenshotPath + screenName, ScreenshotImageFormat.Png);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return screenName;
        }
    }
}
