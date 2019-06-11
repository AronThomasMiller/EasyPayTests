using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPayLibrary.InspectorSidebar.Check_counters
{
   public class UtilityPageTable : BasePageObject
    {
        List<UtilityPageRows> table;

        public override void Init(DriverWrapper driver)
        {
            List<WebElementWrapper> tableOnPage;
            base.Init(driver);

            try
            {
                tableOnPage = driver.GetElementsByXpath("//table[@class='table table-hover schedule text-center']//tbody//tr");
            }
            catch (WebDriverTimeoutException)
            {
                return;
            }
            table = new List<UtilityPageRows>();

            foreach (var element in tableOnPage)
            {
                table.Add(new UtilityPageRows(element, driver));
            }
        }       

        public UtilityPageRows GetFirstRow()
        {
            return table.First();
        }

        public UtilityPageRows GetLastRow()
        {
            return table.Last();
        }

        public List<UtilityPageRows> GetAllRows()
        {
            return table;
        }
    }
}
