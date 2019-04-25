using EasyPayLibrary;
using EasyPayLibrary.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EasyPayTests
{
    public class UserTest
    {
        DriverWrapper driver;

        [SetUp]
        public void PreCondition()
        {
            driver = new DriverFactory().GetDriver();
            driver.Maximaze();
            driver.GoToURL();
        }

        [Test]
        public void UserIsAbleToLogin()
        {
            WelcomePage welcome = new WelcomePage();
            welcome.Init(driver);
            var login = welcome.SignIn();           
            var home = login.Login("user1@gmail.com", "Admin123");            
            Assert.IsTrue(home.GetRole() == true);
        }

        [Test]
        public void UserIsUnableToLoginNonValidData()
        {
            WelcomePage welcome = new WelcomePage();
            welcome.Init(driver);
            var login = welcome.SignIn();
            login.Login("user1@gmail.com", "Admin12345");
            Assert.IsTrue(login.IsErrorPresent());            
        }

        [Test]
        public void PersonalCabinetAccess()
        {
            WelcomePage welcome = new WelcomePage();
            welcome.Init(driver);
            var login = welcome.SignIn();
            var home =login.Login("user1@gmail.com", "Admin123");
            var profile =home.GoToProfile();
            Assert.IsTrue(profile.NameIsVisible());
            Assert.IsTrue(profile.SurnameIsVisible());
            Assert.IsTrue(profile.PhoneNumberIsVisible());
        }

        [Test]
        public void PersonalInfoMatch()
        {
            WelcomePage welcome = new WelcomePage();
            welcome.Init(driver);
            var login = welcome.SignIn();
            var home = login.Login("user1@gmail.com", "Admin123");
            var profile = home.GoToProfile();
            Assert.AreEqual("Mariya",profile.GetName("value"));
            Assert.AreEqual("Chuikina", profile.GetSurname("value"));
            Assert.AreEqual("+380968780876", profile.GetPhoneNumber("value"));
        }

        [Test]
        public void IsNameChanging()
        {
            WelcomePage welcome = new WelcomePage();
            welcome.Init(driver);
            var login = welcome.SignIn();
            var home = login.Login("user1@gmail.com", "Admin123");
            var profile = home.GoToProfile();            
            profile.SetValue("Vasia");
            Assert.AreEqual("Vasia", profile.GetName("value"));
        }

        [Test]
        public void IsPersonalInfoTranslationIsCorrect()
        {
            WelcomePage welcome = new WelcomePage();
            welcome.Init(driver);
            var login = welcome.SignIn();
            var home = login.Login("user1@gmail.com", "Admin123");
            var profile = home.GoToProfile();
            profile.ChangeToUKR();
            profile.Init(driver);
            var name = profile.GetName("value");
            Assert.IsTrue(profile.TranslateToUA(name));
            var surname = profile.GetSurname("value");
            Assert.IsTrue(profile.TranslateToUA(surname));
        }

        [Test]
        public void CheckTranslationOnHomeUsersPage()
        {
            WelcomePage welcome = new WelcomePage();
            welcome.Init(driver);
            var login = welcome.SignIn();
            var home = login.Login("user1@gmail.com", "Admin123");
            home.ChangeToUKR();
            home.Init(driver);
            var role = home.GetRoleText();
            Assert.IsTrue(home.TranslateToUA(role));
            var addresses = home.GetAddressesText();
            Assert.IsTrue(home.TranslateToUA(addresses));
            var connectedUtilities = home.GetConnectedUtilitiesText();
            Assert.IsTrue(home.TranslateToUA(connectedUtilities));
            var payments = home.GetPaymentsText();
            Assert.IsTrue(home.TranslateToUA(payments));
            var paymentsHistory = home.GetPaymentsHistoryText();
            Assert.IsTrue(home.TranslateToUA(paymentsHistory));
            var rateInspectors = home.GetRateInspectorsText();
            Assert.IsTrue(home.TranslateToUA(rateInspectors));

        }


        [TearDown]
        public void PostCondition()
        {
            driver.Quit();
        }
    }
}
