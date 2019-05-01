using EasyPayLibrary.ManagerSidebar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPayLibrary.Pages.Manager
{
    public class HomePageManager:GeneralPage
    {
        ManagerSidebar sidebar;

        public override void Init(DriverWrapper driver)
        {
            sidebar = GetPOM<ManagerSidebar>(driver);
            base.Init(driver);
        }

        public InspectorsListPage NavigateToInspectorsListPage()
        {
            sidebar.ClickOnInspectorsButton();
            return GetPOM<InspectorsListPage>(driver);
        }

        public UtilityPricePage GetPricesToEdit()
        {
            sidebar.ClickOnUtilityPriceButton();
            return GetPOM<UtilityPricePage>(driver);
        }
    }
}
