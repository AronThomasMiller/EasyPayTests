namespace EasyPayLibrary
{
    public class HomePageAdmin : GeneralPage
    {
        SideBarAdmin sidebar;
        public override void Init(DriverWrapper driver)
        {
            base.Init(driver);
            sidebar = GetPOM<SideBarAdmin>(driver);
        }
        public string GetTextRole()
        {
            return sidebar.GetTextRole();
        }

        public Utilities ClickOnUtilities()
        {
            sidebar.ClickOnUtilities();
            return GetPOM<Utilities>(driver);
        }

        public Users ClickOnUsers()
        {
            sidebar.ClickOnUsers();
            return GetPOM<Users>(driver);
        }

        public RegisterUser ClickOnRegisterUser()
        {
            sidebar.ClickOnRegisterUser();
            return GetPOM<RegisterUser>(driver);
        }
    }
}