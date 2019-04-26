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
            base.Init(driver);
        }

        public string GetRoleText()
        {
            role = driver.GetByXpath("//*[@class='menu_section']/h3");
            return role.GetText();
        }

        public string GetAddressesText()
        {
            addresses = driver.GetByXpath("//*[@href='/user/addresses']/span");
            return addresses.GetText();
        }

        public string GetConnectedUtilitiesText()
        {
            connectedUtilities = driver.GetByXpath("//*[@href='/user/connected-utilities/']/span");
            return connectedUtilities.GetText();
        }
        
        public string GetPaymentsText()
        {
            payments = driver.GetByXpath("//*[@href='/user/paymentsPage']/span");
            return payments.GetText();
        }

        public string GetPaymentsHistoryText()
        {
            paymentsHistory = driver.GetByXpath("//*[@href='/user/paymentsHistoryPage']/span");
            return paymentsHistory.GetText();
        }

        public string GetRateInspectorsText()
        {
            rateInspectors = driver.GetByXpath("//*[@href='/user/rate/']/span");
            return rateInspectors.GetText();
        }
    }
}
