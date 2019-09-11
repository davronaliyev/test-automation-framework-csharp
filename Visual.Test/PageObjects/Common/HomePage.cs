using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgerEye.Framework.PageObjects.Common
{
    public class HomePage
    {
        private readonly NavigateTo _navigateTo;
        private readonly Menubar _menubar;

        public HomePage(NavigateTo navigateTo, Menubar menubar)
        {
            _navigateTo = navigateTo;
            _menubar = menubar;
        }

        public NavigateTo NavigateTo()
        {
            return _navigateTo;
        }
        public Menubar Menubar()
        {
            return _menubar;
        }
    }
}
