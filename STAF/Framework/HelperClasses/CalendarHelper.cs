using OpenQA.Selenium;
using STAF.Framework.BaseClasses;
using System;
using System.Globalization;

namespace STAF.Framework.HelperClasses
{
    class CalendarHelper
    {
        internal static void DatePicker(By _calendarIcon, string _date)
        {
            if (_date != "")
            {
                // Substring the date
                string _mounth = _date.Substring(0, 2);
                string _day = _date.Substring(3, 2);
                string _year = _date.Substring(6, 4);
                // Convert month int to month name
                string _mounthName = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(Convert.ToInt32(_mounth));
                // Click the Calendar
                Driver.ClickOn(_calendarIcon);
                Driver.ClickOn(By.XPath("//ul[contains(@style,'display: block;')]//button[@ng-click='toggleMode()']"));
                // Select the year and month
                Driver.WaitForElementExists(By.XPath("//span[contains(.,'March')]"));
                // Get the year from calendar
                string entryYear = Driver.Instance.FindElement(By.XPath("//ul[contains(@style,'display: block;')]//button[contains (@id,'datepicker')]")).Text.ToString();
                if (_year == entryYear)
                {
                    Driver.ClickOn(By.XPath("//span[contains(.,'" + _mounthName + "')]"));
                }
                else if ((Convert.ToInt32(entryYear)) > (Convert.ToInt32(_year)))
                {
                    Driver.ClickOn(By.XPath("//button[@class='btn btn-default btn-sm pull-left']"));
                    Driver.ClickOn(By.XPath("//span[contains(.,'" + _mounthName + "')]"));
                }
                else
                {
                    Driver.ClickOn(By.XPath("//button[@class='btn btn-default btn-sm pull-right']"));
                    Driver.ClickOn(By.XPath("//span[contains(.,'" + _mounthName + "')]"));
                }
                // Pick the Date
                Driver.ClickOn(By.XPath("//ul[contains(@style,'display: block;')]//span[@class='ng-binding' and contains(.,'" + _day + "')]//parent::button"));
            }
        }
    }
}
