using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPayLibrary.Pages.Manager
{
    public class SidebarManager : SidebarBase
    {
        WebElementWrapper InspectorsPage;
        WebElementWrapper UtilityPricePage;

        public override void Init(DriverWrapper driver)
        {
            base.Init(driver);
            InspectorsPage = driver.GetByXpath("//a[@href='/manager/schedule/']");
            UtilityPricePage = driver.GetByXpath("//a[@href='/manager/utility/price']");
        }

        public void ClickOnInspectors()
        {
            InspectorsPage.Click();
        }

        public void ClickOnUtilityPrice()
        {
            UtilityPricePage.Click();
        }
    }
}
