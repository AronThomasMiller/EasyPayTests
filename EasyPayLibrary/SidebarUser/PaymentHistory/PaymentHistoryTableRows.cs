using System;
using System.Threading;

namespace EasyPayLibrary
{
    public class PaymentHistoryTableRow:BaseRow
    {
        string lblDate;
        string lblSum;
        WebElementWrapper btnViewCheck;
        
        public PaymentHistoryTableRow(DriverWrapper driver, WebElementWrapper element)
        {
            lblDate = element.GetByXpath(".//td[@class='historyDate']").GetText();
            lblSum = element.GetByXpath(".//td[@class='historySum']").GetText();
            btnViewCheck = element.GetByXpath(".//td[@class='historyView']/a");
            base.Init(driver);
        }

        public DateTime Date => Convert.ToDateTime(lblDate);
        public float Sum => Convert.ToSingle(lblSum.Replace(".", ","));

        private void ClickOnViewCheckButton()
        {
            btnViewCheck.Click();
        }

        private void ViewCheck()
        {
            ClickOnViewCheckButton();
            driver.WaitUntillUrlContainString("drive.google.com", 20);
        }

        public CheckPDF GetCheck()
        {
            ViewCheck();
            return GetPOM<CheckPDF>(driver);
        }

        public override bool Equals(object obj)
        {
            if (!(obj is PaymentHistoryTableRow)) return false;

            var castedObj = ((PaymentHistoryTableRow)obj);
            return (castedObj.Date == Date && castedObj.Sum == Sum);
        }

        private int DaysInDateOfPay()
        {
            var firstDate = new DateTime(2000, 1, 1);
            var secondDate = Date;
            TimeSpan difference = firstDate - secondDate;
            return difference.Days;
        }

        public override int GetHashCode()
        {
            return ((int)(Sum * 100)) ^ DaysInDateOfPay();
        }
    }
}