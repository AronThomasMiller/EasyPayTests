using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPayLibrary.Changes
{
    public class PaymentsHistoryForm : GeneralPage
    {
        WebElementWrapper btnPaymentsHistory;
        WebElementWrapper selectAddresse;
        public override void Init(DriverWrapper driver)
        {
            btnPaymentsHistory = driver.GetByXpath("//a[@href='/user/paymentsHistoryPage']");
            selectAddresse = driver.GetByXpath("//select[@id='select-address']");
            base.Init(driver);

        }
        public void ClickOnPaymentsHistory()
        {
            btnPaymentsHistory.Click();
        }
        public string SelectAddress(string address)
        {
            SelectElement listOfAddresses;
            listOfAddresses = selectAddresse.selectElement();
            listOfAddresses.SelectByText(address);
            return listOfAddresses.SelectedOption.Text;
        }

    }
}
