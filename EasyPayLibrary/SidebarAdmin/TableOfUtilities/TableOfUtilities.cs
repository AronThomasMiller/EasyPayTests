using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPayLibrary
{
    public class TableOfUtilities:BasePageObject
    {
        List<RowOfTableUtilities> table;

        public override void Init(DriverWrapper driver)
        {
            List<WebElementWrapper> tableOnPage;
            table = new List<RowOfTableUtilities>();
            try
            {
                tableOnPage = driver.GetElementsByXpath("//tbody[@id='users-table']//tr");
            }
            catch (WebDriverTimeoutException)
            {
                return;
            }

            foreach (var element in tableOnPage)
            {
                table.Add(new RowOfTableUtilities(element, driver));
            }
        }

        public RowOfTableUtilities GetRowByUtilities(string myUtilities)
        {
            foreach (var element in table)
            {
                if (element.getNameCompany() == myUtilities)
                {
                    return element;
                }
            }
            return null;
        }

        public List<RowOfTableUtilities> GetAllRows()
        {
            return table;
        }
    }
}
