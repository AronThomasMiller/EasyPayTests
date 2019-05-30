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

        public string fieldEmailText { get { return fieldEmail.GetAttribute("placeholder"); } }
        public string fieldPasswordText { get { return fieldPassword.GetAttribute("placeholder"); } }
        public string btnLoginText { get { return btnLogin.GetAttribute("value"); } }
        public string btnCreateAccountText { get { return btnCreateAccount.GetByXpath("./span").GetText(); } }
        public string NewToSiteText { get { return driver.GetByXpath("//*[@data-locale-item='newToSite']").GetText(); } }
        public string LostYourPassword { get { return driver.GetByXpath("//*[@data-locale-item='lostYourPassword']").GetText(); } }
        public string HeaderText { get { return driver.GetByXpath("//*[@data-locale-item='login']/span").GetText(); } }
        public string Or { get { return driver.GetByXpath("//*[@data-locale-item='or']/span").GetText(); } }
        public string FooterText { get { return driver.GetByXpath("//*[@data-locale-item='copyright']/span").GetText(); } }

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

        public RegisterPage NavigateToCreateAccountPage()
        {
            ClickOnCreateAccountButton();
            return GetPOM<RegisterPage>(driver);
        }
    }

}
