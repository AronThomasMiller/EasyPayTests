using EasyPayLibrary.HomePages;
using EasyPayLibrary.Pages.Manager;
using EasyPayLibrary.Pages.UnauthorizedUserPages;
using EasyPayLibrary.Pages.UnauthorizedUserPages.Gmail;
using OpenQA.Selenium;
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
                RedirectModalWindow.ClickOnRedirectButton(driver, 1);
                return GetPOM<GmailEmailPage>(driver);
            }
            catch (WebDriverTimeoutException)
            {
                switch (GeneralPage.GetRole(driver))
                {
                    case "USER":
                    case "КОРИСТУВАЧ":
                        return GetPOM<HomePageUser>(driver);
                    case "MANAGER":
                    case "МЕНЕДЖЕР":
                        return GetPOM<HomePageManager>(driver);
                    case "ADMIN":
                    case "АДМІНІСТРАТОР":
                        return GetPOM<HomePageAdmin>(driver);
                    case "INSPECTOR":
                    case "КОНТРОЛЕР":
                        return GetPOM<HomePageInspector>(driver);
                    case null:
                        return GetPOM<LoginPage>(driver);
                }

            }
            return GetPOM<LoginPage>(driver);

        }

        public LoginPage TranslatePageToUA()
        {
            return TranslatePageToUA<LoginPage>(driver);
        }

        public LoginPage TranslatePageToEN()
        {
            return TranslatePageToEN<LoginPage>(driver);
        }
        public bool IsErrorPresent()
        {
            try
            {
                errorAlert = driver.GetByXpath("//*[@class='alert ui-pnotify-container alert-danger ui-pnotify-shadow']");
                return true;
            }
            catch (TimeoutException)
            {
                return false;
            }
        }
    }

}
