﻿using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPayLibrary.Changes
{
    public class ConnectedUtilitiesForm : BasePageObject
    {
        WebElementWrapper btnConnectedUtilities;
        WebElementWrapper btnDisconnect;
        WebElementWrapper addressesDropdown;
        WebElementWrapper btnCallinspector;
        WebElementWrapper selectDate;
        WebElementWrapper btnCall;
        WebElementWrapper text;

        public override void Init(DriverWrapper driver)
        {
            base.Init(driver);
            btnConnectedUtilities = driver.GetByXpath("//a[@href='/user/connected-utilities/']");
            addressesDropdown = driver.GetByXpath("//select[@id='selectAddress']");           
        }

        public void ClickOnConnectedUtilities()
        {
            btnConnectedUtilities.Click();
        }

        public string SelectAddress(string address)
        {
            SelectElement list = addressesDropdown.selectElement();
            list.SelectByText(address);
            return list.SelectedOption.Text;
        }

        public void CallInspector(string address)
        {
            SelectAddress(address);
            ClickOnCallInspector();
            SelectDate();
        }

        public ConnectedUtilitiesForm Disconect()
        {
            btnDisconnect = driver.GetByXpath("//td[contains(text(),'ДнепрОблЭнерго')]/..//td[3]/a");
            btnDisconnect.Click();
            return GetPOM<ConnectedUtilitiesForm>(driver);
        }

        public void ClickOnCallInspector()
        {
            btnCallinspector = driver.GetByXpath("//button[@id='preCall']");
            btnCallinspector.Click();
        }

        public void SelectDate()
        {
            selectDate = driver.GetByXpath("//input[@id='picker']");
            selectDate.Click();
            DateTime currentDate = DateTime.Today.AddDays(1);
            string currentDateString = currentDate.ToString("yyyy-MM-dd");
            selectDate.SendText(currentDateString);
        }

        public HomePageUser SubmitCall()
        {
            btnCall = driver.GetByXpath("//button[@id='submit']");
            btnCall.Click();
            return GetPOM<HomePageUser>(driver);
        }

        public string VerifyThatUtilitiExist()
        {
            try
            {
                text = driver.GetByXpath("//td[contains(text(),'ДнепрОблЭнерго')]/..");
            }
            catch (WebDriverTimeoutException)
            {
                return null;
            }
            return text.GetText();
        }
    }
}