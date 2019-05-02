using System.Collections.Generic;

namespace EasyPayLibrary
{
    internal class PaymentHistoryTable:BasePageObject
    {
        List<PaymentHistoryTableRows> table;

        public override void Init(DriverWrapper driver)
        {
            base.Init(driver);
            List<WebElementWrapper> tableOnPage = driver.GetElementsByXpath("//tbody/tr");
            table = new List<PaymentHistoryTableRows>();

            foreach (var element in tableOnPage)
            {
                table.Add(new PaymentHistoryTableRows(element));
            }           
        }

        public PaymentHistoryTableRows GetLastRow()
        {
            return table[table.Count-1];
        }

        public string GetLastPayInString()
        {
            PaymentHistoryTableRows last = GetLastRow();
            return last.GetDateFromRow() + "_" + last.GetSumFromRow();
        }
    }
}