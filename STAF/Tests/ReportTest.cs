using NUnit.Framework;
using STAF.Framework.BaseClasses;

namespace STAF.Tests
{
    [TestFixture]
    class ReportTest : BaseSetup
    {
        [Test]
        public void ReportTest01()
        {
            _test.Info("Step 1: Do something.");
            _test.Info("Step 2: Do something.");
            _test.Info("Step 3: Do something.");

        }
        [Test]
        public void ReportTest02()
        {
            _test.Pass("Test 2");
        }
        [Test]
        public void ReportTest03()
        {
            _test.Pass("Test 3");
        }

    }
}
