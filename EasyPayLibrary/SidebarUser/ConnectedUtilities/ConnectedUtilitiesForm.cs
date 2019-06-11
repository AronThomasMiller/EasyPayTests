using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPayLibrary.Changes
{
    public class ConnectedUtilitiesForm : HomePageUser
    {
        WebElementWrapper btnDisconnect;
        WebElementWrapper addressesDropdown;
        WebElementWrapper btnCallinspector;
        WebElementWrapper selectDate;
        WebElementWrapper btnCall;
        WebElementWrapper text;

        public override void Init(DriverWrapper driver)
        {
            base.Init(driver);
            addressesDropdown = driver.GetByXpath("//select[@id='selectAddress']");           
        }

        public string SelectAddress(string address)
        {
            SelectElementWrapper list = addressesDropdown.SelectElement();
            list.SelectByText(address);
            return list.GetSelectedOptionText();
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
            driver.Refresh();
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
