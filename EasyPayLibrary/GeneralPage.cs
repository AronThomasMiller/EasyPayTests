namespace EasyPayLibrary
{
    public class GeneralPage : BasePageObject
    {
        protected ManagerSidebar managerSidebar;
        protected Header header;

        public override void Init(DriverWrapper driver)
        {
            header = GetPOM<Header>(driver);
            managerSidebar = GetPOM<ManagerSidebar>(driver);
            base.Init(driver);
        }

        public LoginPage LogOut()
        {
            header.LogOut();
            return GetPOM<LoginPage>(driver);
        }

        public InspectorsListPage ClickInspectorsPage()
        {
            managerSidebar.ClickOnInspectorsButton();
            return GetPOM<InspectorsListPage>(driver);
        }

        public InspectorsListPage GetPrices()
        {
            managerSidebar.ClickOnUtilityPriceButton();
            return GetPOM<InspectorsListPage>(driver);
        }

        public UtilityPricePage ClickUtilityPricePage()
        {
            managerSidebar.ClickOnUtilityPriceButton();
            return GetPOM<UtilityPricePage>(driver);
        }
    }
}