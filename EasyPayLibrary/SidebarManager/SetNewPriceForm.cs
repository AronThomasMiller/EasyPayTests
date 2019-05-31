using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPayLibrary.SidebarManager
{
    public class SetNewPriceForm : BasePageObject
    {
        WebElementWrapper btnApplyNewPrice;
        WebElementWrapper inputFormForNewPrice;

        public override void Init(DriverWrapper driver)
        {
            base.Init(driver);
            inputFormForNewPrice = driver.GetByXpath("//input[@id='new_price_value']");
            btnApplyNewPrice = driver.GetByXpath("//*[@id='price_form']/button");
        }

        public void SetValueIntoNewPriceForm(string value)
        {
            inputFormForNewPrice.SendText(value);
        }

        public void ClickOnApplyNewPriceButton()
        {
            btnApplyNewPrice.Click();
        }

        public void SetNewPrice(string value)
        {
            SetValueIntoNewPriceForm(value);
            ClickOnApplyNewPriceButton();
            driver.Refresh();
        }
    }
}
