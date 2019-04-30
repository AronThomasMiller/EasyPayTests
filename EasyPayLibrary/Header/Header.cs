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

        public void GoToProfile()
        {
            ClickOnProfileDropdown();
            btnProfile = driver.GetByXpath("//a[@href='/profile']");                       
            btnProfile.ClickOnIt();
        }

        public void LogOut()
        {
            btnLogOut = driver.GetByXpath("//a[@href='/logout']");
            ClickOnProfileDropdown();  
            btnLogOut.ClickOnIt();
        }       
    }
}