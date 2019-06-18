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
    public class AdminPage:BaseTest
    {
        HomePageAdmin homePage;

        [SetUp]
        public override void PreCondition()
        {
            base.PreCondition();
            LogProgress("Admin is going to Login Page ");
            var loginPage = welcomePage.SignIn();
            LogProgress("Admin is going to his Home Page");
            homePage = loginPage.LoginAsAdmin("admin1@gmail.com", "Admin123");
        }

        [Test]
        public void LoginAsAdminWithValidData()
        {
            LogProgress("Getting role from AdminSideBar");
            var actualRole = GeneralPage.GetRole(driver);
            var expectedRole = "ADMIN";
            Assert.AreEqual(expectedRole, actualRole, "Not logined as admin");
        }      

        [Test]
        public void VerifyThatAdminHasAbilityToAccessHisProfile()
        {
            LogProgress("Admin navigating to his profile");
            var profilePage = homePage.GoToProfile();
            var actualTitle = profilePage.GetTitle();
            var expectedTitle = "Profile";
            Assert.AreEqual(expectedTitle, actualTitle, "Profile page is not avaliable");
        }

        [Test]
        public void VerifyThatAdminHasAbilityToChangeHisProfileInfo()
        {
            LogProgress("Admin navigating to his profile");
            var profilePage = homePage.GoToProfile();
            LogProgress("Admin editing his data");
            profilePage.EditData("Ivan", "Petrov", "+380938780876", "Admin123", "Admin1234");
            var actualPopupText = profilePage.GetSuccessText();
            var expectedPopupText = "Success";
            Assert.AreEqual(expectedPopupText, actualPopupText, "Admin can't change his profile data");

            LogProgress("Post condition: Admin returns his previous data");
            profilePage.EditPassword("Admin1234", "Admin123");
            actualPopupText = profilePage.GetSuccessText();
            expectedPopupText = "Success";
            Assert.AreEqual(expectedPopupText, actualPopupText, "Admin can't change his profile data to previous");
            LogProgress("Post condition is successful");
        }

        [Test]
        public void VerifyThatAdminCanChangeRole()
        {
            LogProgress("Admin navigating to User Page");
            var userPage = homePage.NavigateToUsers();
            LogProgress("Admin change role to Manager");
            var rowsPage = userPage.ReturnUsersTable();
            var rowWithEmail = rowsPage.GetRowByEmail("user3@gmail.com");
            var changeRolePopUp = rowWithEmail.GetChangeRolePopUp();
            userPage = changeRolePopUp.SelectRole("MANAGER");
            rowsPage = userPage.ReturnUsersTable();
            rowWithEmail = rowsPage.GetRowByEmail("user3@gmail.com");
            var actualRole = rowWithEmail.GetRole();
            var expectedRole = "MANAGER";
            Assert.AreEqual(expectedRole, actualRole, "Admin changed user`s role to Manager");

            LogProgress("Post condition: Admin returns role to User");
            rowsPage = userPage.ReturnUsersTable();
            rowWithEmail = rowsPage.GetRowByEmail("user3@gmail.com");
            changeRolePopUp = rowWithEmail.GetChangeRolePopUp();
            userPage = changeRolePopUp.SelectRole("USER");
            LogProgress("Post condition is successful");
        }

        [Test]
        public void VerifyThatListOfUsersIsVisibleForAdmin()
        {
            LogProgress("Admin navigating to User Page");
            var userPage = homePage.NavigateToUsers();
            var tbOfUsersIsVisible = userPage.TableOfUsersIsVisible();
            Assert.IsTrue(tbOfUsersIsVisible, "Table of users doesn't visible for Admin");
        }

        [Test]
        public void VerifyThatListOfUtilitiesIsVisibleForAdmin()
        {
            LogProgress("Admin navigating to Utilities Page");
            var utilitiesPage = homePage.NavigateToUtilities();
            var tbOfUtilitiesIsVisible = utilitiesPage.TableOfUtilitiesIsVisible();
            Assert.IsTrue(tbOfUtilitiesIsVisible, "Table of utilities doesn't visible for Admin");
        }

        [Test]
        public void IsUserSignedUp()
        {
            LogProgress("Admin navigating to User Page");
            var userPage = homePage.NavigateToUsers();
            var userIsVisible = userPage.TableOfUsersIsVisible();
            Assert.IsTrue(userIsVisible, "User`s table doesn`t contain specific user");
        }
    }
}
