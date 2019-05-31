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
        WebElementWrapper btnDeleteAddress;
        WebElementWrapper fieldChooseAddress;
        WebElementWrapper btnApply;

        public override void Init(DriverWrapper driver)
        {
            fieldChooseDateAndTime = driver.GetByXpath("//input[@id='datetimepicker-edit']");
            btnDeleteAddress = driver.GetByXpath("//*[@id='edit-schedule-item-form']/div/div/span");
            fieldChooseAddress = driver.GetByXpath("//form[@id='edit-schedule-item-form']//input[@placeholder='Select a Address']");
            btnApply = driver.GetByXpath("//button[@class='btn btn-primary js-edit-apply']");
            base.Init(driver);
        }        

        public void ClearFieldChooseDateAndTime()
        {
            for (int i = 0; i <= 7; i++)
            {
                fieldChooseDateAndTime.sendBackSpace();
            }
        }
        public void ChooseDateAndTime(string date)
        {
            fieldChooseDateAndTime.Click();
            ClearFieldChooseDateAndTime();
            fieldChooseDateAndTime.SendText(date);
        }

        public void ChooseAddressToEdit(string address)
        {
            btnDeleteAddress.Click();
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
