using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BridgerEye.Framework.Base;
using BridgerEye.Framework.PageObjects.SystemAccess;

namespace BridgerEye.Framework.PageObjects.Common
{
    public class NavigateTo: PageBase
    {
        public UsersPage UsersPage()
        {
            Driver.Navigate().GoToUrl(_baseUrl + "/XgApp/SystemAccess/Users");
            return new UsersPage(new NavigateTo());
        }
        public RolesPage RolesPage()
        {
            Driver.Navigate().GoToUrl(_baseUrl + "/XgApp/SystemAccess/Roles");
            return new RolesPage();
        }
    }
}
