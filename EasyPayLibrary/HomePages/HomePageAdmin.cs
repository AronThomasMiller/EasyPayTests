namespace EasyPayLibrary
{
    public class HomePageAdmin : GeneralPage
    {
        SidebarAdmin sidebar;

        public override void Init(DriverWrapper driver)
        {
            base.Init(driver);
            sidebar = GetPOM<SidebarAdmin>(driver);         
        }

        public Utilities NavigateToUtilities()
        {
            sidebar.ClickOnUtilities();
            return GetPOM<Utilities>(driver);
        }

        public Users NavigateToUsers()
        {
            sidebar.ClickOnUsers();
            return GetPOM<Users>(driver);
        }

        public RegisterUser NavigateToRegisterUser()
        {
            sidebar.ClickOnRegisterUser();
            return GetPOM<RegisterUser>(driver);
        }
    }
}