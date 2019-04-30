using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPayLibrary
{
    public class AddScheduleItemPage : BasePageObject
    {
        WebElementWrapper chooseDateAndTime;
        WebElementWrapper chooseAddress;
        WebElementWrapper btnApply;

        public override void Init(DriverWrapper driver)
        {
            chooseDateAndTime = driver.GetByXpath("//input[@id='datetimepicker']");
            chooseAddress = driver.GetByXpath("//form[@id='add-schedule-item-form']//input[@placeholder='Select a Address']");
            btnApply = driver.GetByXpath("//button[contains(@class, 'js-add-apply')]");
            base.Init(driver);
        }

        public AddScheduleItemPage ChooseDateAndTime(string date)
        {
            chooseDateAndTime.SendText(date);
            chooseDateAndTime.Enter();
            return GetPOM<AddScheduleItemPage>(driver);
        }

        public AddScheduleItemPage ChooseAddress(string address)
        {
            chooseAddress.SendText(address);
            chooseAddress.Enter();
            return GetPOM<AddScheduleItemPage>(driver);
        }

        public SchedulePage Apply()
        {
            btnApply.ClickOnIt();
            return GetPOM<SchedulePage>(driver);
        }

        public bool IsAddressFromScheduleDisplayed()
        {
           var element = driver.GetByXpath("//div[@class='fc-content']");
           return element.IsDisplayed();           
        }
    }
}
