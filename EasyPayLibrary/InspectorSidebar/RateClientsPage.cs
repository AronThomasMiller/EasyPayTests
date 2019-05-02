using EasyPayLibrary.HomePages;
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
        ClientsPage clientsPage;

        public override void Init(DriverWrapper driver)
        {
            element = driver.GetByXpath("//table[@id='user-list-rating']//tbody");
            base.Init(driver);
        }

        public bool ElementsIsDisplayed()
        {
            return element.IsDisplayed();
        }

        public ClientsPage ReturnRateClients()
        {
            return GetPOM<ClientsPage>(driver);
        }
    }
}
