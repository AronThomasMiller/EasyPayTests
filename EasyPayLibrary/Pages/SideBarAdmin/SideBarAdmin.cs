namespace EasyPayLibrary
{
    internal class SideBarAdmin:SidebarBase
    {
        WebElementWrapper role;
        WebElementWrapper utilities;
        WebElementWrapper users;
        WebElementWrapper registerUser;

        public override void Init(DriverWrapper driver)
        {
            base.Init(driver);
            role = driver.GetByXpath("//div[@class='menu_section']/h3");
            utilities = sidebar[0];
            users = sidebar[1];
            registerUser = sidebar[2];       
        }

        public string GetTextRole()
        {
            var result = role.GetText();
            return result;
        }

        public void ClickOnUtilities()
        {
            utilities.ClickOnIt();
        }

        public void ClickOnUsers()
        {
            users.ClickOnIt();
        }

        public void ClickOnRegisterUser()
        {
            registerUser.ClickOnIt();
        }
    }
}