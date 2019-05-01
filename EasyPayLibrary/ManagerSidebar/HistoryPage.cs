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
            var element = driver.GetByXpath($"//td[contains(text(),'{address}')]/following-sibling::td[text()='{date}']");
            return element.IsDisplayed();            
        }

        public HistoryPage ClickOnPreviousMonthButton()
        {
            btnPreviousMonth.Click();
            return GetPOM<HistoryPage>(driver);
        }

        public bool IsHistoryPreviousMonthVisible(string date)
        {
            var element = driver.GetByXpath($"//*[contains(text(),'{date}')]");
            return element.IsDisplayed();
        }
    }
}
