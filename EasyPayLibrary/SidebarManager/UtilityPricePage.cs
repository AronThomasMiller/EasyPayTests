using EasyPayLibrary.SidebarManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPayLibrary.ManagerSidebar
{
    public class UtilityPricePage : BasePageObject
    {
        WebElementWrapper btnSetNewPrice;
        WebElementWrapper btnSetFuturePrice;

        public override void Init(DriverWrapper driver)
        {
            base.Init(driver);
            btnSetNewPrice = driver.GetByXpath("//button[@id='price_form_btn']");
            btnSetFuturePrice = driver.GetByXpath("//button[@id='future_price_form_btn']");
        }

        public SetNewPriceForm ClickOnSetNewPriceButton()
        {
            btnSetNewPrice.Click();
            return GetPOM<SetNewPriceForm>(driver);
        }

        public SetFuturePriceForm ClickOnSetFuturePriceButton()
        {
            btnSetFuturePrice.Click();
            return GetPOM<SetFuturePriceForm>(driver);
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
    }
}
