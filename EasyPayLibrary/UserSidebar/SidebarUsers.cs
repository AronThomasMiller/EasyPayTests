using EasyPayLibrary.Changes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPayLibrary.Pages
{
    public class SidebarUsers : SidebarBase
    {
        WebElementWrapper role;
        WebElementWrapper addresses;
        WebElementWrapper connectedUtilities;
        WebElementWrapper payments;
        WebElementWrapper paymentsHistory;
        WebElementWrapper rateInspectors;

        public override void Init(DriverWrapper driver)
        {
            base.Init(driver);
            addresses = sidebar[0];
            connectedUtilities = sidebar[1];
            payments = sidebar[2];
            paymentsHistory = sidebar[3];
            rateInspectors = sidebar[4];
            
        }

        public string GetRoleText()
        {
            role = driver.GetByXpath("//*[@class='menu_section']/h3");
            return role.GetText();
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

        public void ClickOnPayment()
        {
            sidebar[2].Click();
        }

        public void ClickOnPaymentHistory()
        {
            sidebar[3].Click();
        }

        public AddressesPage GoToAddresses()
        {
            addresses.Click();
            return GetPOM<AddressesPage>(driver);
        }
        public ConnectedUtilitiesPage GoToConnectedUtilities()
        {
            connectedUtilities.Click();
            return GetPOM<ConnectedUtilitiesPage>(driver);
        }
        public PaymentPage GoToPayments()
        {
            payments.Click();
            return GetPOM<PaymentPage>(driver);
        }

        public PaymentsHistoryPage GoToPaymentsHistory()
        {
            paymentsHistory.Click();
            return GetPOM<PaymentsHistoryPage>(driver);
        }
        public RateInspectorsPage GoToRateInspectors()
        {
            rateInspectors.Click();
            return GetPOM<RateInspectorsPage>(driver);
        }

    }
}
