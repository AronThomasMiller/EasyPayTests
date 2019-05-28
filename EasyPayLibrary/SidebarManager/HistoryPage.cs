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
            btnCurrentMonth = driver.GetByXpath("//*[text()='Current month']");
            btnPreviousMonth = driver.GetByXpath("//*[text()='Previous month']");
            base.Init(driver);
        }

        public HistoryPage ClickOnCurrentMonthButton()
        {
            btnCurrentMonth.Click();
            return GetPOM<HistoryPage>(driver);
        }

        public bool IsHistoryCurrentMonthVisible(string address,string date)
        {
            WebElementWrapper element;
            try
            {
                element = driver.GetByXpath($"//table[@id='scheduleHistoryCurrent']//td[contains(text(),'{address}')]/following-sibling::td[contains(text(),'{date}')]");
            }
            catch (WebDriverTimeoutException)
            {
                return false;
            }
            return true;
        }

        public HistoryPage ClickOnPreviousMonthButton()
        {
            btnPreviousMonth.Click();
            return GetPOM<HistoryPage>(driver);
        }

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
