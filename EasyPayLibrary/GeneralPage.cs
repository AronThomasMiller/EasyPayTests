namespace EasyPayLibrary
{
    public class GeneralPage:BasePageObject
    {
        protected Header header;
        //HeaderPOM Header { get; set; }
        
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
            return driver.GetByXpath("//div[@class='menu_section']//h3").GetText();
        }

    }
}