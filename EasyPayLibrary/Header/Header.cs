namespace EasyPayLibrary
{
    public class Header:BasePageObject
    {
        WebElementWrapper btnProfile;
        WebElementWrapper btnLogOut;
        WebElementWrapper dropdownProfile;

        //WebElementWrapper btnEN;
        WebElementWrapper btnUA;
        WebElementWrapper dropdownLanguage;

        public override void Init(DriverWrapper driver)
        {
            dropdownProfile = driver.GetByXpath("//a[@class='user-profile dropdown-toggle']");
            dropdownLanguage = driver.GetByXpath("//a[@class='dropdown-toggle user-profile']");
            base.Init(driver);
        }

        public void ClickOnProfileDropdown()
        {
            dropdownProfile.ClickOnIt();
        }

        public void ClickOnLanguageDropdown ()
        {
            dropdownLanguage.ClickOnIt();
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
        
        public void ChangeToUa()
        {
            ClickOnLanguageDropdown();
            btnUA = driver.GetByXpath("//a[@href='/profile']");
            btnUA.ClickOnIt();
        }
    }
}