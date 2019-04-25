using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPayLibrary.Pages
{
    public class UsersSidebar : BasePageObject
    {
        WebElementWrapper role;
        WebElementWrapper addresses;
        WebElementWrapper connectedUtilities;
        WebElementWrapper payments;
        WebElementWrapper paymentsHistory;
        WebElementWrapper rateInspectors;

        public override void Init(DriverWrapper driver)
        {
            role = driver.GetByXpath("//*[@class='menu_section']/h3");
            addresses = driver.GetByXpath("//*[@href='/user/addresses']/span");
            connectedUtilities = driver.GetByXpath("//*[@href='/user/connected-utilities/']/span");
            payments = driver.GetByXpath("//*[@href='/user/paymentsPage']/span");
            paymentsHistory = driver.GetByXpath("//*[@href='/user/paymentsHistoryPage']/span");
            rateInspectors = driver.GetByXpath("//*[@href='/user/rate/']/span");
            base.Init(driver);
        }

        public string GetRoleText()
        {
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
    }
}
