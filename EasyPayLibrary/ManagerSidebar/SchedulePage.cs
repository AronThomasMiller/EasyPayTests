using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPayLibrary
{
    public class SchedulePage : BasePageObject
    {
        WebElementWrapper btnAddSchedule;
        WebElementWrapper tabHistory;
        WebElementWrapper tabStatistics;

        public override void Init(DriverWrapper driver)
        {
            btnAddSchedule = driver.GetByXpath("//button[contains(@class,'fc-addScheduleItem-button')]");
            tabHistory = driver.GetByXpath("//a[@id='profile-tab2']");
            tabStatistics = driver.GetByXpath("//span[contains(text(),'Statistics')]");
            base.Init(driver);
        }

        public AddScheduleItemPage ClickOnAddScheduleButton()
        {
            btnAddSchedule.ClickOnIt();
            return GetPOM<AddScheduleItemPage>(driver);
        }

        public HistoryPage ClickOnTabHistory()
        {
            tabHistory.ClickOnIt();
            return GetPOM<HistoryPage>(driver);
        }

        public StatisticsPage ClickOnTabStatistics()
        {
            tabStatistics.ClickOnIt();
            return GetPOM<StatisticsPage>(driver);
        }
    }
}
