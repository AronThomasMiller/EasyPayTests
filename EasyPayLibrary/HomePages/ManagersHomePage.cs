using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPayLibrary
{
    public class ManagersHomePage : GeneralPage
    {

        protected ManagerSidebar managerSidebar;

        public override void Init(DriverWrapper driver)
        {
            managerSidebar = GetPOM<ManagerSidebar>(driver);
            base.Init(driver);
        }

        public InspectorsListPage GetInspectorsList()
        {
            managerSidebar.ClickOnInspectorsButton();
            return GetPOM<InspectorsListPage>(driver);
        }

        public UtilityPricePage GetPricesToEdit()
        {
            managerSidebar.ClickOnUtilityPriceButton();
            return GetPOM<UtilityPricePage>(driver);
        }

    }
}
