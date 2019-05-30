using EasyPayLibrary.Pages.UnauthorizedUserPages;
using EasyPayLibrary.Pages.UnauthorizedUserPages.Gmail;
using System.Collections.Generic;
using System.Threading;

namespace EasyPayLibrary.Pages.Common
{
    public class RegisterPage:BasePageObject
    {
        WebElementWrapper header;
        WebElementWrapper footer;

        WebElementWrapper fieldName;
        WebElementWrapper fieldSurname;
        WebElementWrapper fieldPhoneNumber;
        WebElementWrapper fieldEmail;
        WebElementWrapper fieldPassword;
        WebElementWrapper fieldConfirmPassword;

        WebElementWrapper btnSubmit;
        WebElementWrapper btnSignIn;


        public string headerText { get { return header.GetText(); } }
        public string footerText { get { return footer.GetByXpath("./span").GetText(); } }
        public string fieldNameText { get { return fieldName.GetAttribute("placeholder"); } }
        public string fieldSurnameText { get { return fieldSurname.GetAttribute("placeholder"); } }
        public string fieldEmailText { get { return fieldEmail.GetAttribute("placeholder"); } }
        public string fieldPasswordText { get { return fieldPassword.GetAttribute("placeholder"); } }
        public string fieldConfirmPasswordText { get { return fieldConfirmPassword.GetAttribute("placeholder"); } }
        public string btnSubmitText { get { return btnSubmit.GetAttribute("value"); } }
        public string btnSignInText { get { return btnSignIn.GetByXpath("./span").GetText(); } }

        public override void Init(DriverWrapper driver)
        {
            base.Init(driver);

            header = driver.GetByXpath("//h1[@id='registrationName']");
            footer = driver.GetByXpath("//span[@data-locale-item='haveAnAccount']");

            fieldName = driver.GetByXpath("//input[@id='name']");
            fieldSurname = driver.GetByXpath("//input[@id='surname']");
            fieldPhoneNumber = driver.GetByXpath("//input[@id='phone']");
            fieldEmail = driver.GetByXpath("//input[@id='email']");
            fieldPassword = driver.GetByXpath("//input[@id='password']");
            fieldConfirmPassword = driver.GetByXpath("//input[@id='confirm']");

            btnSubmit = driver.GetByXpath("//input[@id='submit-btn']");
            btnSignIn = driver.GetByXpath("//a[@data-locale-item='signIn']");
        }

        void SetName(string name)
        {
            fieldName.SendText(name);
        }

        void SetSurname(string surName)
        {
            fieldSurname.SendText(surName);
        }

        void SetPhoneNumber(string phoneNumber)
        {
            fieldPhoneNumber.SendText(phoneNumber);
        }

        void SetEmail(string email)
        {
            fieldEmail.SendText(email);
        }

        void SetPassword(string password)
        {
            fieldPassword.SendText(password);
        }

        void SetConfirmPassword(string password)
        {
            fieldConfirmPassword.SendText(password);
        }

        void ClickOnSubmitButton()
        {
            btnSubmit.Click();
        }
        
        public GmailEmailPage Register(string name, string surName, string phoneNumber, string email, string password)
        {
            SetName(name);
            SetSurname(surName);
            SetPhoneNumber(phoneNumber);
            SetEmail(email);
            SetPassword(password);
            SetConfirmPassword(password);

            ClickOnSubmitButton();

            RedirectModalWindow.ClickOnRedirectButton(driver,10);
            
            return GetPOM<GmailEmailPage>(driver);
        }
        
        public RegisterPage TranslatePageToUA()
        {
            return TranslatePageToUA<RegisterPage>(driver);
        }

        public RegisterPage TranslatePageToEN()
        {
            return TranslatePageToEN<RegisterPage>(driver);
        }
    }
}
