using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPayLibrary.Pages.Manager
{
    class ManagerSidebar : SidebarBase
    {
        public void ClickOnInspectors()
        {
            sidebar[0].Click();
        }

        public void ClickOnUtilityPrice()
        {
            sidebar[1].Click();
        }
    }
}
