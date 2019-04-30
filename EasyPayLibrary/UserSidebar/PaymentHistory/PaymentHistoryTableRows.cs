namespace EasyPayLibrary
{
    internal class PaymentHistoryTableRows:BasePageObject
    {
        WebElementWrapper row;
        
        public PaymentHistoryTableRows(WebElementWrapper element)
        {
            row = element;
        }

        public string GetDateFromRow()
        {
            return row.GetByXpath(".//td[@class='historyDate']").GetText();
        }

        public string GetSumFromRow()
        {
            return row.GetByXpath(".//td[@class='historySum']").GetText();
        }
    }
}