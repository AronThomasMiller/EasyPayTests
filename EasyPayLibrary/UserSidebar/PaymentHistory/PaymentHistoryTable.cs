using OpenQA.Selenium;
using System;
using System.Collections.Generic;

namespace EasyPayLibrary
{
    public class PaymentHistoryTable:BasePageObject
    {
        List<PaymentHistoryTableRow> table;

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
            table = new List<PaymentHistoryTableRow>();

            foreach (var element in tableOnPage)
            {
                table.Add(new PaymentHistoryTableRow(element));
            }           
        }

        public PaymentHistoryTableRow GetLastRow()
        {
            return table?[table.Count - 1];
        }

        public List<PaymentHistoryTableRow> GetAllRows()
        {
            return table;
        }

        public string GetLastPayInString()
        {
            PaymentHistoryTableRow last = GetLastRow();
            return last.GetDateFromRow() + "_" + last.GetSumFromRow();
        }
    }
}