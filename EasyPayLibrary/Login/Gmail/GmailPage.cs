using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;

namespace EasyPayLibrary.Pages.UnauthorizedUserPages.Gmail
{
    public class GmailPage:BasePageObject
    {
        WebElementWrapper emailFromEasyPay;

        public override void Init(DriverWrapper driver)
        {
            var ListOfEmails = driver.GetElementsByXpath("//*[contains(text(),'EASY PAY - Confirm Registration')]/../..");
            emailFromEasyPay = ListOfEmails[0];
            base.Init(driver);
        }

        public void ClickOnFirstMail()
        {
            emailFromEasyPay.Click();
        }

        public MailPage OpenMail()
        {
            ClickOnFirstMail();
            
            return GetPOM<MailPage>(driver);
        }

    }
}