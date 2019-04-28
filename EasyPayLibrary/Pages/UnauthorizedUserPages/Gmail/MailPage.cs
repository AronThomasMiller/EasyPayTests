using OpenQA.Selenium;
using System.Collections.Generic;
using System.Threading;

namespace EasyPayLibrary.Pages.UnauthorizedUserPages.Gmail
{
    public class MailPage:BasePageObject
    {
        List<WebElementWrapper> confirmationLinks;

        public override void Init(DriverWrapper driver)
        {
            driver.WaitUntilSiteFullyLoaded("//div[contains(text(),'To confirm your account registration, click on the link: ')]//a", 10);
            confirmationLinks = driver.GetElementsByXpath("//div[contains(text(),'To confirm your account registration, click on the link: ')]//a");
            base.Init(driver);
        }

        public void ClickOnLastLink()
        {
            confirmationLinks[confirmationLinks.Count-1].ClickOnIt();
        }

        public void DeleteAllMails()
        {
            WebElementWrapper btnDelete = driver.GetByXpath("/html[1]/body[1]/div[7]/div[3]/div[1]/div[2]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[2]/div[3]/div[1]");
            btnDelete.ClickOnIt();
        }

        public LoginPage ConfirmEmail()
        {
            ClickOnLastLink();
            
            DeleteAllMails();

            driver.SwitchToWindow();
            return GetPOM<LoginPage>(driver);
        }
    }
}