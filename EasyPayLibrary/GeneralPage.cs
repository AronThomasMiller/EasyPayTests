using OpenQA.Selenium;

namespace EasyPayLibrary
{
    public class GeneralPage : BasePageObject
    {
        protected Header header;        
        
        public override void Init(DriverWrapper driver)
        {
            header = GetPOM<Header>(driver);            
            base.Init(driver);
        }

        public static string GetRole(DriverWrapper driver)
        {
            try
            {
                GetPOM<BasePageObject>(driver);
                WebElementWrapper role = driver.GetByXpath("//*[@class='menu_section']/h3",1);
                return role.GetText();
            }
            catch (WebDriverTimeoutException)
            {
                return null;
            }            
        }
        
        public ProfilePage GoToProfile()
        {
            header.GoToProfile();
            return GetPOM<ProfilePage>(driver);
        }

        public LoginPage LogOut()
        {
            header.LogOut();
            return GetPOM<LoginPage>(driver);
        }
    }
}