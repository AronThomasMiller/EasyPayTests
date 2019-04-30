namespace EasyPayLibrary.Pages.UnauthorizedUserPages.Gmail
{
    public class GmailPasswordPage:BasePageObject
    {
        WebElementWrapper fieldPassword;
        WebElementWrapper btnNext;

        public override void Init(DriverWrapper driver)
        {
            fieldPassword = driver.GetByXpath("//input[@name='password']");
            btnNext = driver.GetByXpath("//div[@id='passwordNext']");
            base.Init(driver);
        }

        public void SetPassword(string password)
        {
            fieldPassword.SendText(password);
        }

        public void ClickOnNextButton()
        {
            btnNext.Click();
        }

        public GmailPage EnterPassword(string password)
        {
            SetPassword(password);
            ClickOnNextButton();
            driver.GetByXpath("//*[@class='gb_pe']");
            driver.GoToURL("https://mail.google.com/mail/u/0/h/1pq68r75kzvdr/?v%3Dlui");
            return GetPOM<GmailPage>(driver);
        }
    }
}