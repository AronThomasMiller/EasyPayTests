using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPayLibrary
{
    public class UtilityPricePage : BasePageObject
    {

        WebElementWrapper btnSetNewPrice;
        WebElementWrapper btnSetFuturePrice;
        WebElementWrapper inputFormForNewPrice;
        WebElementWrapper inputFormForFuturePrice;
        WebElementWrapper inputFormForDate;
        WebElementWrapper btnApplyNewPrice;
        WebElementWrapper btnApplyFuturePrice;


        public override void Init(DriverWrapper driver)
        {

            btnSetNewPrice = driver.GetByXpath("//button[@id='price_form_btn']");
            btnSetFuturePrice = driver.GetByXpath("//button[@id='future_price_form_btn']");
            base.Init(driver);
        }

        public void ClickOnSetNewPriceButton()
        {
            btnSetNewPrice.Click();
        }

        public void ClickOnSetFuturePriceButton()
        {
            btnSetFuturePrice.Click();
        }

        public void SetValueIntoNewPriceForm(string value)
        {
            inputFormForNewPrice = driver.GetByXpath("//input[@id='new_price_value']");
            inputFormForNewPrice.SendText(value);
        }

        public void SetValueIntoFuturePriceForm(string value)
        {
            inputFormForFuturePrice = driver.GetByXpath("//input[@id='future_price_value']");
            inputFormForFuturePrice.SendText(value);
        }

        public void SetDate(string date)
        {
            inputFormForDate = driver.GetByXpath("//input[@id='future_price_date']");
            inputFormForDate.SendText(date);
        }

        public void ClickOnApplyNewPriceButton()
        {
            btnApplyNewPrice = driver.GetByXpath("//*[@id='price_form']/button");
            btnApplyNewPrice.Click();
        }

        public void ClickOnApplyFuturePriceButton()
        {
            btnApplyFuturePrice = driver.GetByXpath("//*[@id='future_price_form']/button");
            btnApplyFuturePrice.Click();
        }

        public string GetCurrentPrice()
        {
            var currentPrice = driver.GetByXpath("//p[@id='service_price']").GetText();
            return currentPrice;
        }

        public string GetFuturePrice()
        {
            var futurePrice = driver.GetByXpath("//p[@id='future_price']").GetText();
            return futurePrice;
        }

        public string GetActivationDate()
        {
            var activationDate = driver.GetByXpath("//p[@id='activation_date']").GetText();
            return activationDate;
        }

        public void SetNewPrice(string value)
        {
            ClickOnSetNewPriceButton();
            SetValueIntoNewPriceForm(value);
            ClickOnApplyNewPriceButton();

        }

        public void SetFuturePrice(string value, string date)
        {
            ClickOnSetFuturePriceButton();
            SetValueIntoFuturePriceForm(value);
            SetDate(date);
            ClickOnApplyFuturePriceButton();

        }
    }
}
