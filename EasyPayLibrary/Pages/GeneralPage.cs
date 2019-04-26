namespace EasyPayLibrary
{
    public class GeneralPage:BasePageObject
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
    }
}