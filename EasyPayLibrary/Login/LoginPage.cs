using EasyPayLibrary.HomePages;
using EasyPayLibrary.Pages.Common;
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
        WebElementWrapper btnCreateAccount;
        WebElementWrapper errorAlert;


        public override void Init(DriverWrapper driver)
        {
            fieldEmail = driver.GetByXpath("//input[@id='email']");
            fieldPassword = driver.GetByXpath("//input[@id='password']");
            btnLogin = driver.GetByXpath("//input[@id='Login_button']");
            btnCreateAccount = driver.GetByXpath("//a[@data-locale-item='createAccount']");
            base.Init(driver);
        }

        private void SetEmail(string email)
        {
            fieldEmail.SendText(email);
        }

        private void SetPassword(string password)
        {
            fieldPassword.SendText(password);
        }

        private void ClickOnLoginButton()
        {
            btnLogin.Click();
        }

        private void ClickOnCreateAccountButton()
        {
            btnCreateAccount.Click();
        }

        private void EnterEmailAndPasswordAndClickLogin(string email, string password)
        {
            SetEmail(email);
            SetPassword(password);
            ClickOnLoginButton();
        }

        public HomePageAdmin LoginAsAdmin(string email, string password)
        {
            EnterEmailAndPasswordAndClickLogin(email, password);
            return GetPOM<HomePageAdmin>(driver);
        }

        public HomePageManager LoginAsManager(string email, string password)
        {
            EnterEmailAndPasswordAndClickLogin(email, password);
            return GetPOM<HomePageManager>(driver);
        }

        public HomePageInspector LoginAsInspector(string email, string password)
        {
            EnterEmailAndPasswordAndClickLogin(email, password);
            return GetPOM<HomePageInspector>(driver);
        }

        public HomePageUser LoginAsUser(string email, string password)
        {
            EnterEmailAndPasswordAndClickLogin(email, password);
            return GetPOM<HomePageUser>(driver);
        }

        public LoginPage TryLoginWithInvalidData(string email, string password)
        {
            EnterEmailAndPasswordAndClickLogin(email, password);
            return GetPOM<LoginPage>(driver);
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

        public string this[string elementName]
        {
            get
            {
                switch (elementName)
                {
                    case "Email": return fieldEmail.GetAttribute("placeholder");
                    case "Password": return fieldPassword.GetAttribute("placeholder");
                    case "Login": return btnLogin.GetAttribute("value");
                    case "NewToSite": return driver.GetByXpath("//*[@data-locale-item='newToSite']").GetText();
                    case "CreateAccount": return btnCreateAccount.GetByXpath("./span").GetText();
                    case "LostYourPassword": return driver.GetByXpath("//*[@data-locale-item='lostYourPassword']").GetText();
                    case "Header": return driver.GetByXpath("//*[@data-locale-item='login']/span").GetText();
                    case "Or": return driver.GetByXpath("//*[@data-locale-item='or']/span").GetText();
                    case "Footer": return driver.GetByXpath("//*[@data-locale-item='copyright']/span").GetText();
                    default: return null;
                }
            }
        }

        public RegisterPage NavigateToCreateAccountPage()
        {
            ClickOnCreateAccountButton();
            return GetPOM<RegisterPage>(driver);
        }
    }

}
