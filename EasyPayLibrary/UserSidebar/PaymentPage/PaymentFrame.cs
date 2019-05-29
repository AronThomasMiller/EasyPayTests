using OpenQA.Selenium.Firefox;
using System;
using System.Threading;

namespace EasyPayLibrary
{
    public class PaymentFrame:BasePageObject
    {
        WebElementWrapper email;
        WebElementWrapper cardNumber;
        WebElementWrapper dateOfCard;
        WebElementWrapper cvc;
        WebElementWrapper zipCode;
        WebElementWrapper btnSubmit;
        string frameName = "stripe_checkout_app";

        public override void Init(DriverWrapper driver)
        {
            driver.ChangeFrame(frameName);
            base.Init(driver);

            email = driver.GetByXpath("//input[@placeholder='Email']");
            cardNumber = driver.GetByXpath("//input[@placeholder='Card number']");
            dateOfCard = driver.GetByXpath("//input[@placeholder='MM / YY']");
            cvc = driver.GetByXpath("//input[@placeholder='CVC']");
            btnSubmit = driver.GetByXpath("//button");
        }

        public void SetEmail(string email)
        {
            this.email.SendText(email);
        }

        public void SetZipCode(string zipCode)
        {
            this.zipCode.SendText(zipCode);
        }

        public void SetCardNumber(string cardNumber)
        {
            this.cardNumber.SendText(cardNumber);
        }

        public void SetDateOfCard(string dateOfCard)
        {
            this.dateOfCard.SendText(dateOfCard);
        }

        public void SetCVC(string cvc)
        {
            this.cvc.SendText(cvc);
        }

        public void ClickSubmitButton()
        {
            btnSubmit.Click();
        }

        public Tuple<HomePageUser,string> Pay(string email, string cardNumber, string dateOfCard, string cvc, string zipCode)
        {
            SetEmail(email);
            SetCardNumber(cardNumber);
            SetDateOfCard(dateOfCard);
            SetCVC(cvc);

            this.zipCode = driver.GetByXpath("//input[@placeholder='ZIP Code']");
            SetZipCode(zipCode);

            ClickSubmitButton();
            driver.WaitUntillUrlContainString("drive.google.com",20);
            var urlOfCheck = driver.GetUrl();
            if (driver.GetTypeOfDriver() == typeof(FirefoxDriver)) driver.SwithToDefault();
            driver.GoToURL("http://localhost:8080/home");
            return new Tuple<HomePageUser, string>(GetPOM<HomePageUser>(driver), urlOfCheck);
        }
    }
}