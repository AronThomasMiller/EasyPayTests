using OpenQA.Selenium;

namespace EasyPayLibrary
{
    public class ProfilePage : GeneralPage
    {
        WebElementWrapper title;
        WebElementWrapper name;
        WebElementWrapper surName;
        WebElementWrapper phoneNumber;
        WebElementWrapper password;
        WebElementWrapper newPassword;
        WebElementWrapper confirmPassword;
        //WebElementWrapper imageSelect;
        WebElementWrapper btnUpdateProfile;
        

        public override void Init(DriverWrapper driver)
        {
            base.Init(driver);
            
            name = driver.GetByXpath("//input[@id = 'name']");
            surName = driver.GetByXpath("//input[@id = 'surname']");
            phoneNumber = driver.GetByXpath("//input[@id='phone-number']");
            password = driver.GetByXpath("//input[@id='password']");
            newPassword = driver.GetByXpath("//input[@id='new-password']");
            confirmPassword = driver.GetByXpath("//input[@id='password-repeat']");
            btnUpdateProfile = driver.GetByXpath("//button[@id='submit-button']");
            title = driver.GetByXpath("//div[@class='title_left']//span");
            //imageSelect = driver.GetByXpath("//input[@id='image-file']");
        }

        public string GetTitle()
        {           
            return title.GetText();
        }

        public void SetName(string firstName)
        {
            name.SendText(firstName);
        }

        public void SetSurName(string secondName)
        {
            surName.SendText(secondName);
        }

        public void SetPhoneNumber(string phone)
        {
            phoneNumber.SendText(phone);
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
            btnUpdateProfile.ClickOnIt();
            btnUpdateProfile.ClickOnIt();
            //btnUpdateProfile.SendText(Keys.Enter);
        }
        public string GetSuccessText()
        {
            WebElementWrapper success = driver.GetByXpath("//h4[@class='ui-pnotify-title']");
            return success.GetText();
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
        //public void SetImage()
        //{
        //    imageSelect.SendText(@"C:\Users\Maxim\Desktop\11.jpg");
        //}
    }
}