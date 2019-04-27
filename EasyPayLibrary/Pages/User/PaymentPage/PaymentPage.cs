using OpenQA.Selenium.Support.UI;

namespace EasyPayLibrary
{
    public class PaymentPage: HomePageUser
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
            SelectElement list;
            list = addressesDropdown.SelectElement();
            list.SelectByText(address);
        }

        public UtilityDetailsPage NavigateToUtilityDetails(string utility)
        {
            WebElementWrapper btnDetails = driver.GetByXpath($"//tbody/tr/td[contains(text(),'{utility}')]/../td[3]/button");
            btnDetails.ClickOnIt();
            return GetPOM<UtilityDetailsPage>(driver);
        }

        public SelectPaymentSumPage NavigateToSelectPaymentSumPage(string utility)
        {
            NavigateToUtilityDetails(utility);
            return GetPOM<SelectPaymentSumPage>(driver);
        }

        public HomePageUser Pay(string utility, float sum, string email, string cardNumber, string dateOfCard, string cvc, string zipCode)
        {
            var page = NavigateToUtilityDetails(utility);
            page.PayForSum(sum, email, cardNumber, dateOfCard, cvc, zipCode);
            return GetPOM<HomePageUser>(driver);
        }

   
    }
}