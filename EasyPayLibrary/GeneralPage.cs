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
                var role = driver.GetByXpath("//*[@class='menu_section']/h3");
                return role.GetText();
            }
            catch (OpenQA.Selenium.NoSuchElementException)
            { }
            return "Login";
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