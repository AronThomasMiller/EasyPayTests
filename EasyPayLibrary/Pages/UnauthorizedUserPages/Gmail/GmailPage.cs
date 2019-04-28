using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;

namespace EasyPayLibrary.Pages.UnauthorizedUserPages.Gmail
{
    public class GmailPage:BasePageObject
    {
        List<WebElementWrapper> emailFromEasyPay;

        public override void Init(DriverWrapper driver)
        {
            emailFromEasyPay = driver.GetElementsByXpath("//span[@email='ch067.easypay@gmail.com']/../../../..");
            base.Init(driver);
        }

        public void ClickOnFirstMail()
        {
            emailFromEasyPay[0].ClickOnIt();
        }

        public MailPage OpenMail()
        {
            ClickOnFirstMail();
            
            return GetPOM<MailPage>(driver);
        }

    }
}