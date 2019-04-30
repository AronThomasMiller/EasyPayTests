using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;

namespace EasyPayLibrary.Pages.UnauthorizedUserPages.Gmail
{
    public class GmailPage:BasePageObject
    {
        WebElementWrapper emailFromEasyPay;

        public override void Init(DriverWrapper driver)
        {
            emailFromEasyPay = driver.GetByXpath("//*[contains(text(),'EASY PAY - Confirm Registration')]/../..");
            base.Init(driver);
        }

        public void ClickOnFirstMail()
        {
            emailFromEasyPay.ClickOnIt();
        }

        public MailPage OpenMail()
        {
            ClickOnFirstMail();
            
            return GetPOM<MailPage>(driver);
        }

    }
}