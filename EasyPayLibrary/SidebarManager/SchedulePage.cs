using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPayLibrary.ManagerSidebar
{
    public class SchedulePage : BasePageObject
    {
        WebElementWrapper btnAddScheduleItem;
        WebElementWrapper btnEditScheduleItem;
        WebElementWrapper btnDeleteScheduleItem;

        WebElementWrapper tabHistory;
        WebElementWrapper tabStatistics;

        public override void Init(DriverWrapper driver)
        {
            btnAddScheduleItem = driver.GetByXpath("//button[@class='fc-addScheduleItem-button fc-button fc-state-default fc-corner-left fc-corner-right']");
            tabHistory = driver.GetByXpath("//a[@id='profile-tab2']");
            tabStatistics = driver.GetByXpath("//span[contains(text(),'Statistics')]");
            base.Init(driver);
        }
        //you can use property for one-line method
        public WebElementWrapper GetAddScheduleItem()
        {
            return btnAddScheduleItem;
        }

        public WebElementWrapper GetTask()
        {
            //it will return some task, not some specific
            //it doesn't has logic if you checking is there some task
            //it doesn't mean that it appeared by your manipulation
            return driver.GetByXpath("//span[@class='fc-title']");
        }

        public void ClickOnAddScheduleButton()
        {
            btnAddScheduleItem.Click();
        }

        public void ClickOnEditScheduleButton()
        {
            //GetTask has same xpath
            btnEditScheduleItem = driver.GetByXpath("//span[@class='fc-title']");
            btnEditScheduleItem.Click();
        }

        public void ClickOnDeleteScheduleButton()
        {
            //it will delete some task, not specific one
            btnDeleteScheduleItem = driver.GetByXpath("//i[@class='fa fa-trash-o']");
            btnDeleteScheduleItem.Click();
        }

        public AddScheduleItemPage AddItem()
        {
            ClickOnAddScheduleButton();
            return GetPOM<AddScheduleItemPage>(driver);
        }

        public EditScheduleItemPage EditItem()
        {
            ClickOnEditScheduleButton();
            return GetPOM<EditScheduleItemPage>(driver);
        }

        public DeleteScheduleItemPage DeleteItem()
        {
            ClickOnDeleteScheduleButton();
            return GetPOM<DeleteScheduleItemPage>(driver);
        }

        public HistoryPage ClickOnTabHistory()
        {
            tabHistory.Click();
            return GetPOM<HistoryPage>(driver);
        }

        public StatisticsPage ClickOnTabStatistics()
        {
            tabStatistics.Click();
            return GetPOM<StatisticsPage>(driver);
        }
    }
}
