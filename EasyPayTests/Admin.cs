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
    [TestFixture]
    [Category("All")]
    [Category("Admin")]
    [Parallelizable(ParallelScope.Fixtures)]
    public class Admin:BaseTest
    {
        HomePageAdmin home;

        [SetUp]
        public override void PreCondition()
        {
            base.PreCondition();
            LogProgress("Admin is going to Login Page ");
            var login = welcomePage.SignIn();
            LogProgress("Admin is going to his Home Page");
            home = login.LoginAsAdmin("admin1@gmail.com", "Admin123");
        }

        [Test]
        public void LoginAsAdminWithValidData()
        {
            LogProgress("Getting role from AdminSideBar");
            var role = GeneralPage.GetRole(driver);
            Assert.AreEqual("ADMIN", role,"not logined as admin");
        }

       

        [Test]
        public void VerifyThatAdminHasAbilityToAccessHisProfile()
        {
            LogProgress("Admin navigating to his profile");
            var prof = home.GoToProfile();
            Assert.AreEqual("Profile", prof.GetTitle(),"Profile is not avaliable");
        }

        [Test]
        public void VerifyThatAdminHasAbilityToChangeHisProfileInfo()
        {
            LogProgress("Admin navigating to his profile");
            var prof = home.GoToProfile();
            LogProgress("Admin editing his data");
            prof.EditData("Ivan", "Petrov", "+380938780876", "Admin123", "Admin1234");
            Assert.AreEqual("Success", prof.GetSuccessText(),"Admin can't change his profile data");

            LogProgress("Admin returns his old data");
            prof.EditPassword("Admin1234", "Admin123");
            Assert.AreEqual("Success", prof.GetSuccessText(), "Admin can't change his profile data");
        }

        [Test]
        public void VerifyThatAdminCanChangeRole()
        {
            LogProgress("Admin navigating to User Page");
            var user = home.NavigateToUsers();
            LogProgress("Admin change role to Manager");
            user.ChangeRole("user3@gmail.com", "MANAGER");
            Assert.AreNotEqual("USER", user.GetRole("user3@gmail.com"),"Role isn't changing");

            LogProgress("Admin returns role to User");
            user.ChangeRole("user3@gmail.com", "USER");
        }

        [Test]
        public void VerifyThatListOfUsersIsVisibleForAdmin()
        {
            LogProgress("Admin navigating to User Page");
            var user = home.NavigateToUsers();
            Assert.IsTrue(user.TableOfUsersIsVisible(),"Table of users isn't visible");
        }

        [Test]
        public void VerifyThatListOfUtilitiesIsVisibleForAdmin()
        {
            LogProgress("Admin navigating to Utilities Page");
            var utilities = home.NavigateToUtilities();
            Assert.IsTrue(utilities.TableOfUtilitiesIsVisible(),"Table of utilities isn't visible");
        }

        [Test]
        public void IsUserSignedUp()
        {
            LogProgress("Admin navigating to User Page");
            var user = home.NavigateToUsers();
            Assert.IsTrue(user.UserIsVisible(),"User isn't visible");
        }
    }
}
