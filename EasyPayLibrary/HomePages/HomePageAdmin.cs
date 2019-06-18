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

        public UtilitiesPage NavigateToUtilities()
        {
            sidebar.ClickOnUtilities();
            return GetPOM<UtilitiesPage>(driver);
        }

        public UsersPage NavigateToUsers()
        {
            sidebar.ClickOnUsers();
            return GetPOM<UsersPage>(driver);
        }

        public RegisterUser NavigateToRegisterUser()
        {
            sidebar.ClickOnRegisterUser();
            return GetPOM<RegisterUser>(driver);
        }
    }
}