using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPayLibrary.Inspector
{
    public class SchedulePage: GeneralPage
    {
        public ScheduleForm schedule;
        public override void Init(DriverWrapper driver)
        {
            schedule = GetPOM<ScheduleForm>(driver);
            base.Init(driver);
        }
    }
}
