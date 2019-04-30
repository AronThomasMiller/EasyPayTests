using EasyPayLibrary.Pages;
using EasyPayLibrary.Pages.Inspector;
using System.Threading;

namespace EasyPayLibrary
{
    public class LoginPage : BasePageObject
    {
        public WebElementWrapper fieldEmail;
        public WebElementWrapper fieldPassword;
        public WebElementWrapper btnLogin;

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

        public void LoginIncorrect(string email, string password)
        {
            SetEmail(email);
            SetPassword(password);
            ClickOnLoginButton();
        }

        public HomePageInspector LoginInspector(string email, string password)
        {
            SetEmail(email);
            SetPassword(password);
            ClickOnLoginButton();
            return GetPOM<HomePageInspector>(driver);          
        }

        public HomePageUser LoginUser(string email, string password)
        {
            SetEmail(email);
            SetPassword(password);
            ClickOnLoginButton();
            return GetPOM<HomePageUser>(driver);
        }



    }

}
