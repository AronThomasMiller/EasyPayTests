namespace EasyPayLibrary
{
    public class SelectPaymentSumPage:BasePageObject
    {
        WebElementWrapper fieldSumToPay;
        WebElementWrapper btnDownloadCheck;
        WebElementWrapper btnProcceed;

        public override void Init(DriverWrapper driver)
        {
            base.Init(driver);
            fieldSumToPay = driver.GetByXpath("//input[@id='payment-sum-input']");
            btnDownloadCheck = driver.GetByXpath("//span[@id='download-check-text']");
            btnProcceed = driver.GetByXpath("//button[@id='payment-proceed']");
        }

        public PaymentFrame PayForSum(float sum)
        {
            SetSumToPay(sum);
            ClickOnPayButton();
            return GetPOM<PaymentFrame>(driver);
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
            btnProcceed.Click();
        }
    }
}