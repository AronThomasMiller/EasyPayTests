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
        WebElementWrapper fieldChooseDateAndTime;
        WebElementWrapper fieldDeleteAddress;
        WebElementWrapper fieldChooseAddress;
        WebElementWrapper btnApply;

        public override void Init(DriverWrapper driver)
        {
            fieldChooseDateAndTime = driver.GetByXpath("//input[@id='datetimepicker-edit']");
            fieldDeleteAddress = driver.GetByXpath("//*[@id='edit-schedule-item-form']/div/div/span");
            fieldChooseAddress = driver.GetByXpath("//form[@id='edit-schedule-item-form']//input[@placeholder='Select a Address']");
            btnApply = driver.GetByXpath("//button[@class='btn btn-primary js-edit-apply']");
            base.Init(driver);
        }

        public void ChooseDateAndTime(string date)
        {
            fieldChooseDateAndTime.Click();
            DatePicker.DatePickerFunc(fieldChooseDateAndTime);
            fieldChooseDateAndTime.SendText(date);
        }

        public void ChooseAddressToEdit(string address)
        {
            fieldDeleteAddress.Click();
            fieldChooseAddress.Click();
            fieldChooseAddress.SendText(address);
            fieldChooseAddress.sendEnter();
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
