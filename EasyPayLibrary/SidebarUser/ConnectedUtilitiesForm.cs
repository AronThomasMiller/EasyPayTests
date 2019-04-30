using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPayLibrary.Changes
{
   public class ConnectedUtilitiesForm: BasePageObject
    {
        WebElementWrapper btnConnectedUtilities;
        WebElementWrapper btnDisconnect;
        WebElementWrapper addressesDropdown;
        WebElementWrapper btnCallinspector;
        WebElementWrapper selectDate;
        WebElementWrapper btnCall;

        public override void Init(DriverWrapper driver)
        {
            btnConnectedUtilities = driver.GetByXpath("//a[@href='/user/connected-utilities/']");
            addressesDropdown = driver.GetByXpath("//select[@id='selectAddress']");
            base.Init(driver);

        }
        public void ClickOnConnectedUtilities()
        {
            btnConnectedUtilities.Click();
        }
        public string SelectAddress(string address)
        {
            SelectElement list;
            list = addressesDropdown.selectElement();
            list.SelectByText(address);
            return list.SelectedOption.Text;
        }

        public void Disconect()
        {
            btnDisconnect = driver.GetByXpath("//*[@id='disc']");
            btnDisconnect.Click();

        }
        public void ClickOnCallInspector()
        {
            btnCallinspector = driver.GetByXpath("//*[@id='preCall']");
            btnCallinspector.Click();
        }
        public void SelectDate()
        {
            selectDate = driver.GetByXpath("//*[@id='picker']");
            selectDate.Click();
            var currentDate = DateTime.Today.Day + 1;
            string currentDateString = currentDate.ToString();
            var list = driver.GetElementsByXpath("//td[@class='day']");
            foreach (var element in list)
            {
                if (element.GetText() == currentDateString)
                {
                    element.Click();
                    break;
                }
            }
            //selectDate.Enter();

        }
        public HomePageUser SubmitCall()
        {
            btnCall = driver.GetByXpath("//*[@id='submit']");
            btnCall.Click();
            driver.Refresh();
            return GetPOM<HomePageUser>(driver);

        }

    }
}
