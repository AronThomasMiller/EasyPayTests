using OpenQA.Selenium.Support.UI;

namespace EasyPayLibrary
{
    public class PaymentPage: UsersHomePage
    {
        WebElementWrapper addressesDropdown;
        WebElementWrapper utilitiesTable;

        public override void Init(DriverWrapper driver)
        {
            base.Init(driver);
            addressesDropdown = driver.GetByXpath("//select[@id='selectAddress']");
            utilitiesTable = driver.GetByXpath("//table[@id='historyTable']");
        }

        public void ChooseAddress(string address)
        {
            SelectElementWrapper list;
            list = new SelectElementWrapper(addressesDropdown);
            list.SelectByText(address);
        }

        public UtilityDetailsPage NavigateToUtilityDetails(string utility)
        {
            WebElementWrapper btnDetails = driver.GetByXpath($"//tbody/tr/td[contains(text(),'{utility}')]/../td[3]/button");
            btnDetails.Click();
            return GetPOM<UtilityDetailsPage>(driver);
        }

        public SelectPaymentSumPage NavigateToSelectPaymentSumPage(string utility)
        {
            NavigateToUtilityDetails(utility);
            return GetPOM<SelectPaymentSumPage>(driver);
        }

        public UsersHomePage Pay(string address, string utility, float sum, string email, string cardNumber, string dateOfCard, string cvc, string zipCode)
        {
            ChooseAddress(address);
            var page = NavigateToUtilityDetails(utility);
            page.PayForSum(sum, email, cardNumber, dateOfCard, cvc, zipCode);
            return GetPOM<UsersHomePage>(driver);
        }


    }
}