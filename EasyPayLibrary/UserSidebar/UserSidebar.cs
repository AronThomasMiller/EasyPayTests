namespace EasyPayLibrary
{
    public class UserSidebar:BaseSidebar
    {
        public void ClickOnPayment()
        {
            sidebar[2].ClickOnIt();
        }

        public void ClickOnPaymentHistory()
        {
            sidebar[3].ClickOnIt();
        }
    }
}