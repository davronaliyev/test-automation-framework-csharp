using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BridgerEye.Framework.PageObjects.Common;

namespace BridgerEye.Framework.PageObjects.SystemAccess
{
    public class UsersPage
    {
        private readonly NavigateTo _navigateTo;

        public UsersPage(NavigateTo navigateTo)
        {
            _navigateTo = navigateTo;
        }

        public NavigateTo NavigateTo()
        {
            return _navigateTo;
        }
    }
}
