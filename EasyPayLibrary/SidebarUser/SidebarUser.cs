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
        //elements on page need prefix to describe what the type of element it is
        WebElementWrapper addresses;
        WebElementWrapper connectedUtilities;
        WebElementWrapper payments;
        WebElementWrapper paymentsHistory;
        WebElementWrapper rateInspectors;

        public override void Init(DriverWrapper driver)
        {
            base.Init(driver);
            lnkAddresses = driver.GetByXpath("//a[@href='/user/addresses']");
            lnkConnectedUtilities = driver.GetByXpath("//a[@href='/user/connected-utilities/']");
            lnkPayments = driver.GetByXpath("//a[@href='/user/paymentsPage']");
            lnkPaymentsHistory = driver.GetByXpath("//a[@href='/user/paymentsHistoryPage']");
            lnkRateInspectors = driver.GetByXpath("//a[@href='/user/rate/']");
        }

        public string GetAddressesText()
        {
            return lnkAddresses.GetText();
        }

        public string GetConnectedUtilitiesText()
        {
            return lnkConnectedUtilities.GetText();
        }
        
        public string GetPaymentsText()
        {
            return lnkPayments.GetText();
        }

        public string GetPaymentsHistoryText()
        {
            return lnkPaymentsHistory.GetText();
        }

        public string GetRateInspectorsText()
        {
            return lnkRateInspectors.GetText();
        }

        public void ClickOnAddresses()
        {
            lnkAddresses.Click();
        }

        public void ClickOnConnectedUtilities()
        {
            lnkConnectedUtilities.Click();
        }

        public void ClickOnPayment()
        {
            lnkPayments.Click();
        }

        public void ClickOnPaymentHistory()
        {
            lnkPaymentsHistory.Click();
        }       
        
        public void ClickOnRateInspectorsPage()
        {
            lnkRateInspectors.Click();            
        }
    }
}
