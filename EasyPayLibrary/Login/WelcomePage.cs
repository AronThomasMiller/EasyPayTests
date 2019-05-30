using EasyPayLibrary.Pages.Common;
using System.Collections.Generic;

namespace EasyPayLibrary
{
    public class WelcomePage:BasePageObject
    {
        WebElementWrapper btnSignIn;
        WebElementWrapper btnSignUp;

        WebElementWrapper Lead;

        public string btnSignInText { get { return btnSignIn.GetByXpath("./span").GetText(); } }
        public string btnSignUpText { get { return btnSignUp.GetByXpath("./span").GetText(); } }
        public string LeadText { get { return Lead.GetText(); } }
        public string FooterText { get { return driver.GetByXpath("//*[@class='mastfoot']/div[@class='inner']//p[2]").GetText(); } }

        public override void Init(DriverWrapper driver)
        {
            Lead = driver.GetByXpath("//p[@class='lead']");

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
