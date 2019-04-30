using EasyPayLibrary.Pages;
using EasyPayLibrary.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPayLibrary
{
    public class InspectorsPage: RateInspectorsForm
    {
        public override void Init(DriverWrapper driver)
        {
            base.Init(driver);
        }

        public WebElementWrapper Rate(string name, int starNumber, int halfStar)
        {
            //halfStar: 1 if a half, 2 if full star  
            WebElementWrapper starRate = driver.GetByXpath($"//td[contains(text(),'{name}')]/../td[4]/span/div[{starNumber}]/div[{halfStar}]");
            WebElementWrapper element = driver.GetByXpath("//tbody/tr[1]/td[4]/span[1]");
            var actionMove = new ActionsWrapper(driver, element, 20, 10);
            starRate.Click();
            var errorOrSuccess = driver.GetByXpath("//h4[@class='ui-pnotify-title']"); 
            return errorOrSuccess;
        }
    }
}
