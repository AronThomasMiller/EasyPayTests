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
        
        LanguageChanger language;
        
        public override void Init(DriverWrapper driver)
        {
            
            language = GetPOM<LanguageChanger>(driver);
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

        public string GetName(string value)
        {
            
            return nameInput.GetAttribute(value);
        }

        public string GetSurname(string value)
        {
            return surnameInput.GetAttribute(value);
        }

        public string GetPhoneNumber(string value)
        {
            return phoneNumberInput.GetAttribute(value);
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

        public void SetValue(string text)
        {
            nameInput.SendText(text);
        }

        public LanguageChanger ChangeToUKR()
        {
            language.ChangeToUA();
            return GetPOM<LanguageChanger>(driver);
        }
        public bool TranslateToUA(string value)
        {
            Translation translation = new Translation();
            return translation.CheckUA(value);
        }
    }
}