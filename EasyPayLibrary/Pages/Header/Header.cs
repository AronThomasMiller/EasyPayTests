namespace EasyPayLibrary
{
    public class Header:BasePageObject
    {
        WebElementWrapper btnProfile;
        WebElementWrapper btnLogOut;
        WebElementWrapper dropdownProfile;

        public override void Init(DriverWrapper driver)
        {            
            base.Init(driver);
        }

        public void ClickOnProfileDropdown()
        {
            dropdownProfile = driver.GetByXpath("//a[@class='user-profile dropdown-toggle']");
            dropdownProfile.ClickOnIt();
        }

        public ProfilePage GoToProfile()
        {
            ClickOnProfileDropdown();
            btnProfile = driver.GetByXpath("//a[@href='/profile']");                       
            btnProfile.ClickOnIt();
            return GetPOM<ProfilePage>(driver);
        }

        public void LogOut()
        {
            ClickOnProfileDropdown();
            btnLogOut = driver.GetByXpath("//a[@href='/logout']");
            btnLogOut.ClickOnIt();
        }       
    }
}