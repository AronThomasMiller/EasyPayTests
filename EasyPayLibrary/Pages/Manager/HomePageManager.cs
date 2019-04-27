using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPayLibrary.Pages.Manager
{
    class HomePageManager:HomePage
    {
        ManagerSidebar sidebar;
        public InspectorsListPage NavigateToInspectorsListPage()
        {
            sidebar.ClickOnInspectorsButton();
            return GetPOM<InspectorsListPage>(driver);
        }
    }
}
