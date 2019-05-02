using EasyPayLibrary;
using EasyPayLibrary.Translations;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPayTests
{
    public class Admin
    {
        DriverWrapper driver;
        HomePageAdmin home;

        [SetUp]
        public void PreCondition()
        {
            driver = new DriverFactory().GetDriver();
            driver.Maximaze();
            driver.GoToURL();
            WelcomePage welcome = new WelcomePage();
            welcome.Init(driver);
            var login = welcome.SignIn();
            home = (HomePageAdmin)login.Login("admin1@gmail.com", "Admin123");
        }

        [TearDown]
        public void PostCondition()
        {
            if ((TestContext.CurrentContext.Result.Outcome == ResultState.Failure)||(TestContext.CurrentContext.Result.Outcome == ResultState.Error))
            {
                driver.getScreenshot();
            }
            driver.Quit();
        }

        [Test]
        public void LoginAsAdminWithValidData()
        {
            var role = home.GetTextRole();
            Assert.AreEqual("ADMIN", role);
        }

        //[TestCase("admin1@gmail.com", "Admin5677")]
        //public void LoginAsAdminWithNonValidData(string email, string password)
        //{
        //    driver.GoToURL();
        //    WelcomePage welcome = new WelcomePage();
        //    welcome.Init(driver);
        //    var login = welcome.SignIn();
        //    var home = (LoginPage)login.Login(email, password);

        //    Assert.IsFalse(home.IsErrorPresent());
        //}

        [Test]
        public void VerifyThatAdminHasAbilityToAccessHisDashboard()
        {
            var role = home.GetTextRole();
            Assert.AreEqual("ADMIN", role);
        }

        [Test]
        public void VerifyThatAdminHasAbilityToAccessHisProfile()
        {
            var prof = home.GoToProfile();
            Assert.AreEqual("Profile", prof.GetTitle());
        }

        [Test]
        public void VerifyThatAdminHasAbilityToCheckHisProfile()
        {
            var prof = home.GoToProfile();
            prof.EditData("Ivan", "Petrov", "+380938780876", "Admin123", "Admin1234");
            Assert.AreEqual("Success", prof.GetSuccessText());

            prof.EditPassword("Admin1234", "Admin123");
        }

        [Test]
        public void VerifyThatAdminCanChangeRole()
        {
            var user = home.NavigateToUsers();
            user.ChangeRoleToManager("user3@gmail.com");
            Assert.AreNotEqual("USER", user.GetRole("user3@gmail.com"));
            user.ChangeRoleToUser("user3@gmail.com");
        }

        [Test]
        public void VerifyThatListOfUsersIsVisibleForAdmin()
        {
            var user = home.NavigateToUsers();
            Assert.IsTrue(user.TableOfUsersIsVisible());
        }

        [Test]
        public void VerifyThatListOfUtilitiesIsVisibleForAdmin()
        {
            var utilities = home.NavigateToUtilities();
            Assert.IsTrue(utilities.TableOfUtilitiesIsVisible());
        }

        [Test]
        public void VerifyThatAdminCanEditManager()
        {
            var utilities = home.NavigateToUtilities();
            utilities.ClickOnChangeManager();
            utilities.SetKeywordToTextBox();
            utilities.SelectManager("Viktoriya Radashko");
            utilities.ClickOnConfirm();
            Assert.AreEqual("Viktoriya Radashko", utilities.getTextFromManagerField());
        }

        [Test]
        public void IsUserSignedUp()
        {
            driver.GetByXpath("//*[@href='/admin/management-users']").Click();
            var user = driver.GetByXpath("//td[text()='user1@gmail.com']");
            Assert.IsTrue(user.IsDisplayed());
        }

    }
}
