using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPayLibrary
{
    public class ManagerSidebar : BasePageObject
    {
        public WebElementWrapper btnInspectors;
        public WebElementWrapper btnUtilityPrice;


        public override void Init(DriverWrapper driver)
        {
            btnInspectors = driver.GetByXpath("//a[@href='/manager/schedule/']");
            btnUtilityPrice = driver.GetByXpath("//a[@href='/manager/utility/price']");

            base.Init(driver);
        }


        public void ClickOnInspectorsButton()
        {
            btnInspectors.Click();

        }

        public void ClickOnUtilityPriceButton()
        {
            btnUtilityPrice.Click();

        }


    }
}
