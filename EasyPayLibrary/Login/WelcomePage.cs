using EasyPayLibrary.Pages.Common;
using System.Collections.Generic;

namespace EasyPayLibrary
{
    public class WelcomePage:BasePageObject
    {
        WebElementWrapper btnSignIn;
        WebElementWrapper btnSignUp;

        WebElementWrapper lblLead;

        public string btnSignInText => btnSignIn.GetByXpath("./span").GetText();
        public string btnSignUpText => btnSignUp.GetByXpath("./span").GetText();
        public string lblLeadText => lblLead.GetText();
        public string FooterText => driver.GetByXpath("//*[@class='mastfoot']/div[@class='inner']//p[2]").GetText();

        public override void Init(DriverWrapper driver)
        {
            lblLead = driver.GetByXpath("//p[@class='lead']");

            btnSignIn = driver.GetByXpath("//a[@id='Sign_in']");
            btnSignUp = driver.GetByXpath("//a[@id='Sign_up']");

            base.Init(driver);
        }

        private void ClickOnSignInButton()
        {
            btnSignIn.Click();
        }

        private void ClickOnSignUpButton()
        {
            btnSignUp.Click();
        }

        public LoginPage SignIn()
        {
            ClickOnSignInButton();            
            return  GetPOM<LoginPage>(driver);
        }

        public RegisterPage SignUp()
        {
            ClickOnSignUpButton();
            return GetPOM<RegisterPage>(driver);
        }

        public WelcomePage TranslatePageToUA()
        {
            return TranslatePageToUA<WelcomePage>(driver);
        }

        public WelcomePage TranslatePageToEN()
        {
            return TranslatePageToEN<WelcomePage>(driver);
        }
    }
}
