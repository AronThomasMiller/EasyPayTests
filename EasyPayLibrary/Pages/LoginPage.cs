using System;

namespace EasyPayLibrary
{
    public class LoginPage : BasePageObject
    {
        WebElementWrapper fieldEmail;
        WebElementWrapper fieldPassword;
        WebElementWrapper btnLogin;
        WebElementWrapper errorAlert;


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

        public UsersHomePage Login(string email, string password)
        {
            SetEmail(email);
            SetPassword(password);
            ClickOnLoginButton();            
            return GetPOM<UsersHomePage>(driver);
        }

        public bool IsErrorPresent()
        {
            try
            {
                errorAlert = driver.GetByXpath("//*[@class='alert ui-pnotify-container alert-danger ui-pnotify-shadow']");
                return errorAlert.IsDisplayed();
            }
            catch (OpenQA.Selenium.NoSuchElementException ex)
            {}
            return false;            
        }
    }
}
