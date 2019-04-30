using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static EasyPayLibrary.Pages.Inspector.ClientsPage;

namespace EasyPayLibrary.Pages.Inspector
{
    public class RateClientsPage : HomePageInspector
    {
        public WebElementWrapper element;
        public ClientsPage clientsPage;
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
