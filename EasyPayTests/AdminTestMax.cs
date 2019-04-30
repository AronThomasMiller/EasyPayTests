using EasyPayLibrary;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPayTests
{
    class AdminTestMax:BaseTest
    {
        [Test]
        public void LoginAsAdminWithValidData()
        {
            driver.GoToURL();
            WelcomePage welcome = new WelcomePage();
            welcome.Init(driver);
            var login = welcome.SignIn();
            var home = (HomePageAdmin)login.Login("admin1@gmail.com", "Admin123");
            var role = home.GetTextRole();
            Assert.AreEqual("ADMIN", role);
        }
        [Test]
        public void LoginAsAdminWithNonValidData()
        {
            driver.GoToURL();
            WelcomePage welcome = new WelcomePage();
            welcome.Init(driver);
            var login = welcome.SignIn();
            var home = (LoginPage)login.Login("admin1@gmail.com", "Admin5677");
            
            //var role = home.GetTextRole();
            //Assert.AreEqual("ADMIN", role);
        }

        [Test]
        public void VerifyThatAdminHasAbilityToAccessHisDashboard()
        {
            driver.GoToURL();
            WelcomePage welcome = new WelcomePage();
            welcome.Init(driver);
            var login = welcome.SignIn();
            var home = (HomePageAdmin)login.Login("admin1@gmail.com", "Admin123");
            var role = home.GetTextRole();
            Assert.AreEqual("ADMIN", role);
        }

        [Test]
        public void VerifyThatAdminHasAbilityToAccessHisProfile()
        {
            driver.GoToURL();
            WelcomePage welcome = new WelcomePage();
            welcome.Init(driver);
            var login = welcome.SignIn();
            var home = (HomePageAdmin)login.Login("admin1@gmail.com", "Admin123");
            var prof = home.GoToProfile();
            Assert.AreEqual("Profile", prof.GetTitle());
        }

        [Test]
        public void VerifyThatAdminHasAbilityToCheckHisProfile() //False
        {
            driver.GoToURL();
            WelcomePage welcome = new WelcomePage();
            welcome.Init(driver);
            var login = welcome.SignIn();
            var home = (HomePageAdmin)login.Login("admin1@gmail.com", "Admin123");
            var prof = home.GoToProfile();
            prof.EditData("Ivan", "Petrov", "+380938780876", "Admin123", "Admin1234");
            Assert.AreEqual("Success", prof.GetSuccessText());

            prof.EditPassword("Admin1234", "Admin123");
        }

        [Test]
        public void VerifyThatAdminCanChangeRole()
        {
            driver.GoToURL();
            WelcomePage welcome = new WelcomePage();
            welcome.Init(driver);
            var login = welcome.SignIn();
            var home = (HomePageAdmin)login.Login("admin1@gmail.com", "Admin123");
            var user = home.ClickOnUsers();
            user.ChangeRoleToManager();
            Assert.AreNotEqual("USER", user.GetRole());
            user.ChangeRoleToUser();
        }

        [Test]
        public void VerifyThatListOfUsersIsVisibleForAdmin()
        {
            driver.GoToURL();
            WelcomePage welcome = new WelcomePage();
            welcome.Init(driver);
            var login = welcome.SignIn();
            var home = (HomePageAdmin)login.Login("admin1@gmail.com", "Admin123");
            var user = home.ClickOnUsers();
            Assert.IsTrue(user.TableOfUsersIsVisible());

        }

        [Test]
        public void VerifyThatListOfUtilitiesIsVisibleForAdmin()
        {
            driver.GoToURL();
            WelcomePage welcome = new WelcomePage();
            welcome.Init(driver);
            var login = welcome.SignIn();
            var home = (HomePageAdmin)login.Login("admin1@gmail.com", "Admin123");
            var utilities = home.ClickOnUtilities();
            Assert.IsTrue(utilities.TableOfUtilitiesIsVisible());
        }

        [Test]
        public void VerifyThatAdminCanEditManager()
        {
            driver.GoToURL();
            WelcomePage welcome = new WelcomePage();
            welcome.Init(driver);
            var login = welcome.SignIn();
            var home = (HomePageAdmin)login.Login("admin1@gmail.com", "Admin123");
            var utilities = home.ClickOnUtilities();

        }
    }
}
