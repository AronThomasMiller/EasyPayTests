namespace EasyPayLibrary
{
    public class Header:BasePageObject
    {
        WebElementWrapper btnProfile;
        WebElementWrapper btnLogOut;
        WebElementWrapper dropdownProfile;

        public override void Init(DriverWrapper driver)
        {
            dropdownProfile = driver.GetByXpath("//li[@id='user-menu-header']/a");

            base.Init(driver);
        }

        public void ClickOnProfileDropdown()
        {
            dropdownProfile.Click();
        }

        public void GoToProfile()
        {
            ClickOnProfileDropdown();
            btnProfile = driver.GetByXpath("//a[@href='/profile']");          
            btnProfile.Click();
        }

        public void LogOut()
        {
            ClickOnProfileDropdown();
            btnLogOut = driver.GetByXpath("//a[@href='/logout']");
            btnLogOut.Click();
        }       
    }
}