using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPayLibrary.Changes
{
    public class SideBarUser: BaseSidebar
    {
        public WebElementWrapper addresses;
        public WebElementWrapper connectedUttilities;
        public WebElementWrapper payments;
        public WebElementWrapper paymentsHistory;
        public WebElementWrapper rateInspectors;

        public override void Init(DriverWrapper driver)
        {
            addresses = driver.GetByXpath("//a[@href='/user/addresses']");
            connectedUttilities = driver.GetByXpath("//a[@href='/user/connected-utilities/']");
            payments = driver.GetByXpath("//a[@href='/user/paymentsPage']");
            paymentsHistory = driver.GetByXpath("//a[@href='/user/paymentsHistoryPage']");
            rateInspectors = driver.GetByXpath("//a[@href='/user/rate/']");
            base.Init(driver);
        }        
    }
}