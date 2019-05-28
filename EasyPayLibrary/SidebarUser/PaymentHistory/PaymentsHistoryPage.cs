using OpenQA.Selenium.Support.UI;
using System;

namespace EasyPayLibrary
{
    public class PaymentsHistoryPage: HomePageUser
    {
        WebElementWrapper addressesDropdown;
        WebElementWrapper utilitiesDropdown;

        public override void Init(DriverWrapper driver)
        {
            base.Init(driver);
            addressesDropdown = driver.GetByXpath("//select[@id='select-address']");
            utilitiesDropdown = driver.GetByXpath("//select[@id='select-utility']");
        }

        public string SelectAddress(string address)
        {
            SelectElementWrapper listOfAddresses = addressesDropdown.SelectElement();
            listOfAddresses.SelectByText(address);
            return listOfAddresses.GetSelectedOptionText();
        }

        public void SelectUtility(string utility)
        {
            SelectElementWrapper list = new SelectElementWrapper(utilitiesDropdown);
            list.SelectByText(utility);
        }
        
        public PaymentHistoryTable InitTable()
        {
            return GetPOM<PaymentHistoryTable>(driver);
        }
    }
}