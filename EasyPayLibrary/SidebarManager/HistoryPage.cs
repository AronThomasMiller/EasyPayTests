using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPayLibrary.ManagerSidebar
{
    public class HistoryPage : BasePageObject
    {
        WebElementWrapper btnCurrentMonth;
        WebElementWrapper btnPreviousMonth;

        public override void Init(DriverWrapper driver)
        {
            //Xpath By Text?
            btnCurrentMonth = driver.GetByXpath("//*[text()='Current month']");
            btnPreviousMonth = driver.GetByXpath("//*[text()='Previous month']");
            base.Init(driver);
        }

        public HistoryPage ClickOnCurrentMonthButton()
        {
            btnCurrentMonth.Click();
            return GetPOM<HistoryPage>(driver);
        }
        //history doesn't mean it contains specific address or date, you have to rename it, or to make another logic like find table with addresses of current month
        public bool IsHistoryCurrentMonthVisible(string address,string date)
        {
            WebElementWrapper element;
            try
            {
                element = driver.GetByXpath($"//table[@id='scheduleHistoryCurrent']//td[contains(text(),'{address}')]/following-sibling::td[contains(text(),'{date}')]");
                return true;
            }
            catch (WebDriverTimeoutException)
            {
                return false;
            }
        }
        //In this case you choose previous month or select, but not just click
        //you should to create separte POM for table of address(list of rows) which can navigate through 
        //pages of this table and make some logic with rows
        public HistoryPage ClickOnPreviousMonthButton()
        {
            btnPreviousMonth.Click();
            return GetPOM<HistoryPage>(driver);
        }
        //same as with current
        public bool IsHistoryPreviousMonthVisible(string date)
        {
            try
            {
                var element = driver.GetByXpath($"//*[contains(text(),'{date}')]",1);
                return true;
            }
            catch (WebDriverTimeoutException)
            {
                return false;
            }
        }
    }
}
