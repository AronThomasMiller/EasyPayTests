using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPayLibrary.Inspector
{
   public class SideBarInspector:BaseSidebar
    {
        protected WebElementWrapper schedule;
        public override void Init(DriverWrapper driver)
        {
            schedule = driver.GetByXpath("//a[@href='/inspector/schedule/']");
            base.Init(driver);
        }
        public ScheduleForm GotoSchedule()
        {
            schedule.Click();
            return GetPOM<ScheduleForm>(driver);
        }
    }
}
