using OpenQA.Selenium.Support.UI;
using System;

namespace EasyPayLibrary
{
    public class PaymentPage: UsersHomePage
    {
        WebElementWrapper addressesDropdown;
        WebElementWrapper utilitiesTable;
        
        WebElementWrapper selectAddresse;
        WebElementWrapper btnDetails;
        WebElementWrapper setNewValue;
        WebElementWrapper fieldNewValue;
        WebElementWrapper btnApply;
        WebElementWrapper balance;
        WebElementWrapper btnPay;
        WebElementWrapper fieldSum;
        WebElementWrapper sendCheck;
        WebElementWrapper btnProceed;
        WebElementWrapper fieldEmail;
        WebElementWrapper fieldCardNumber;
        WebElementWrapper fieldDate;
        WebElementWrapper fieldCVC;
        WebElementWrapper fieldZip;
        WebElementWrapper btnSubmit;

        public override void Init(DriverWrapper driver)
        {
            base.Init(driver);
            addressesDropdown = driver.GetByXpath("//select[@id='selectAddress']");
            utilitiesTable = driver.GetByXpath("//table[@id='historyTable']");
        }

        public void SelectAddress(string address)
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
            SelectAddress(address);
            var page = NavigateToUtilityDetails(utility);
            page.PayForSum(sum, email, cardNumber, dateOfCard, cvc, zipCode);
            return GetPOM<UsersHomePage>(driver);
        }

        public void EnterDebtInfo(string address, string sum)
        {
            selectAddresse = driver.GetByXpath("//*[@id='selectAddress']");
            SelectElement listOfAddressesPay;
            listOfAddressesPay = selectAddresse.selectElement();
            listOfAddressesPay.SelectByText(address);
            btnDetails = driver.GetByXpath("//tbody/tr[1]/td/button");
            btnDetails.Click();
            btnPay = driver.GetByXpath("//*[@id='pay']");
            btnPay.Click();
            fieldSum = driver.GetByXpath("//*[@id='payment-sum-input']");
            fieldSum.SendText(sum);
            sendCheck = driver.GetByXpath("//label[@id='download-check-label']");
            sendCheck.Click();
            btnProceed = driver.GetByXpath("//button[@id='payment-proceed']");
            btnProceed.Click();
        }
        
        public void MakePayment(string email, string cardNumb, string date, string cvc, string zip)
        {
            fieldEmail = driver.GetByXpath("//input[@placeholder='Email']");
            fieldEmail.SendText(email);
            fieldCardNumber = driver.GetByXpath("//input[@placeholder='Card number']");
            fieldCardNumber.SendText(cardNumb);
            fieldDate = driver.GetByXpath("//input[@placeholder='MM / YY']");
            fieldDate.SendText(date);
            fieldCVC = driver.GetByXpath("//input[@placeholder='CVC']");
            fieldCVC.SendText(cvc);
            fieldZip = driver.GetByXpath("//input[@placeholder='ZIP Code']");
            fieldZip.SendText(zip);
            btnSubmit = driver.GetByXpath("//button[@type='submit']");
            btnSubmit.Click();
        }

        public double GetBalance()
        {
            balance = driver.GetByXpath("//tbody/tr[1]/td[2]");
            return Convert.ToDouble(balance.GetText().Replace('.', ','));

        }
        public void ChangeMatrix(string address, string value)
        {
            selectAddresse = driver.GetByXpath("//*[@id='selectAddress']");
            SelectElement listOfAddressesPay;
            listOfAddressesPay = selectAddresse.selectElement();
            listOfAddressesPay.SelectByText(address);

            btnDetails = driver.GetByXpath("//tbody/tr[1]/td/button");
            btnDetails.Click();
            setNewValue = driver.GetByXpath("//table[@id = 'modal-table']/tbody/tr/td/button");
            setNewValue.Click();
            fieldNewValue = driver.GetByXpath("//input[@id='newCurrentValue']");
            fieldNewValue.SendText(value);
            btnApply = driver.GetByXpath("//button[@class='btn btn-primary js-apply']");
            btnApply.Click();
        }
    }
}