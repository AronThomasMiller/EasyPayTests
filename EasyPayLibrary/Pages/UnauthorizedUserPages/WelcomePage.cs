using EasyPayLibrary.Pages.Common;

namespace EasyPayLibrary
{
    public class WelcomePage:BasePageObject
    {
        WebElementWrapper btnSignIn;
        WebElementWrapper btnSignUp;

        public override void Init(DriverWrapper driver)
        {
            btnSignIn = driver.GetByXpath("//a[@id='Sign_in']");
            btnSignUp = driver.GetByXpath("//a[@id='Sign_up']");
            base.Init(driver);
        }

        public void ClickOnSignInButton()
        {
            btnSignIn.ClickOnIt();
        }

        public void ClickOnSignUpButton()
        {
            btnSignUp.ClickOnIt();
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
    }
}
