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
            schedule = driver.GetByXpath("//a[@href='/inspector/schedule/']");
            checkCounters = driver.GetByXpath("//a[@href='/inspector/addresses/counters/']");
            rateClients = driver.GetByXpath("//a[@href='/inspector/rate/']");
            base.Init(driver);
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

        public SchedulePage GotoSchedule()
        {
            schedule.Click();
            return GetPOM<SchedulePage>(driver);
        }

    }
}
