using NUnit.Framework;
using STAF.Framework.BaseClasses;
using STAF.Framework.Pages;

namespace STAF.Tests
{
    [TestFixture]
    class TestCaseTemplate : BaseSetup
    {
        [Test]
        public void TestCase_01()
        {
            // Step 1:
            Verify.AreEqual("Test", PageClassTemplate.pageHeader);
            // Step 2:

            // Step 3:
        }
        [Test]
        public void TestCase_02()
        {
            // Step 1:

            // Step 2:

            // Step 3:
        }
        [Test]
        public void TestCase_03()
        {
            // Step 1:

            // Step 2:

            // Step 3:
        }
    }
}
