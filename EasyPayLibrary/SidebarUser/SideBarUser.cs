using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPayLibrary.Changes
{
    class SideBarUser : BaseSidebar
    {
        protected WebElementWrapper addresses;
        protected WebElementWrapper selectAddresse;
        protected WebElementWrapper paymentsHistory;
        protected WebElementWrapper payments;
        protected WebElementWrapper rateInspectors;
        public override void Init(DriverWrapper driver)
        {
            addresses = driver.GetByXpath("//a[@href='/user/addresses']");
            selectAddresse = driver.GetByXpath("//a[@href='/user/connected-utilities/']");
            paymentsHistory = driver.GetByXpath("//a[@href='/user/paymentsHistoryPage']");
            payments = driver.GetByXpath("//a[@href='/user/paymentsPage']");
            rateInspectors = driver.GetByXpath("//a[@href='/user/rate/']");
            base.Init(driver);
        }
        public AddressesPage GoToAddresses()
        {
            addresses.Click();
            return GetPOM<AddressesPage>(driver);
        }
        public ConnectedUtilitiesPage GoToConnectedUtilities()
        {
            selectAddresse.Click();
            return GetPOM<ConnectedUtilitiesPage>(driver);
        }
        public PaymentsPage GoToPayments()
        {
            payments.Click();
            return GetPOM<PaymentsPage>(driver);
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
