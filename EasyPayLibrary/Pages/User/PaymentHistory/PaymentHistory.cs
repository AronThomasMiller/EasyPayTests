using OpenQA.Selenium.Support.UI;
using System;

namespace EasyPayLibrary
{
    public class PaymentHistory:HomePageUser
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

        public void ChooseAddress(string address)
        {
            SelectElement list;
            list = addressesDropdown.SelectElement();
            list.SelectByText(address);
        }

        public void ChooseUtility(string utility)
        {
            SelectElement list;
            list = utilitiesDropdown.SelectElement();
            list.SelectByText(utility);
        }

        public string GetLastPayInString()
        {
            tblPayment = GetPOM<PaymentHistoryTable>(driver);
            return tblPayment.GetLastPayInString();
            //return driver.GetByXpath("//tbody//tr[last()]//td[1]").GetText() + "_" + driver.GetByXpath("//tbody//tr[last()]//td[2]").GetText();
        }
    }
}