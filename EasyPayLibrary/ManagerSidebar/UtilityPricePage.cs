using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPayLibrary
{
    public class UtilityPricePage : BasePageObject
    {
        WebElementWrapper setNewPrice;
        WebElementWrapper setFuturePrice;
        WebElementWrapper enterNewPrice;
        WebElementWrapper btnApplyCurrentPrice;

        WebElementWrapper enterNewFuturePrice;
        WebElementWrapper pickActivationDate;
        WebElementWrapper btnApplyFuturePrice;

        public string CurrentPrice;
        public string FuturePrice;

        public override void Init(DriverWrapper driver)
        {
            CurrentPrice = driver.GetByXpath("//p[@id='service_price']").GetText();
            FuturePrice = driver.GetByXpath("//p[@id='future_price']").GetText();
            setNewPrice = driver.GetByXpath("//*[@id='price_form_btn']");
            setFuturePrice = driver.GetByXpath("//button[@id='future_price_form_btn']");
            base.Init(driver);
        }

        public void ClickOnSetNewPrice()
        {
            setNewPrice.ClickOnIt();
        }

        public void SetNewPrice(string value)
        {
            ClickOnSetNewPrice();
            enterNewPrice = driver.GetByXpath("//input[@id='new_price_value']");
            enterNewPrice.SendText(value);
            btnApplyCurrentPrice = driver.GetByXpath("//form[@id='price_form']//button[@class='btn btn-success']");
            btnApplyCurrentPrice.ClickOnIt();
            driver.Refresh();
        }

        
        public void ClickOnSetFuturePriceButton()
        {
            setFuturePrice.ClickOnIt();
           //return GetPOM<UtilityPricePage>(driver);
        }
        
        public UtilityPricePage SetFuturePrice(string value , string data)
        {
            ClickOnSetFuturePriceButton();
            enterNewFuturePrice = driver.GetByXpath("//input[@id='future_price_value']");
            enterNewFuturePrice.SendText(value);
            pickActivationDate = driver.GetByXpath("//input[@id='future_price_date']");
            pickActivationDate.SendText(data);
            btnApplyFuturePrice = driver.GetByXpath("//form[@id='future_price_form']//button[@class='btn btn-success']");
            btnApplyFuturePrice.ClickOnIt();
            return GetPOM<UtilityPricePage>(driver);
        }

    }
}
