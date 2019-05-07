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
            Assert.AreEqual("ADMIN", role,"not logined as admin");
        }

       

        [Test]
        public void VerifyThatAdminHasAbilityToAccessHisProfile()
        {
            var prof = home.GoToProfile();
            Assert.AreEqual("Profile", prof.GetTitle(),"Profile is not avaliable");
        }

        [Test]
        public void VerifyThatAdminHasAbilityToCheckHisProfile()
        {
            var prof = home.GoToProfile();
            prof.EditData("Ivan", "Petrov", "+380938780876", "Admin123", "Admin1234");
            Assert.AreEqual("Success", prof.GetSuccessText(),"Admin can't change his profile data");

            //post condition
            prof.EditPassword("Admin1234", "Admin123");
        }

        [Test]
        public void VerifyThatAdminCanChangeRole()
        {
            var user = home.NavigateToUsers();
            user.ChangeRoleToManager("user3@gmail.com");
            Assert.AreNotEqual("USER", user.GetRole("user3@gmail.com"),"Role isn't changing");
            user.ChangeRoleToUser("user3@gmail.com");
        }

        [Test]
        public void VerifyThatListOfUsersIsVisibleForAdmin()
        {
            var user = home.NavigateToUsers();
            Assert.IsTrue(user.TableOfUsersIsVisible(),"Table of users isn't visible");
        }

        [Test]
        public void VerifyThatListOfUtilitiesIsVisibleForAdmin()
        {
            var utilities = home.NavigateToUtilities();
            Assert.IsTrue(utilities.TableOfUtilitiesIsVisible(),"Table of utilities isn't visible");
        }

        [Test]
        public void VerifyThatAdminCanEditManager()
        {
            var utilities = home.NavigateToUtilities();
            utilities.ClickOnChangeManager();
            utilities.SetKeywordToTextBox();
            utilities.SelectManager("Viktoriya Radashko");
            utilities.ClickOnConfirm();
            Assert.AreEqual("Viktoriya Radashko", utilities.getTextFromManagerField(),"Viktoriya Radashko isn't assigned as manager");
        }

        [Test]
        public void IsUserSignedUp()
        {
            var user = home.NavigateToUsers();
            Assert.IsTrue(user.UserIsVisible(),"User isn't visible");
        }
    }
}
