using AventStack.ExtentReports.MarkupUtils;
using BridgerEye.Framework.Base;
using Globant.Selenium.Axe;
using System.Configuration;

namespace BridgerEye.Framework.Helpers
{
    class AxeHelper : PageBase
    {
        static readonly AxeResult results = Driver.Analyze();


        public static void PageScan(string pageName)
        {
            var scan = ConfigurationManager.AppSettings["DOMScan"];
            if (scan == "y" || scan == "Y")
            {
                TestLog.Warning("<span class=\"label white-text red\"> " + pageName + " || Accessibility Violations</span>");
                foreach (var t in results.Violations)
                {
                    var totalOuter = results.Violations.Length;
                    var totalInner = t.Nodes.Length;
                    var totalViolations = totalOuter + totalInner;
                    var violation = MarkupHelper.CreateCodeBlock(t.Description).GetMarkup();

                    TestLog.Warning("<span class=\"label white-text orange\">Violation</span>" +
                                            "<br><b>Impact: &nbsp;</b>" + t.Impact +
                                            "<br><b>Violations found: &nbsp;</b>" + t.Nodes.Length +
                                            "<br><b>" + violation + "</b>");
                }

                // Violation Details

                //foreach (var t in results.Violations)
                //{

                //    var firstList = new string[3][] {
                //        new [] { "<span class=\"label white-text blue\">Violation Details</span>", "<b>Issue description</b>"},
                //        new [] { MarkupHelper.CreateCodeBlock(t.Help).GetMarkup(), MarkupHelper.CreateCodeBlock(t.Description).GetMarkup()},
                //        new [] { "<b>Element location</b>", "<b>Element source</b>" }
                //    };

                //    BaseSetup._test.Info(MarkupHelper.CreateTable(firstList).GetMarkup()
                //    );

                //    foreach (var t1 in t.Nodes)
                //    {
                //        var secondList = new string[1][] {
                //            new [] { MarkupHelper.CreateCodeBlock(t1.Target[0]).GetMarkup(), MarkupHelper.CreateCodeBlock(t1.Html).GetMarkup()}
                //        };
                //        BaseSetup._test.Info(MarkupHelper.CreateTable(secondList).GetMarkup());
                //    }
                //}

            }
            else
            {
               // TestLog.Info("<span class=\"label white-text blue\">" + pageName + " || DOM validation not performed</span>");
            }

        }
    }
}
