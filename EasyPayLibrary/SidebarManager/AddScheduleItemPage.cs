﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPayLibrary.ManagerSidebar
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

        public void ChooseDateAndTime(string date)
        {
            chooseDateAndTime.Click();
            for (int i = 0; i <= 7; i++)
            {
                chooseDateAndTime.sendBackSpace();
            }
            chooseDateAndTime.SendText(date);
        }

        public void ChooseAddress(string address)
        {
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

        public bool IsAddressFromScheduleDisplayed()
        {
            var element = driver.GetByXpath("//div[@class='fc-content']");
            return element.IsDisplayed();
        }
    }
}