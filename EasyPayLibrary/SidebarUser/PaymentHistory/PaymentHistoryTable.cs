using OpenQA.Selenium;
using System;
using System.Linq;
using System.Collections.Generic;

namespace EasyPayLibrary
{
    public class PaymentHistoryTable:BaseTable<PaymentHistoryTableRow>
    {
        public override void Init(DriverWrapper driver)
        {
            List<WebElementWrapper> tableOnPage;
            base.Init(driver);
            try
            {
                tableOnPage = driver.GetElementsByXpath("//table[@id='historyTable']//tbody/tr",1);
            }
            catch (WebDriverTimeoutException)
            {
                return;
            }

            Rows = tableOnPage.Select(element => new PaymentHistoryTableRow(element)).ToList();
        }
    }
}