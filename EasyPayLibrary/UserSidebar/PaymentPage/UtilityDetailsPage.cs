namespace EasyPayLibrary
{
    public class UtilityDetailsPage:BasePageObject
    {
        WebElementWrapper btnSetNewValue;
        WebElementWrapper btnClose;
        WebElementWrapper btnPay;

        public override void Init(DriverWrapper driver)
        {
            base.Init(driver);
            btnSetNewValue = driver.GetByXpath("//button[@class='btn btn-primary change-value']");
            btnClose = driver.GetByXpath("//div[@class='modal-dialog modal-lg']//button[@class='btn btn-default']");
            btnPay = driver.GetByXpath("//button[@id='pay']");
        }

        public SetValuePage ClickSetNewValueButton()
        {
            btnSetNewValue.Click();
            return GetPOM<SetValuePage>(driver);
        }

        public UtilityDetailsPage SetNewValue(float Value)
        {
            var SetValuePage = ClickSetNewValueButton();
            SetValuePage.SetValue(Value);
            return GetPOM<UtilityDetailsPage>(driver);
        }

        public void ClickOnCloseButton()
        {
            btnClose.Click();
        }

        public PaymentPage CloseUtilityDetailsPage()
        {
            ClickOnCloseButton();
            return GetPOM<PaymentPage>(driver);
        }

        public void ClickOnButtonPay()
        {
            btnPay.Click();
        }

        public void PayForSum(float sum, string email, string cardNumber, string dateOfCard, string cvc, string zipCode)
        {
            ClickOnButtonPay();
            var page = GetPOM<SelectPaymentSumPage>(driver);
            page.PayForSum(sum, email, cardNumber, dateOfCard, cvc, zipCode);
        }
    }
}