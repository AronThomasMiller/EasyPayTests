using EasyPayLibrary.Changes;
using EasyPayLibrary.Pages;
using EasyPayLibrary.Pages.Base;
using System.Collections.Generic;

namespace EasyPayLibrary
{
    public class UsersHomePage : GeneralPage
    {
        WebElementWrapper role;
        WebElementWrapper mainPageTitle;
        WebElementWrapper xTitle;

        SidebarUsers sidebar;
        SidebarBase sidebarBase;

        public override void Init(DriverWrapper driver)
        {
            sidebarBase = GetPOM<SidebarBase>(driver);
            sidebar = GetPOM<SidebarUsers>(driver);
            base.Init(driver);
        }

        public bool GetRole()
        {
            role = driver.GetByXpath("//h3[text()='User']");
            return role.IsDisplayed();
        }
        public string GetRoleText()
        {
            return sidebar.GetRoleText().ToLower();
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

        public UsersHomePage ChangeToUKR()
        {
            header.ChangeToUa();
            return GetPOM<UsersHomePage>(driver);
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
            return sidebarBase.GetListOfSideBarComponents();
        }

        public AddAddressForm OpenAddresses()
        {
            sidebar.GoToAddresses();
            return GetPOM<AddAddressForm>(driver);
        }
        public ConnectedUtilitiesForm OpenUtilities()
        {
            sidebar.GoToConnectedUtilities();
            return GetPOM<ConnectedUtilitiesForm>(driver);
        }
        public PaymentsHistoryPage OpenPaymentsHistory()
        {
            sidebar.GoToPaymentsHistory();
            return GetPOM<PaymentsHistoryPage>(driver);
        }
        public PaymentPage OpenPayments()
        {
            sidebar.GoToPayments();
            return GetPOM<PaymentPage>(driver);
        }
        public RateInspectorsPage OpenRateInspectors()
        {
            sidebar.GoToRateInspectors();
            return GetPOM<RateInspectorsPage>(driver);
        }
    }

    //public bool TranslateToUA(string value)
    //{
    //    Translation translation = new Translation();
    //    return translation.CheckUA(value);
    //}
}