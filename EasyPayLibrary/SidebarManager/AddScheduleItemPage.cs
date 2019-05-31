using EasyPayLibrary.SidebarManager;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPayLibrary.ManagerSidebar
{
    public class AddScheduleItemPage : BasePageObject
    {        
        WebElementWrapper fieldChooseDateAndTime;
        WebElementWrapper fieldChooseAddress;
        WebElementWrapper btnApply;

        public override void Init(DriverWrapper driver)
        {
            fieldChooseDateAndTime = driver.GetByXpath("//input[@id='datetimepicker']");
            fieldChooseAddress = driver.GetByXpath("//form[@id='add-schedule-item-form']//input[@placeholder='Select a Address']");
            btnApply = driver.GetByXpath("//button[@class='btn btn-primary js-add-apply']");
        }
        public void ChooseDateAndTime(string date)
        {
            fieldChooseDateAndTime.Click();
            DatePicker.DatePickerFunc(fieldChooseDateAndTime);
            fieldChooseDateAndTime.SendText(date);
        }

        public void ChooseAddress(string address)
        {
            fieldChooseAddress.SendText(address);
            fieldChooseAddress.sendEnter();
        }

        public void ClickOnApplyButton()
        {
            btnApply.Click();
        }

        public SchedulePage ApplyToAdd(string date, string address)
        {
            ChooseDateAndTime(date);
            ChooseAddress(address);
            ClickOnApplyButton();
            return GetPOM<SchedulePage>(driver);
        }

        public bool IsAddressFromScheduleDisplayed()
        {
            try
            {
                var element = driver.GetByXpath("//div[@class='fc-content']");
                return element.IsDisplayed();
            }
            catch (WebDriverTimeoutException)
            {
                return false;
            }
        }
    }
}
