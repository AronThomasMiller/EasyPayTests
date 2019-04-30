using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPayLibrary.Inspector
{
   public class HomePageInspector: GeneralPage
    {
        private SideBarInspector sideBar;
        public override void Init(DriverWrapper driver)
        {
            sideBar = GetPOM<SideBarInspector>(driver);
            base.Init(driver);
        }
        public ScheduleForm OpenSchedule()
        {
            sideBar.GotoSchedule();
            return GetPOM<ScheduleForm>(driver);
        }

    }
}
