namespace EasyPayLibrary
{
    internal class SidebarAdmin : SidebarBase
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
            return role.GetText();
        }

        public void ClickOnUtilities()
        {
            utilities.Click();
        }

        public void ClickOnUsers()
        {
            users.Click();
        }

        public void ClickOnRegisterUser()
        {
            registerUser.Click();
        }
    }
}