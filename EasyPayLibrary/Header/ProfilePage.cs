using EasyPayLibrary.Pages;
using EasyPayLibrary.Pages.Base;
using OpenQA.Selenium;

namespace EasyPayLibrary
{
    public class ProfilePage : GeneralPage
    {
        WebElementWrapper title;
        WebElementWrapper nameInput;
        WebElementWrapper surnameInput;
        WebElementWrapper phoneNumberInput;
        WebElementWrapper password;
        WebElementWrapper newPassword;
        WebElementWrapper confirmPassword;
        WebElementWrapper errorAlert;
        WebElementWrapper successAlert;
        //WebElementWrapper imageSelect;
        WebElementWrapper btnUpdateProfile;



        public override void Init(DriverWrapper driver)
        {
            base.Init(driver);
            
            nameInput = driver.GetByXpath("//input[@id = 'name']");
            surnameInput = driver.GetByXpath("//input[@id = 'surname']");
            phoneNumberInput = driver.GetByXpath("//input[@id='phone-number']");
            password = driver.GetByXpath("//input[@id='password']");
            newPassword = driver.GetByXpath("//input[@id='new-password']");
            confirmPassword = driver.GetByXpath("//input[@id='password-repeat']");
            btnUpdateProfile = driver.GetByXpath("//button[@id='submit-button']");
            title = driver.GetByXpath("//div[@class='title_left']//span");
            //imageSelect = driver.GetByXpath("//input[@id='image-file']");
        }

        public bool NameIsVisible()
        {
            return nameInput.IsDisplayed();
        }
        public bool SurnameIsVisible()
        {
            return surnameInput.IsDisplayed();
        }
        public bool PhoneNumberIsVisible()
        {
            return phoneNumberInput.IsDisplayed();
        }

        public string GetName()
        {
            return nameInput.GetAttribute("value");
        }

        public string GetSurname()
        {
            return surnameInput.GetAttribute("value");
        }

        public string GetPhoneNumber()
        {
            return phoneNumberInput.GetAttribute("value");
        }

        public string GetTitle()
        {           
            return title.GetText();
        }

        public void SetName(string firstName)
        {
            nameInput.SendText(firstName);
        }

        public void SetSurName(string secondName)
        {
            surnameInput.SendText(secondName);
        }

        public void SetPhoneNumber(string phone)
        {
            phoneNumberInput.SendText(phone);
        }

        public void SetPassword(string pass)
        {
            password.SendText(pass);
        }

        public void SetNewPassword(string newpass)
        {
            newPassword.SendText(newpass);
        }

        public void SetConfirmPassword(string newpass)
        {
            confirmPassword.SendText(newpass);
        }

        public void ClickOnUpdateProfile()
        {
            btnUpdateProfile.Click();
            btnUpdateProfile.Click();
            //btnUpdateProfile.SendText(Keys.Enter);
        }

        public ProfilePage UpdateProfile()
        {
            ClickOnUpdateProfile();
            return GetPOM<ProfilePage>(driver);
        }

        public string GetSuccessText()
        {
            WebElementWrapper success = driver.GetByXpath("//h4[@class='ui-pnotify-title']");
            return success.GetText();
        }

        public bool IsErrorAlertDisplayed()
        {
            errorAlert = driver.GetByXpath("//*[@class='alert ui-pnotify-container alert-danger ui-pnotify-shadow']");
            return errorAlert.IsDisplayed();
        }

        public bool IsSuccessAlertDisplayed()
        {
            successAlert = driver.GetByXpath("//*[@class='alert ui-pnotify-container alert-success ui-pnotify-shadow']");
            return successAlert.IsDisplayed();
        }

        public void EditPassword(string pass, string newpass)
        {
            SetPassword(pass);
            SetNewPassword(newpass);
            SetConfirmPassword(newpass);
            ClickOnUpdateProfile();
        }
        public void EditData(string firstName, string secondName, string phone, string pass, string newpass)
        {
            SetName(firstName);
            SetSurName(secondName);
            SetPhoneNumber(phone);
            EditPassword(pass, newpass);
            ClickOnUpdateProfile();
        }

        public ProfilePage ChangeToUKR()
        {
            header.ChangeToUa();
            return GetPOM<ProfilePage>(driver);
        }
        //public void SetImage()
        //{
        //    imageSelect.SendText(@"C:\Users\Maxim\Desktop\11.jpg");
        //}
    }
}