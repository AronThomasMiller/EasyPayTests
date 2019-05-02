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
        private WebElementWrapper textInfo;
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

        public string GetInformation()
        {
            textInfo = driver.GetByXpath("//td[contains(@class,'fc-day fc-widget-content fc-wed fc-today')]");
            return textInfo.GetText();
        }



    }
}
