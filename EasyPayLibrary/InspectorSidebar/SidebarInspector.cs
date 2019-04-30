using EasyPayLibrary.Pages.Inspector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPayLibrary.Pages
{
   public class SidebarInspector : BaseSidebar
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
            checkCounters.ClickOnIt();
        }
        public void ClickOnRateClient()
        {
            rateClients.ClickOnIt();
        }

        public void ClickOnSchedule()
        {
            schedule.ClickOnIt();
        }
       
    }
}
