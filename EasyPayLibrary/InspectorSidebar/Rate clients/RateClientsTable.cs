using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPayLibrary.InspectorSidebar.Rate_clients
{
    public class RateClientsTable : BasePageObject
    {
        List<RateClientsRows> table;

        public override void Init(DriverWrapper driver)
        {
            List<WebElementWrapper> tableOnPage;
            base.Init(driver);

            try
            {
                tableOnPage = driver.GetElementsByXpath("//table[@class='table table-hover text-justify']//tbody//tr");
            }
            catch (WebDriverTimeoutException)
            {
                return;
            }
            table = new List<RateClientsRows>();

            foreach (var element in tableOnPage)
            {
                table.Add(new RateClientsRows(element, driver));
            }
            table = tableOnPage.Select(element => new RateClientsRows(element, driver)).ToList();
        }

        public RateClientsRows GetFirstRow()
        {
            return table.First();
        }

        public RateClientsRows GetLastRow()
        {
            return table.Last();
        }

        public List<RateClientsRows> GetAllRows()
        {
            return table;
        }        
    }
}
