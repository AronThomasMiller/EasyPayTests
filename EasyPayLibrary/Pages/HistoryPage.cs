using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPayLibrary
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
            btnCurrentMonth.ClickOnIt();
            return GetPOM<HistoryPage>(driver);
        }

        public bool IsHistoryCurrentMonthVisible()
        {
            var element = driver.GetByXpath("//table[@id='scheduleHistoryCurrent']//tbody//tr//td");
            return element.IsDisplayed();
            //td[contains(text(),'вулиця Весняна 96')]
        }

        public HistoryPage ClickOnPreviousMonthButton()
        {
            btnPreviousMonth.ClickOnIt();
            return GetPOM<HistoryPage>(driver);
        }

        public bool IsHistoryPreviousMonthVisible()
        {
            var element = driver.GetByXpath("//div[@class='tab-pane active']//span[contains(text(),'No schedule history yet')]");
            return element.IsDisplayed();
        }
    }
}
