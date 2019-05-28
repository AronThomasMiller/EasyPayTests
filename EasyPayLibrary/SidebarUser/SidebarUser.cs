using EasyPayLibrary.Changes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPayLibrary.Pages
{
    public class SidebarUser: SidebarBase
    {
        WebElementWrapper addresses;
        WebElementWrapper connectedUtilities;
        WebElementWrapper payments;
        WebElementWrapper paymentsHistory;
        WebElementWrapper rateInspectors;

        public override void Init(DriverWrapper driver)
        {
            base.Init(driver);
            addresses = driver.GetByXpath("//a[@href='/user/addresses']");
            connectedUtilities = driver.GetByXpath("//a[@href='/user/connected-utilities/']");
            payments = driver.GetByXpath("//a[@href='/user/paymentsPage']");
            paymentsHistory = driver.GetByXpath("//a[@href='/user/paymentsHistoryPage']");
            rateInspectors = driver.GetByXpath("//a[@href='/user/rate/']");
        }

        public string GetAddressesText()
        {
            return addresses.GetText();
        }

        public string GetConnectedUtilitiesText()
        {
            return connectedUtilities.GetText();
        }
        
        public string GetPaymentsText()
        {
            return payments.GetText();
        }

        public string GetPaymentsHistoryText()
        {
            return paymentsHistory.GetText();
        }

        public string GetRateInspectorsText()
        {
            return rateInspectors.GetText();
        }

        public void ClickOnAddresses()
        {
            addresses.Click();
        }

        public void ClickOnConnectedUtilities()
        {
            connectedUtilities.Click();
        }

        public void ClickOnPayment()
        {
            payments.Click();
        }

        public void ClickOnPaymentHistory()
        {
            paymentsHistory.Click();
        }       
        
        public void ClickOnRateInspectorsPage()
        {
            rateInspectors.Click();            
        }
    }
}
