namespace EasyPayLibrary
{
    public class Header:BasePageObject
    {
        WebElementWrapper btnProfile;
        WebElementWrapper btnLogOut;
        WebElementWrapper dropdownProfile;

        public override void Init(DriverWrapper driver)
        {
            dropdownProfile = driver.GetByXpath(".//li[@id='user-menu-header']//a[@class='user-profile dropdown-toggle']");
            base.Init(driver);
        }

        public void ClickOnProfileDropdown()
        {
            dropdownProfile.ClickOnIt();
        }

        public void GoToProfile()
        {
            ClickOnProfileDropdown();
            btnProfile = driver.GetByXpath("//a[@href='/profile']");
            btnProfile.ClickOnIt();
        }

        public void LogOut()
        {
            ClickOnProfileDropdown();
            btnLogOut = driver.GetByXpath("//a[@href='/logout']");
            btnLogOut.ClickOnIt();
        }       
    }
}