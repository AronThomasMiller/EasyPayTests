using EasyPayLibrary.Pages;

namespace EasyPayLibrary
{
    public class LoginPage : BasePageObject
    {
        WebElementWrapper fieldEmail;
        WebElementWrapper fieldPassword;
        WebElementWrapper btnLogin;

        public override void Init(DriverWrapper driver)
        {
            fieldEmail = driver.GetByXpath("//input[@id='email']");
            fieldPassword = driver.GetByXpath("//input[@id='password']");
            btnLogin = driver.GetByXpath("//input[@id='Login_button']");
            base.Init(driver);
        }

        public void SetEmail(string email)
        {
            fieldEmail.SendText(email);
        }

        public void SetPassword(string password)
        {
            fieldPassword.SendText(password);
        }

        public void ClickOnLoginButton()
        {
            btnLogin.ClickOnIt();
        }

        public BasePageObject Login(string email, string password)
        {
            SetEmail(email);
            SetPassword(password);
            ClickOnLoginButton();
            switch (HomePage.GetRole(driver))
            {
                case "USER": return GetPOM<HomePageUser>(driver);
                case "MANAGER": return GetPOM<HomePageUser>(driver);
            }
            return GetPOM<LoginPage>(driver);
        }



    }

}
