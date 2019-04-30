using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
            btnApply = driver.GetByXpath("//button[@class='btn btn-primary js-add-apply']");
            base.Init(driver);
        }
        /// <summary>
        /// REDO
        /// </summary>
        /// <returns></returns>
        public void ChooseDateAndTime(string date)
        {
            chooseDateAndTime.Click();
            chooseDateAndTime.sendBackSpace();
            chooseDateAndTime.sendBackSpace();
            chooseDateAndTime.sendBackSpace();
            chooseDateAndTime.sendBackSpace();
            chooseDateAndTime.sendBackSpace();
            chooseDateAndTime.sendBackSpace();
            chooseDateAndTime.sendBackSpace();
            chooseDateAndTime.sendBackSpace();
            chooseDateAndTime.SendText(date);
        }
        public void ChooseAddress(string address)
        {
            chooseAddress.Click();
            chooseAddress.SendText(address);
            chooseAddress.sendEnter();
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


    }
}