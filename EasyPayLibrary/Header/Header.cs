namespace EasyPayLibrary
{
    public class Header:BasePageObject
    {
        public WebElementWrapper btnProfile;
        public WebElementWrapper btnLogOut;
        public WebElementWrapper dropdownProfile;

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
            btnProfile = driver.GetByXpath("//a[@href='/profile']");
            ClickOnProfileDropdown();             
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