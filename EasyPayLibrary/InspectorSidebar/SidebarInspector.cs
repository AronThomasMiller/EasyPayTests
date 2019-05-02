using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPayLibrary.InspectorSidebar
{
    public class SidebarInspector : SidebarBase
    {
        public WebElementWrapper schedule;
        public WebElementWrapper checkCounters;
        public WebElementWrapper rateClients;

        public override void Init(DriverWrapper driver)
        {
            base.Init(driver);
            schedule = sidebar[0];
            checkCounters = sidebar[1];
            rateClients = sidebar[2];            
        }

        public void ClickOnCheckCounters()
        {
            checkCounters.Click();
        }

        public void ClickOnRateClient()
        {
            rateClients.Click();
        }

        public void ClickOnSchedule()
        {
            schedule.Click();
        }
    }
}
