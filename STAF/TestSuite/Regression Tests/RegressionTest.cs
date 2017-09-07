using NUnit.Framework;
using STAF.Framework.BaseClasses;
using STAF.Pages;

namespace STAF.TestSuite.Regression_Tests
{
    [TestFixture]
    class RegressionTest : BaseSetup
    {
        [Test]
        public void RegressionTestCase()
        {
            TestStep("Step 1", "Verify page elements.");
            Temp.VerifyPageElements();
            TestStep("Step 2", "Verify the page header.");
        }
    }
}
