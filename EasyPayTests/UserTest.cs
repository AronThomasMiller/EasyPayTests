using EasyPayLibrary;
using NUnit.Framework;
using System;

namespace EasyPayTests
{
    public class UserTest:BaseTest
    {
        [TestCase("user1@gmail.com","Admin123", (float)12.4, "4242424242424242", "012020","434","58004", "Чернівецька область", "Чернівці", "вулиця Шевченка 44/54", "Pat \"Chernivtsihaz\"")]
        public void PayAndCheckOneInPaymentHistory(string userEmail, string userPass, float sumToPay, string cardNumber, string dateOfCard, string cvc, string zipCode, string region, string city, string street, string utility)
        {
            driver.GoToURL();
            WelcomePage welcomePage = new WelcomePage();
            welcomePage.Init(driver);

            var loginPage = welcomePage.SignIn();

            var homePage = (HomePageUser)loginPage.Login(userEmail, userPass);
            Assert.AreEqual("USER", GeneralPage.GetRole(driver));

            var payPage = homePage.NavigateToPayment();

            var address = street + ", " + city + ", " + region;
            homePage = payPage.Pay(address, utility, sumToPay, userEmail, cardNumber, dateOfCard, cvc, zipCode);

            var paymentHistoryPage = homePage.NavigateToPaymentHistory();

            address = region + ", " + city + ", " + street;
            Assert.AreEqual(DateTime.Today.ToString("d") + "_" + sumToPay.ToString().Replace(',', '.'), paymentHistoryPage.GetLastPayInString(address, utility));
        }
    }
}
