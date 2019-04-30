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

        public override void Init(DriverWrapper driver)
        {
            base.Init(driver);

            header = driver.GetByXpath("//h1[@id='registrationName']");
            footer = driver.GetByXpath("//div[@class='separator']");

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

        public override List<string> GetTextElements()
        {
            var list = new List<string>
            {
                header.GetText(),
                footer.GetByXpath(".//span/span").GetText(),
                footer.GetByXpath(".//a/span").GetText(),
                
                fieldName.GetCssValue("placeholder"),
                fieldSurname.GetCssValue("placeholder"),
                fieldEmail.GetCssValue("placeholder"),
                fieldPassword.GetCssValue("placeholder"),
                fieldPassword.GetCssValue("placeholder")
            };

            return list;
        }
    }
}
