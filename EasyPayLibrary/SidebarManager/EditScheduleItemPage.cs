using EasyPayLibrary.SidebarManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPayLibrary.ManagerSidebar
{
    public class EditScheduleItemPage : BasePageObject
    {
        WebElementWrapper chooseDateAndTime;
        WebElementWrapper deleteAddress;
        WebElementWrapper chooseAddress;
        WebElementWrapper btnApply;

        public override void Init(DriverWrapper driver)
        {
            chooseDateAndTime = driver.GetByXpath("//input[@id='datetimepicker-edit']");
            deleteAddress = driver.GetByXpath("//*[@id='edit-schedule-item-form']/div/div/span");
            chooseAddress = driver.GetByXpath("//form[@id='edit-schedule-item-form']//input[@placeholder='Select a Address']");
            btnApply = driver.GetByXpath("//button[@class='btn btn-primary js-edit-apply']");
            base.Init(driver);
        }

        public void ChooseDateAndTime(string date)
        {
            chooseDateAndTime.Click();
            DatePicker.DatePickerFunc(chooseDateAndTime);
            chooseDateAndTime.SendText(date);
        }

        public void ChooseAddressToEdit(string address)
        {
            deleteAddress.Click();
            chooseAddress.Click();
            chooseAddress.SendText(address);
            chooseAddress.sendEnter();
        }

        public void ClickOnApplyButton()
        {
            btnApply.Click();
        }

        public SchedulePage ApplyToEdit(string date, string address)
        {
            ChooseDateAndTime(date);
            ChooseAddressToEdit(address);
            ClickOnApplyButton();
            return GetPOM<SchedulePage>(driver);
        }
    }
}
