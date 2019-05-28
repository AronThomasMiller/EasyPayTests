using EasyPayLibrary.Pages.Common;
using System.Collections.Generic;

namespace EasyPayLibrary
{
    public class WelcomePage:BasePageObject
    {
        WebElementWrapper btnSignIn;
        WebElementWrapper btnSignUp;

        WebElementWrapper Lead;

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

        public string this[string elementName]
        {
            get
            {
                switch (elementName)
                {
                    case "Lead": return Lead.GetText();
                    case "SignIn": return btnSignIn.GetByXpath("./span").GetText();
                    case "SignUp": return btnSignUp.GetByXpath("./span").GetText();
                    case "Footer": return driver.GetByXpath("//*[@class='mastfoot']/div[@class='inner']//p[2]").GetText();
                    default: return null;
                }
            }
        }
    }
}
