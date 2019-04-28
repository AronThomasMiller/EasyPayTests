using EasyPayLibrary.Pages.UnauthorizedUserPages;
using EasyPayLibrary.Pages.UnauthorizedUserPages.Gmail;
using System.Threading;

namespace EasyPayLibrary.Pages.Common
{
    public class RegisterPage:BasePageObject
    {
        WebElementWrapper fieldName;
        WebElementWrapper fieldSurname;
        WebElementWrapper fieldPhoneNumber;
        WebElementWrapper fieldEmail;
        WebElementWrapper fieldPassword;
        WebElementWrapper fieldConfirmPassword;

        WebElementWrapper btnSubmit;

        public override void Init(DriverWrapper driver)
        {
            base.Init(driver);
            fieldName = driver.GetByXpath("//input[@id='name']");
            fieldSurname = driver.GetByXpath("//input[@id='surname']");
            fieldPhoneNumber = driver.GetByXpath("//input[@id='phone']");
            fieldEmail = driver.GetByXpath("//input[@id='email']");
            fieldPassword = driver.GetByXpath("//input[@id='password']");
            fieldConfirmPassword = driver.GetByXpath("//input[@id='confirm']");

            btnSubmit = driver.GetByXpath("//input[@id='submit-btn']");
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
            btnSubmit.ClickOnIt();
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
            
            driver.GoToURL("https://accounts.google.com");
            return GetPOM<GmailEmailPage>(driver);
        }
    }
}
