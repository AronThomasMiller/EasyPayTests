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
            var login = welcome.SignIn();
            home = (HomePageAdmin)login.Login("admin1@gmail.com", "Admin123");
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
            Assert.AreEqual("Success", prof.GetSuccessText(), "Admin can't change his profile data");
        }

        [Test]
        public void VerifyThatAdminCanChangeRole()
        {
            var user = home.NavigateToUsers();
            user.ChangeRole("user3@gmail.com", "MANAGER");
            Assert.AreNotEqual("USER", user.GetRole("user3@gmail.com"),"Role isn't changing");
            user.ChangeRole("user3@gmail.com", "USER");
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
        public void IsUserSignedUp()
        {
            var user = home.NavigateToUsers();
            Assert.IsTrue(user.UserIsVisible(),"User isn't visible");
        }
    }
}
