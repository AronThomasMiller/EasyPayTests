using EasyPayLibrary.HomePages;
using EasyPayLibrary.InspectorSidebar.Rate_clients;
using EasyPayLibrary.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPayLibrary.InspectorSidebar
{
    public class RateClientsPage : HomePageInspector
    {
        WebElementWrapper element;

        public override void Init(DriverWrapper driver)
        {
            element = driver.GetByXpath("//table[@id='user-list-rating']//tbody");
            base.Init(driver);
        }

        public bool ElementsIsDisplayed()
        {
            return element.IsDisplayed();
        }

        public RateClientsTable ReturnRateClients()
        {
            return GetPOM<RateClientsTable>(driver);
        }       
    }
}
