using System;

namespace EasyPayLibrary
{
    public class PaymentHistoryTableRow:BasePageObject
    {
        WebElementWrapper lblDate;
        WebElementWrapper lblSum;
        WebElementWrapper btnViewCheck;

        public PaymentHistoryTableRow(WebElementWrapper element)
        {
            lblDate = element.GetByXpath(".//td[@class='historyDate']");
            lblSum = element.GetByXpath(".//td[@class='historySum']");
            btnViewCheck = element.GetByXpath(".//td[@class='historyView']/a");
            base.Init(driver);
        }

        public DateTime GetDateFromRow()
        {
            return Convert.ToDateTime(lblDate.GetText());
        }

        public float GetSumFromRow()
        {
            return Convert.ToSingle(lblSum.GetText().Replace(".",","));
        }

        public void ViewCheck()
        {
            btnViewCheck.Click();
        }
    }
}