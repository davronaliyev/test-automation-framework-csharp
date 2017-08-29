using NUnit.Framework;
using STAF.Framework.BaseClasses;
using STAF.Framework.HelperClasses;
using STAF.Framework.Pages;

namespace STAF.Tests
{
    [TestFixture]
    class ReportTest : BaseSetup
    {
        [Test]
        public void TestCase_01()
        {
            TestStep("Step 1", "Verify page elements.");
            PageClassTemplate.VerifyPageElements();
            TestStep("Step 2", "Verify the page header.");
        }
        [Test]
        public void TestCase_02()
        {
            TestStep("Step 1", "Verify page elements.");
            TestStep("Step 2", "Verify the page header.");
        }
        [Test]
        public void DataDrivenTest()
        {
            // Step 1
            TestStep(ExcelReader.ReadFrom(1, 1, 2), ExcelReader.ReadFrom(1, 2, 2));
            // Step 2!
            TestStep(ExcelReader.ReadFrom(1, 1, 3), ExcelReader.ReadFrom(1, 2, 3));
            // Step 3
            TestStep(ExcelReader.ReadFrom(1, 1, 4), ExcelReader.ReadFrom(1, 2, 4));
            // Step 4
            TestStep(ExcelReader.ReadFrom(1, 1, 5), ExcelReader.ReadFrom(1, 2, 5));
            // Step 5
            TestStep(ExcelReader.ReadFrom(1, 1, 6), ExcelReader.ReadFrom(1, 2, 6));
            // Step 6
            TestStep(ExcelReader.ReadFrom(1, 1, 7), ExcelReader.ReadFrom(1, 2, 7));
        }
    }
}
