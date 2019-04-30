namespace EasyPayLibrary
{
    public class HomePageUser:GeneralPage
    {
        UserSidebar sidebar;
        public override void Init(DriverWrapper driver)
        {
            base.Init(driver);
            sidebar = GetPOM<UserSidebar>(driver);
        }

        public PaymentPage NavigateToPayment()
        {
            sidebar.ClickOnPayment();
            return GetPOM<PaymentPage>(driver);
        }

        public PaymentHistory NavigateToPaymentHistory()
        {
            sidebar.ClickOnPaymentHistory();
            return GetPOM<PaymentHistory>(driver);
        }
    }
}