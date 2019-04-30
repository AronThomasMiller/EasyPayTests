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
            dropdownLanguage = driver.GetByXpath("//a[@class='dropdown-toggle user-profile']");
            base.Init(driver);
        }

        public void ClickOnProfileDropdown()
        {
            dropdownProfile = driver.GetByXpath("//a[@class='user-profile dropdown-toggle']");
            dropdownProfile.Click();
        }

        public void ClickOnLanguageDropdown ()
        {
            dropdownLanguage.ClickOnIt();
        }

        public void GoToProfile()
        {
            ClickOnProfileDropdown();
            btnProfile = driver.GetByXpath("//a[@href='/profile']");                       
            btnProfile.Click();
            return GetPOM<ProfilePage>(driver);
        }

        public void LogOut()
        {
            ClickOnProfileDropdown();
            btnLogOut = driver.GetByXpath("//a[@href='/logout']");
            btnLogOut.Click();
        }    
        
        public void ChangeToUa()
        {
            ClickOnLanguageDropdown();
            btnUA = driver.GetByXpath("//a[@href='/profile']");
            btnUA.ClickOnIt();
        }
    }
}