using EasyPayLibrary.Pages;
using EasyPayLibrary.Pages.Manager;
using EasyPayLibrary.Pages.UnauthorizedUserPages;
using EasyPayLibrary.Pages.UnauthorizedUserPages.Gmail;
using OpenQA.Selenium;

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

            try
            {
                RedirectModalWindow.ClickOnRedirectButton(driver,1);
                driver.GoToURL("https://accounts.google.com");
                return GetPOM<GmailEmailPage>(driver);
            }
            catch (WebDriverTimeoutException)
            {
                switch (GeneralPage.GetRole(driver))
                {
                    case "USER": return GetPOM<HomePageUser>(driver);
                    case "MANAGER": return GetPOM<HomePageManager>(driver);
                }
            }
            return GetPOM<BasePageObject>(driver);
        }
    }

}
