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
            List<WebElementWrapper> tbPayments;
            base.Init(driver);
            try
            {
                tbPayments = driver.GetElementsByXpath("//table[@id='historyTable']//tbody/tr",1);
            }
            catch (WebDriverTimeoutException)
            {
                Rows = new List<PaymentHistoryTableRow>();
                return;
            }

            Rows = tbPayments.Select(element => new PaymentHistoryTableRow(driver, element)).ToList();
        }
    }
}