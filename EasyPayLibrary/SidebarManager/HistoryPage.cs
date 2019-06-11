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
            base.Init(driver);
            btnCurrentMonth = driver.GetByXpath("//*[@data-locale-item='currentMonth']");
            btnPreviousMonth = driver.GetByXpath("//*[@data-locale-item='previousMonth']");
        }

        public HistoryPage ClickOnCurrentMonthButton()
        {
            btnCurrentMonth.Click();
            return GetPOM<HistoryPage>(driver);
        }

        public bool CurrentMonthContainsAddress(string address, string date)
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

        public HistoryPage ClickOnPreviousMonthButton()
        {
            btnPreviousMonth.Click();
            return GetPOM<HistoryPage>(driver);
        }

        public bool PreviousMonthContainsAddress(string date)
        {
            try
            {
                var element = driver.GetByXpath($"//*[contains(text(),'{date}')]", 1);
                return true;
            }
            catch (WebDriverTimeoutException)
            {
                return false;
            }
        }
    }
}
