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
            btnLogin.Click();
        }

        public BasePageObject Login(string email, string password)
        {
            SetEmail(email);
            SetPassword(password);
            ClickOnLoginButton();
            try
            {
                switch (GeneralPage.GetRole(driver))
                {
                    case "USER":
                    case "КОРИСТУВАЧ":
                        return GetPOM<UsersHomePage>(driver);
                    case "MANAGER":
                    case "МЕНЕДЖЕР":
                        return GetPOM<BasePageObject>(driver);
                    case "ADMIN":
                    case "АДМІНІСТРАТОР":
                        return GetPOM<HomePageAdmin>(driver);
                    case "INSPECTOR":
                    case "КОНТРОЛЕР":
                        return GetPOM<BasePageObject>(driver);
                    case "Login":
                        return GetPOM<LoginPage>(driver);
                }
            }
            catch (OpenQA.Selenium.NoSuchElementException) { }

            return GetPOM<LoginPage>(driver);
        }

        public bool IsErrorPresent()
        {
            try
            {
                base.Init(driver);
                errorAlert = driver.GetByXpath("//*[@class='alert ui-pnotify-container alert-danger ui-pnotify-shadow']");
                return errorAlert.IsDisplayed();
            }
            catch (OpenQA.Selenium.NoSuchElementException)
            {}
            return false;            
        }
    }
}
