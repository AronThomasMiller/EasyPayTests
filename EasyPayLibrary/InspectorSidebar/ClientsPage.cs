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

        //public class ClientDataRow : BasePageObject
        //{
        //    WebElementWrapper row { get; set; }
            
        //    public string GetName()
        //    {
        //        return row.fin
        //    }
        //    public void Rate(int starNumber, bool andHalf = false);
        //}

            public enum Stars
        {
            One,
            OneAndHalf,
            Two,
        }

        public WebElementWrapper Rate(string name, int starNumber, int halfStar)
        { 
            WebElementWrapper starRate = driver.GetByXpath($"//td[contains(text(),'{name}')]/../td[3]/span/div[{starNumber}]/div[{halfStar}]");
            WebElementWrapper element = driver.GetByXpath("//tbody/tr[1]/td[3]/span[1]");
            var actionMove = new ActionsWrapper(driver, element, 12, 5);
            starRate.Click();
            var errorOrSuccess = driver.GetByXpath("//h4[@class='ui-pnotify-title']");
            return errorOrSuccess;
        }
    }
}
