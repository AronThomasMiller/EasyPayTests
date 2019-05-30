namespace EasyPayLibrary
{
    public class SidebarAdmin : SidebarBase
    {
        WebElementWrapper utilities;
        WebElementWrapper users;
        WebElementWrapper registerUser;

        public override void Init(DriverWrapper driver)
        {
            base.Init(driver);
            utilities = driver.GetByXpath("//a[@href='/admin/utilitiesPage']");
            users = driver.GetByXpath("//a[@href='/admin/management-users']");
            registerUser = driver.GetByXpath("//a[@href='/admin/register-user']");       
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