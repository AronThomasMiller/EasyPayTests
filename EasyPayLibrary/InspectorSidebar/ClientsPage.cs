using EasyPayLibrary.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPayLibrary.InspectorSidebar
{
    public class ClientsPage : RateClientsPage
    {
        public override void Init(DriverWrapper driver)
        {
            base.Init(driver);
        }
        public WebElementWrapper Rate(string name, int starNumber, int halfStar)
        {
            //halfStar: 1 if a half, 2 if full star  
            WebElementWrapper starRate = driver.GetByXpath($"//td[contains(text(),'{name}')]/../td[3]/span/div[{starNumber}]/div[{halfStar}]");
            WebElementWrapper element = driver.GetByXpath("//tbody/tr[1]/td[3]/span[1]");
            var actionMove = new ActionsWrapper(driver, element, 12, 5);
            starRate.Click();
            var errorOrSuccess = driver.GetByXpath("//h4[@class='ui-pnotify-title']");
            return errorOrSuccess;
        }

    }
}
