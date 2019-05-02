using OpenQA.Selenium.Support.UI;
using System;

namespace EasyPayLibrary
{
    public class PaymentsHistoryPage: UsersHomePage
    {
        WebElementWrapper addressesDropdown;
        WebElementWrapper utilitiesDropdown;
        PaymentHistoryTable tblPayment;

        public override void Init(DriverWrapper driver)
        {
            base.Init(driver);

            addressesDropdown = driver.GetByXpath("//select[@id='select-address']");
            utilitiesDropdown = driver.GetByXpath("//select[@id='select-utility']");
        }

        public string SelectAddress(string address)
        {
            SelectElement listOfAddresses;
            listOfAddresses = addressesDropdown.selectElement();
            listOfAddresses.SelectByText(address);
            return listOfAddresses.SelectedOption.Text;
        }

        public void SelectUtility(string utility)
        {
            SelectElementWrapper list;
            list = new SelectElementWrapper(utilitiesDropdown);
            list.SelectByText(utility);
        }

        public string GetLastPayInString(string address, string utility)
        {
            SelectAddress(address);
            SelectUtility(utility);
            tblPayment = GetPOM<PaymentHistoryTable>(driver);
            return tblPayment.GetLastPayInString();
            //return driver.GetByXpath("//tbody//tr[last()]//td[1]").GetText() + "_" + driver.GetByXpath("//tbody//tr[last()]//td[2]").GetText();
        }
    }
}