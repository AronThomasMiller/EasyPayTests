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
        //use property instead one-line method
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

        public HomePageUser ChangeToUA()
        {
            header.ChangeToUa();
            return TranslatePageToUA<HomePageUser>(driver);
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

        public PaymentPage NavigateToPaymentPage()
        {
            sidebar.ClickOnPayment();
            return GetPOM<PaymentPage>(driver);
        }

        public PaymentsHistoryPage NavigateToPaymentHistoryPage()
        {
            sidebar.ClickOnPaymentHistory();
            return GetPOM<PaymentsHistoryPage>(driver);
        }
        //Get List of what? function need to be able to say what it actualy returns
        public IEnumerable<WebElementWrapper> GetList()
        {
            return sidebar.ListOfSideBarComponents;
        }

        public AddAddressForm NavigateToAddressesPage()
        {
            sidebar.ClickOnAddresses();
            return GetPOM<AddAddressForm>(driver);
        }

        public ConnectedUtilitiesPage NavigateToConnectedUtilitiesPage()
        {
            sidebar.ClickOnConnectedUtilities();
            return GetPOM<ConnectedUtilitiesPage>(driver);
        }

        public RateInspectorsPage NavigateToRateInspectorsPage()
        {
            sidebar.ClickOnRateInspectorsPage();
            return GetPOM<RateInspectorsPage>(driver);
        }
    }    
}