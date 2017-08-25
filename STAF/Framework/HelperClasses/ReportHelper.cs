using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using System;
using System.Configuration;

namespace STAF.Framework.HelperClasses
{
    public class ReportHelper
    {
        [SetUpFixture]
        public abstract class Base
        {
            protected ExtentReports _extent;
            protected ExtentTest _test;

            [OneTimeSetUp]
            protected void Setup()
            {
                // Setup up report directory from App.config file.
                var dir = AppDomain.CurrentDomain.BaseDirectory + ConfigurationManager.AppSettings["ReportPath"];
                var fileName = this.GetType().ToString() + ".html";
                var htmlReporter = new ExtentHtmlReporter(dir + fileName);

                _extent = new ExtentReports();
                _extent.AttachReporter(htmlReporter);




                //htmlReporter.LoadConfig(AppDomain.CurrentDomain.BaseDirectory + @"..\..\packages\ExtentReports.3.0.2\lib\extent-config.xml");

                // Report Configurations
                // make the charts visible on report open
                htmlReporter.Configuration().ChartVisibilityOnOpen = false;
                htmlReporter.Configuration().ChartLocation = ChartLocation.Top;
                // report title
                htmlReporter.Configuration().DocumentTitle = ConfigurationManager.AppSettings["ReportTitle"];
                // report or build name
                htmlReporter.Configuration().ReportName = ConfigurationManager.AppSettings["ReportTitle"] + " &nbsp|&nbsp Build - " + ConfigurationManager.AppSettings["ProductVersion"];
                // add custom css
                htmlReporter.Configuration().CSS = @"td{font-size: 16px} .test-steps th:nth-child(2), tr.log > td:nth-child(2), .node-steps th:nth-child(2), .node-steps td:nth-child(2) { display: none; }";
                // add custom javascript
                //htmlReporter.Configuration().JS = "var lastColHeader = Array.prototype.slice.call(document.querySelectorAll('th:Timestamp', '#btt-ranges'), 0);var lastColCells = Array.prototype.slice.call(document.querySelectorAll('td:last-child', '#btt-ranges'), 0).concat(lastColHeader);lastColCells.forEach(function(cell) {cell.style.display = 'none';});";



            }
            [OneTimeTearDown]
            protected void TearDown()
            {
                _extent.Flush();
            }
            [SetUp]
            public void BeforeTest()
            {
                _test = _extent.CreateTest(TestContext.CurrentContext.Test.Name);
            }
            [TearDown]
            public void AfterTest()
            {
                var status = TestContext.CurrentContext.Result.Outcome.Status;
                var stacktrace = string.IsNullOrEmpty(TestContext.CurrentContext.Result.StackTrace)
                        ? ""
                        : string.Format("{0}", TestContext.CurrentContext.Result.StackTrace);
                Status logstatus;

                switch (status)
                {
                    case TestStatus.Failed:
                        logstatus = Status.Fail;
                        break;
                    case TestStatus.Inconclusive:
                        logstatus = Status.Warning;
                        break;
                    case TestStatus.Skipped:
                        logstatus = Status.Skip;
                        break;
                    default:
                        logstatus = Status.Pass;
                        break;
                }

                _test.Log(logstatus, "Test ended with " + logstatus + stacktrace);
            }
            public void TestStep(string status, string stepName, string description)
            {
                switch (status)
                {
                    case "Info":
                        _test.Info("<span class=\"label white-text blue\">" + stepName + "</span>" + description);
                        break;
                    case "Warning":
                        _test.Warning("<span class=\"label white-text blue\">" + stepName + "</span>" + description);
                        break;
                    case "Fail":
                        _test.Fail("<span class=\"label white-text blue\">" + stepName + "</span>" + description);
                        break;
                    case "Skip":
                        _test.Skip("<span class=\"label white-text blue\">" + stepName + "</span>" + description);
                        break;
                    default:
                        _test.Info("<span class=\"label white-text blue\">" + stepName + "</span>" + description);
                        break;
                }
            }
            public void TestStep(string stepName, string description)
            {
                _test.Info("<span class=\"label white-text blue\">" + stepName + "</span> &nbsp" + description);
            }
        }
    }
}
