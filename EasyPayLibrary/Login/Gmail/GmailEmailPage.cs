namespace EasyPayLibrary.Pages.UnauthorizedUserPages.Gmail
{
    public class GmailEmailPage: BasePageObject
    {
        WebElementWrapper fieldEmail;
        WebElementWrapper btnNext;

        public override void Init(DriverWrapper driver)
        {
            driver.GoToURL("https://accounts.google.com");
            fieldEmail = driver.GetByXpath("//input[@id='identifierId']");
            btnNext = driver.GetByXpath("//div[@id='identifierNext']");
            base.Init(driver);
        }
        
        public void SetEmail(string email)
        {
            fieldEmail.SendText(email);
        }

        public void ClickOnNextButton()
        {
            btnNext.Click();
        }

        public GmailPasswordPage EnterEmail(string email)
        {
            SetEmail(email);
            ClickOnNextButton();
            return GetPOM<GmailPasswordPage>(driver);
        }
    }
}
