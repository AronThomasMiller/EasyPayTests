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
        //what the element? in this case i know it is some table and only by XPath, describe
        WebElementWrapper element;

        public override void Init(DriverWrapper driver)
        {
            element = driver.GetByXpath("//table[@id='user-list-rating']//tbody");
            base.Init(driver);
        }
        //same
        public bool ElementsIsDisplayed()
        {
            return element.IsDisplayed();
        }
        //RateCliens - it can be Page or Table idk, describe
        public RateClientsTable ReturnRateClients()
        {
            return GetPOM<RateClientsTable>(driver);
        }       
    }
}
