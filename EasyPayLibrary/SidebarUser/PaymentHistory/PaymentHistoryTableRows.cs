using System;
using System.Threading;

namespace EasyPayLibrary
{
    public class PaymentHistoryTableRow:BaseRow
    {
        string lblDate;
        string lblSum;
        WebElementWrapper btnViewCheck;

        public PaymentHistoryTableRow(WebElementWrapper element)
        {
            lblDate = element.GetByXpath(".//td[@class='historyDate']").GetText();
            lblSum = element.GetByXpath(".//td[@class='historySum']").GetText();
            btnViewCheck = element.GetByXpath(".//td[@class='historyView']/a");
        }

        public DateTime GetDateFromRow()
        {
            return Convert.ToDateTime(lblDate);
        }

        public float GetSumFromRow()
        {
            return Convert.ToSingle(lblSum.Replace(".",","));
        }

        public void ViewCheck()
        {
            btnViewCheck.Click();
        }

        public override bool Equals(object obj)
        {
            if (!(obj is PaymentHistoryTableRow)) return false;

            return (((PaymentHistoryTableRow)obj).GetDateFromRow() == GetDateFromRow() && ((PaymentHistoryTableRow)obj).GetSumFromRow() == GetSumFromRow());
        }

        public int DaysInDateOfPay()
        {
            var firstDate = new DateTime(2000, 1, 17);
            var secondDate = GetDateFromRow();
            TimeSpan difference = firstDate - secondDate;
            return difference.Days;
        }

        public override int GetHashCode()
        {
            return (int)(GetSumFromRow() * 100) ^ DaysInDateOfPay();
        }
    }
}