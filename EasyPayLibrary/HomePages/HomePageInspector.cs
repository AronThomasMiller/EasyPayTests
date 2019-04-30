using EasyPayLibrary.InspectorSidebar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPayLibrary.HomePages
{
    public class HomePageInspector : GeneralPage
    {
        public SidebarInspector sidebar;

        public override void Init(DriverWrapper driver)
        {
            sidebar = GetPOM<SidebarInspector>(driver);
            base.Init(driver);
        }

        public CheckCountersPage EnterOnCheckCounters()
        {
            sidebar.ClickOnCheckCounters();
            return GetPOM<CheckCountersPage>(driver);
        }

        public RateClientsPage EnterOnRateClient()
        {
            sidebar.ClickOnRateClient();
            return GetPOM<RateClientsPage>(driver);
        }

        public SchedulePage EnterOnSchedule()
        {
            sidebar.ClickOnSchedule();
            return GetPOM<SchedulePage>(driver);
        }
    }
}
