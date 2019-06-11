using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPayLibrary
{
    public class TableOfUsers:BasePageObject
    {
        List<RowOfTableUser> table;

        public override void Init(DriverWrapper driver)
        {
            List<WebElementWrapper> tableOnPage;
            table = new List<RowOfTableUser>();
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
                table.Add(new RowOfTableUser(element, driver));
            }
        }

        public RowOfTableUser GetRowByEmail(string myEmail)
        {
            foreach (var element in table)
            {
                if (element.GetEmail() == myEmail)
                {
                    return element;
                }
            }
            return null;
        }

        public RowOfTableUser getSpecialRow()
        {

            return GetPOM<RowOfTableUser>(driver);
        }

        public List<RowOfTableUser> GetAllRows()
        {
            return table;
        }
    }
}
