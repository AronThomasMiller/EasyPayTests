using DatabaseManipulation;
using EasyPayLibrary;
using NUnit.Framework;
using System.Collections.Generic;

namespace EasyPayTests
{
    [TestFixture]
    [Category("All")]
    [Category("UnauthorizedUser")]
    [Parallelizable(ParallelScope.Fixtures)]
    public class UnauthorizedUser:BaseTest
    {
        [TestCase("Name", "Surname", "+380123456789", "gangstatester@gmail.com", "Fakesoft15")]
        public void CreateAccount(string name, string surname, string phoneNumber, string email, string password)
        {
            using(var conn = new DatabaseMaster())
            {
                LogProgress("Connecting to database");
                conn.Open();
                LogProgress("Clearing pre-registered users");
                conn.ChangeInDB("truncate table email_token");
                LogProgress($"Deleting from DB user with email:{email}");
                conn.ChangeInDB($"delete from users where email = '{email}'");
            }

            LogProgress("Navigating to register page");
            var registerPage = welcomePage.SignUp();
            LogProgress($"Entering data to registration fields - Name:{name}, Surname:{surname}, Phone number:{phoneNumber}, Email:{email}");
            var googlePage = registerPage.Register(name, surname, phoneNumber, email, password);

            LogProgress($"Entering email\"{email}\" to login");
            var passPage = googlePage.EnterEmail(email);
            LogProgress($"Entering password\"{password}\" to login");
            var emailsPage = passPage.EnterPassword(password);
            LogProgress("Opening email with confirm link");
            var mailPage = emailsPage.OpenMail();
            LogProgress("Clicking on confirm link");
            var loginPage = mailPage.ConfirmEmail();
            LogProgress("Checking able of loggining");
            var homePage = loginPage.LoginAsUser(email, password);

            Assert.IsTrue(driver.GetUrl().Contains("http://localhost:8080/home"));
        }

        [Test]
        public void SignInInspectorIncorrect()
        {
            var loginPage = welcomePage.SignIn();
            var test = loginPage.TryLoginWithInvalidData("inspectr1@gmail.com", "Admin123");
            var result = driver.GetByXpath("//h4[@class='ui-pnotify-title']");
            Assert.AreEqual(result.GetText(), "Error");
        }

        [Test]
        public void LoginAsAdminWithNonValidData()
        {
            var login = welcomePage.SignIn();
            var home = login.TryLoginWithInvalidData("admin1@gmail.com", "Admin5677");
            Assert.IsTrue(home.IsErrorPresent());
        }

        [Test]
        public void UserIsUnableToLoginNonValidData()
        {
            WelcomePage welcome = new WelcomePage();
            welcome.Init(driver);
            var login = welcome.SignIn();
            var test = login.TryLoginWithInvalidData("user1@gmail.com", "Admin12345");

            Assert.IsTrue(test.IsErrorPresent());
        }
    }
}
