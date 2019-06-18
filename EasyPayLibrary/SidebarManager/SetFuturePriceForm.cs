namespace EasyPayLibrary.ManagerSidebar
{
    public class SetFuturePriceForm : BasePageObject
    {
        WebElementWrapper btnApplyFuturePrice;
        WebElementWrapper inputFormForFuturePrice;
        WebElementWrapper inputFormForDate;

        public override void Init(DriverWrapper driver)
        {
            base.Init(driver);
            inputFormForFuturePrice = driver.GetByXpath("//input[@id='future_price_value']");
            inputFormForDate = driver.GetByXpath("//input[@id='future_price_date']");
            btnApplyFuturePrice = driver.GetByXpath("//*[@id='future_price_form']/button");
        }

        public void SetValueIntoFuturePriceForm(string value)
        {
            inputFormForFuturePrice.SendText(value);
        }

        public void SetDate(string date)
        {
            inputFormForDate.SendText(date);
        }

        public void ClickOnApplyFuturePriceButton()
        {
            btnApplyFuturePrice.Click();
        }

        public void SetFuturePrice(string value, string date)
        {
            SetValueIntoFuturePriceForm(value);
            SetDate(date);
            ClickOnApplyFuturePriceButton();
        }
    }
}