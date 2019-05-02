using EasyPayLibrary.Pages;
using OpenQA.Selenium;

namespace EasyPayLibrary
{
    public abstract class GeneralPage:BasePageObject
    {
        protected Header header;
        
        public override void Init(DriverWrapper driver)
        {
            header = GetPOM<Header>(driver);
            base.Init(driver);
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

        public static string GetRole(DriverWrapper driver)
        {
            try
            {
                return driver.GetByXpath("//div[@class='menu_section']//h3", 2).GetText();
            }
            catch (WebDriverTimeoutException)
            {
                return null;
            }
        }
    }
}