using EasyPayLibrary.Changes;
using EasyPayLibrary.Pages;
using EasyPayLibrary.Pages.Base;
using System.Collections.Generic;

namespace EasyPayLibrary
{
    public class HomePageUser : GeneralPage
    {
        WebElementWrapper mainPageTitle;
        WebElementWrapper xTitle;
        SidebarUser sidebar;        

        public override void Init(DriverWrapper driver)
        {            
            sidebar = GetPOM<SidebarUser>(driver);
            base.Init(driver);
        }

        public string GetAddressesText()
        {
            return sidebar.GetAddressesText();
        }

        public string GetConnectedUtilitiesText()
        {
            return sidebar.GetConnectedUtilitiesText();
        }

        public string GetPaymentsText()
        {
            return sidebar.GetPaymentsText();
        }

        public string GetPaymentsHistoryText()
        {
            return sidebar.GetPaymentsHistoryText();
        }

        public string GetRateInspectorsText()
        {
            return sidebar.GetRateInspectorsText();
        }

        public HomePageUser ChangeToUKR()
        {
            header.ChangeToUa();
            return GetPOM<HomePageUser>(driver);
        }

        public string GetMainPageTitleText()
        {
            mainPageTitle = driver.GetByXpath("//*[@data-locale-item='mainPage']/span");
            return mainPageTitle.GetText();
        }

        public string GetXTitleText()
        {
            xTitle = driver.GetByXpath("//*[@class='x_title']/h2");
            return xTitle.GetText();
        }

        public PaymentPage NavigateToPayment()
        {
            sidebar.ClickOnPayment();
            return GetPOM<PaymentPage>(driver);
        }

        public PaymentsHistoryPage NavigateToPaymentHistory()
        {
            sidebar.ClickOnPaymentHistory();
            return GetPOM<PaymentsHistoryPage>(driver);
        }

        public IEnumerable<WebElementWrapper> GetList()
        {
            return sidebar.GetListOfSideBarComponents();
        }

        public AddAddressForm NavigateToAddresses()
        {
            sidebar.ClickOnAddresses();
            return GetPOM<AddAddressForm>(driver);
        }

        public ConnectedUtilitiesForm NavigateToUtilities()
        {
            sidebar.ClickOnConnectedUtilities();
            return GetPOM<ConnectedUtilitiesForm>(driver);
        }

        public RateInspectorsPage NavigateToRateInspectors()
        {
            sidebar.ClickOnRateInspectorsPage();
            return GetPOM<RateInspectorsPage>(driver);
        }
    }    
}