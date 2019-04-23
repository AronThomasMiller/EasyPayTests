namespace EasyPayLibrary
{
    public class Header:BasePageObject
    {
        WebElementWrapper btnProfile;
        WebElementWrapper btnLogOut;
        WebElementWrapper dropdownProfile;

        public override void Init(DriverWrapper driver)
        {
            btnProfile = driver.GetByXpath("//a[@href='/profile']");
            btnLogOut = driver.GetByXpath("//a[@href='/logout']");
            dropdownProfile = driver.GetByXpath("//a[@class='user-profile dropdown-toggle']");
            base.Init(driver);
        }

        public void ClickOnProfileDropdown()
        {
            dropdownProfile.ClickOnIt();
        }

        public void GoToProfile()
        {
            ClickOnProfileDropdown();             
            btnProfile.ClickOnIt();
        }

        public void LogOut()
        {
            ClickOnProfileDropdown();  
            btnLogOut.ClickOnIt();
        }       
    }
}