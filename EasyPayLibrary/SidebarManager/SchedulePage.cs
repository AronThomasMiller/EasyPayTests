using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPayLibrary
{
    public class SchedulePage : BasePageObject
    {
        WebElementWrapper btnAddScheduleItem;
        WebElementWrapper btnEditScheduleItem;
        WebElementWrapper btnDeleteScheduleItem;

        public override void Init(DriverWrapper driver)
        {
            btnAddScheduleItem = driver.GetByXpath("//button[@class='fc-addScheduleItem-button fc-button fc-state-default fc-corner-left fc-corner-right']");

            base.Init(driver);
        }
        public WebElementWrapper GetAddScheduleItem()
        {
            return btnAddScheduleItem;
        }

        public WebElementWrapper GetTask()
        {
            return driver.GetByXpath("//span[@class='fc-title']");
        }
        public void ClickOnAddScheduleButton()
        {
            btnAddScheduleItem.Click();
        }

        public void ClickOnEditScheduleButton()
        {
            btnEditScheduleItem = driver.GetByXpath("//span[@class='fc-title']");
            btnEditScheduleItem.Click();
        }

        public void ClickOnDeleteScheduleButton()
        {
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


    }
}
