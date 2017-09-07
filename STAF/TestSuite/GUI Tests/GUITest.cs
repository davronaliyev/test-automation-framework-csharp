using NUnit.Framework;
using STAF.Framework.BaseClasses;

namespace STAF.TestSuite.GUI_Tests
{
    [TestFixture]
    class GUITest : BaseSetup
    {
        [Test]
        public void GUITestCase()
        {
            TestStep("Step 1", "Verify page elements.");
            TestStep("Step 2", "Verify the page header.");
        }
    }
}
