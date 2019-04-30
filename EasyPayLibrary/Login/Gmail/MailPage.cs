using OpenQA.Selenium;
using System.Collections.Generic;
using System.Threading;

namespace EasyPayLibrary.Pages.UnauthorizedUserPages.Gmail
{
    public class MailPage:BasePageObject
    {
        WebElementWrapper confirmationLink;

        public override void Init(DriverWrapper driver)
        {
            confirmationLink = driver.GetByXpath("//div[contains(text(),'To confirm your account registration, click on the link:')]//a");
            base.Init(driver);
        }

        public void ClickOnLastLink()
        {
            confirmationLink.Click();
        }

        public void DeleteAllMails()
        {
            WebElementWrapper btnDelete = driver.GetByXpath("//table//table//table[1]//tbody[1]//tr[1]//td[1]//input[6]");
            btnDelete.Click();
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