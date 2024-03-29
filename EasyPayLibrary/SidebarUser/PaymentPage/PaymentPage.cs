﻿using OpenQA.Selenium.Support.UI;
using System;

namespace EasyPayLibrary
{
    public class PaymentPage: HomePageUser
    {
        //type of elems
        WebElementWrapper addressesDropdown;
        WebElementWrapper utilitiesTable;
        WebElementWrapper btnDetails;
        WebElementWrapper setNewValue;
        WebElementWrapper fieldNewValue;
        WebElementWrapper btnApply;
        WebElementWrapper balance;

        public override void Init(DriverWrapper driver)
        {
            base.Init(driver);
            addressesDropdown = driver.GetByXpath("//select[@id='selectAddress']");
            utilitiesTable = driver.GetByXpath("//table[@id='historyTable']");
        }

        public void SelectAddress(string address)
        {
            SelectElementWrapper list = new SelectElementWrapper(addressesDropdown);
            list.SelectByText(address);
        }

        public UtilityDetailsPage NavigateToUtilityDetails(string utility)
        {
            WebElementWrapper btnDetails = driver.GetByXpath($"//tbody/tr/td[contains(text(),'{utility}')]/../td[3]/button");
            btnDetails.Click();
            return GetPOM<UtilityDetailsPage>(driver);
        }

        public double GetBalance()
        {
            balance = driver.GetByXpath("//tbody/tr[1]/td[2]");
            return Convert.ToDouble(balance.GetText().Replace('.', ','));
        }

        //Incorrect
        public void ChangeMetrics(string address, string value)
        {
            SelectAddress(address);

            btnDetails = driver.GetByXpath("//tbody/tr[1]/td/button");
            btnDetails.Click();
            //separate class
            setNewValue = driver.GetByXpath("//table[@id = 'modal-table']/tbody/tr/td/button");
            setNewValue.Click();
            //
            fieldNewValue = driver.GetByXpath("//input[@id='newCurrentValue']");
            fieldNewValue.SendText(value);
            btnApply = driver.GetByXpath("//button[@class='btn btn-primary js-apply']");
            btnApply.Click();
        }
    }
}