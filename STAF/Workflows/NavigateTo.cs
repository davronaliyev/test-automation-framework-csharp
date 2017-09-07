using STAF.Framework.BaseClasses;
using STAF.Pages;

namespace STAF.Workflows
{
    class NavigateTo
    {
        internal static void LoginPage()
        {
            Temp.NavigateToPage();
            Verify.AreEqual("", Temp.pageHeader);
        }
    }
}
