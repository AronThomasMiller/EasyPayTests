using EasyPayLibrary.Pages;

namespace EasyPayLibrary
{
    public class ProfilePage : GeneralPage
    {
        WebElementWrapper nameInput;
        WebElementWrapper surnameInput;
        WebElementWrapper phoneNumberInput;
        WebElementWrapper labelName;
        WebElementWrapper changeAvatar;
        WebElementWrapper updateProfile;
        WebElementWrapper errorAlert;
        WebElementWrapper successAlert;
        
        LanguageChanger language;
        
        public override void Init(DriverWrapper driver)
        { 
            language = GetPOM<LanguageChanger>(driver);
            updateProfile = driver.GetByXpath("//*[@data-locale-item='updateProfile']");
            nameInput = driver.GetByXpath("//*[@id='name']");
            surnameInput = driver.GetByXpath("//*[@id='surname']");
            phoneNumberInput = driver.GetByXpath("//*[@id='phone-number']");            
            base.Init(driver);
        }

        public bool NameIsVisible()
        {
            return nameInput.IsDisplayed();
        }

        public bool SurnameIsVisible()
        {
            return nameInput.IsDisplayed();
        }

        public bool PhoneNumberIsVisible()
        {
            return nameInput.IsDisplayed();
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

        public string GetNameLabel()
        {
            labelName = driver.GetByXpath("//span[@data-locale-item='name']/span");
            return labelName.GetText();
        }
        public string GetChangeAvatarText()
        {
            changeAvatar = driver.GetByXpath("//*[@data-locale-item='changeAvatar']/span");
            return changeAvatar.GetText();
        }

        public void SetName(string text)
        {
            nameInput.SendText(text);
        }

        public LanguageChanger ChangeToUKR()
        {
            language.ChangeToUA();
            return GetPOM<LanguageChanger>(driver);
        }

        public void ClickOnUpdateProfile()
        {
            updateProfile.ClickOnIt();
        }

        public ProfilePage UpdateProfile()
        {
            ClickOnUpdateProfile();
            return GetPOM<ProfilePage>(driver);
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
       
    }
}