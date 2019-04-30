using EasyPayLibrary.Pages.Common;
using System.Collections.Generic;

namespace EasyPayLibrary
{
    public class WelcomePage:BasePageObject
    {
        WebElementWrapper btnSignIn;
        WebElementWrapper btnSignUp;

        WebElementWrapper LeadText;

        public override void Init(DriverWrapper driver)
        {
            LeadText = driver.GetByXpath("//p[@class='lead']/span");

            btnSignIn = driver.GetByXpath("//a[@id='Sign_in']");
            btnSignUp = driver.GetByXpath("//a[@id='Sign_up']");

            base.Init(driver);
        }

        public void ClickOnSignInButton()
        {
            btnSignIn.Click();
        }

        public void ClickOnSignUpButton()
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

        public override List<string> GetTextElements()
        {
            var list = new List<string>
            {
                LeadText.GetText(),
                btnSignIn.GetByXpath(".//span").GetText(),
                btnSignUp.GetByXpath(".//span").GetText()
            };

            return list;
        }
    }
}
