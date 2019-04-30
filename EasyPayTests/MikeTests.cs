﻿using EasyPayLibrary;
using EasyPayLibrary.Translations;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EasyPayTests
{
    public class MikeTests
    {
        protected DriverWrapper driver;
        TranslationValues t;

        [SetUp]
        public void PreCondition()
        {
            t = TranslationProvider.GetTranslation("ua");
            driver = new DriverFactory().GetDriver();
            driver.Maximaze();
            driver.GoToURL();
        }
        
        [Test]
        /// <summary>
        /// коли буде мерж з адміновскькою пейджою
        /// тоді і хпаси перейдуть на адмін пейдж в ПОМ
        /// </summary>
        public void IsUserSignedUp()
        {
            WelcomePage welcome = new WelcomePage();
            welcome.Init(driver);
            var login = welcome.SignIn();
            var home = login.Login("admin1@gmail.com", "Admin123");
            driver.GetByXpath("//*[@href='/admin/management-users']").Click();
            var user = driver.GetByXpath("//td[text()='user1@gmail.com']");
            Assert.IsTrue(user.IsDisplayed());
        }

        [Test]
        public void UserIsAbleToLogin()
        {
            WelcomePage welcome = new WelcomePage();
            welcome.Init(driver);
            var login = welcome.SignIn();           
            var home = (UsersHomePage)login.Login("user1@gmail.com", "Admin123");            
            Assert.IsTrue(home.GetRole() == true);
        }

        [Test]
        public void UserIsUnableToLoginNonValidData()
        {
            WelcomePage welcome = new WelcomePage();
            welcome.Init(driver);
            var login = welcome.SignIn();
            var test = (LoginPage)login.Login("user1@gmail.com", "Admin12345");

            Assert.IsTrue(test.IsErrorPresent());                        
        }

        [Test]
        public void PersonalCabinetAccess()
        {
            WelcomePage welcome = new WelcomePage();
            welcome.Init(driver);
            var login = welcome.SignIn();
            var home = (UsersHomePage)login.Login("user1@gmail.com", "Admin123");
            var profile = home.GoToProfile();
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
            var home = (UsersHomePage)login.Login("user1@gmail.com", "Admin123");
            var profile = home.GoToProfile();
            Assert.AreEqual("Masha",profile.GetName());
            Assert.AreEqual("Chuikina", profile.GetSurname());
            Assert.AreEqual("+380968780876", profile.GetPhoneNumber());
        }

        [Test]
        public void IsNameChanging()
        {
            WelcomePage welcome = new WelcomePage();
            welcome.Init(driver);
            var login = welcome.SignIn();
            var home = (UsersHomePage)login.Login("user1@gmail.com", "Admin123");
            var profile = home.GoToProfile();            
            profile.SetName("Masha");            
            profile.UpdateProfile();            
            Assert.True(profile.IsSuccessAlertDisplayed());
            Assert.AreEqual("Masha", profile.GetName());
        }

        [Test]
        public void IsPersonalInfoTranslationIsCorrect()
        {
            WelcomePage welcome = new WelcomePage();
            welcome.Init(driver);
            var login = welcome.SignIn();
            var home = (UsersHomePage)login.Login("user1@gmail.com", "Admin123");
            var profile = home.GoToProfile();
            ProfilePage changed = profile.ChangeToUKR();
            profile.Init(driver);
            var name = profile.GetName();            
            Assert.AreEqual(t.Mariya.ToLower(),name.ToLower());
            var surname = profile.GetSurname();
            Assert.AreEqual(t.Chuikina.ToLower(), surname.ToLower());
        }

        [Test]
        public void NameCanContainUALetters()
        {
            WelcomePage welcome = new WelcomePage();
            welcome.Init(driver);
            var login = welcome.SignIn();
            var home = (UsersHomePage)login.Login("user1@gmail.com","Admin123");
            var profile = home.GoToProfile();
            profile.SetName("Вася");
            profile.UpdateProfile();            
            Assert.IsFalse(profile.IsErrorAlertDisplayed());            
        }

        [Test]
        public void CheckTranslationOnHomeUsersPage()
        {
            WelcomePage welcome = new WelcomePage();
            welcome.Init(driver);
            var login = welcome.SignIn();
            var home = (UsersHomePage)login.Login("user1@gmail.com", "Admin123");
            home.ChangeToUKR();
            home.Init(driver);
            var role = home.GetRoleText();            
            Assert.AreEqual(t.User.ToLower(),role.ToLower());            
            var addresses = home.GetAddressesText();
            Assert.AreEqual(t.Addresses.ToLower(), addresses.ToLower());
            var connectedUtilities = home.GetConnectedUtilitiesText();
            Assert.AreEqual(t.ConnectedUtilities.ToLower(), connectedUtilities.ToLower());
            var payments = home.GetPaymentsText();
            Assert.AreEqual(t.Payments.ToLower(), payments.ToLower());
            var paymentsHistory = home.GetPaymentsHistoryText();
            Assert.AreEqual(t.PaymentsHistory.ToLower(), paymentsHistory.ToLower());
            var rateInspectors = home.GetRateInspectorsText();
            Assert.AreEqual(t.RateInspectors.ToLower(), rateInspectors.ToLower());
            var mainPageTitle = home.GetMainPageTitleText();
            Assert.AreEqual(t.MainPage.ToLower(), mainPageTitle.ToLower());
            var xTitle = home.GetXTitleText();
            Assert.AreEqual(t.SomeText.ToLower(), xTitle.ToLower());
        }

        

        [TearDown]
        public void PostCondition()
        {
            Thread.Sleep(3000);
            driver.Quit();
        }
    }
}
