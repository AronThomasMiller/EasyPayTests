using EasyPayLibrary.Admin;
using EasyPayLibrary.Changes;
using EasyPayLibrary.Inspector;
using EasyPayLibrary.Manager;

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
            btnLogin.Click();
        }

        public BasePageObject Login(string email, string password)
        {

            SetEmail(email);
            SetPassword(password);
            ClickOnLoginButton();

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
            }
            
            return GetPOM<BasePageObject>(driver);
        }





    }

}
