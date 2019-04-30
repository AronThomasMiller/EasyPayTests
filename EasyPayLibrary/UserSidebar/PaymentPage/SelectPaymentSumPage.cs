namespace EasyPayLibrary
{
    public class SelectPaymentSumPage:BasePageObject
    {
        WebElementWrapper fieldSumToPay;
        WebElementWrapper btnDownloadCheck;
        WebElementWrapper btnPay;

        public override void Init(DriverWrapper driver)
        {
            base.Init(driver);
            fieldSumToPay = driver.GetByXpath("//input[@id='payment-sum-input']");
            btnDownloadCheck = driver.GetByXpath("//span[@id='download-check-text']");
            btnPay = driver.GetByXpath("//button[@id='payment-proceed']");
        }

        public void PayForSum(float sum, string email, string cardNumber, string dateOfCard, string cvc, string zipCode)
        {
            SetSumToPay(sum);
            ChooseDownloadCheck();
            ClickOnPayButton();
            var payFramePage = GetPOM<PaymentFrame>(driver);
            payFramePage.FillUpPayForm(email, cardNumber, dateOfCard, cvc, zipCode);
        }

        public void SetSumToPay(float sum)
        {
            fieldSumToPay.SendText(sum.ToString());
        }

        public void ChooseDownloadCheck()
        {
            btnDownloadCheck.Click();
        }

        public void ClickOnPayButton()
        {
            btnPay.Click();
        }
    }
}