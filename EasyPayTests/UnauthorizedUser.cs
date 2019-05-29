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
                conn.Open();
                conn.ChangeInDB($"delete from users where email = '{email}'");
            }

            driver.GoToURL();
            WelcomePage welcomePage = new WelcomePage();
            welcomePage.Init(driver);

            var googlePage = welcomePage.SignUp().Register(name, surname, phoneNumber, email, password);

            var passPage = googlePage.EnterEmail(email);
            var emailsPage = passPage.EnterPassword(password);
            var mailPage = emailsPage.OpenMail();
            var loginPage = mailPage.ConfirmEmail();
            var homePage = (HomePageUser)loginPage.Login(email, password);

            Assert.IsTrue(driver.GetUrl().Contains("http://localhost:8080/home"));
        }

        [Test]
        public void SignInInspectorIncorrect()
        {
            WelcomePage welcomePage = new WelcomePage();
            welcomePage.Init(driver);
            var loginPage = welcomePage.SignIn();
            var test = (LoginPage)loginPage.Login("inspectr1@gmail.com", "Admin123");
            var result = driver.GetByXpath("//h4[@class='ui-pnotify-title']");
            Assert.AreEqual(result.GetText(), "Error");
        }

        [Test]
        public void Localization()
        {
            driver.GoToURL();
            var welcomePage = new WelcomePage();
            welcomePage.Init(driver);

            var welcomeTextElemsEN = welcomePage.GetTextElements();
            welcomePage = welcomePage.TranslatePageToUA();
            var welcomeTextElemsUA = welcomePage.GetTextElements();
            welcomePage = welcomePage.TranslatePageToEN();

            var dict = new Dictionary<string, string>();
            for (int i = 0; i < welcomeTextElemsUA.Count; i++)
            {
                dict.Add(welcomeTextElemsEN[i], welcomeTextElemsUA[i]);
            }

            var result = BasePageObject.CheckTranslation(dict, welcomeTextElemsUA);
            Assert.IsTrue(result == null, "The word {0} didn't match dictionary", result);
            dict.Clear();



            var registerPage = welcomePage.SignUp();

            var registerPageTextElemsEN = registerPage.GetTextElements();
            registerPage = registerPage.TranslatePageToUA();
            var registerPageTextElemsUA = registerPage.GetTextElements();
            registerPage = registerPage.TranslatePageToEN();

            dict = new Dictionary<string, string>();
            for (int i = 0; i < welcomeTextElemsUA.Count; i++)
            {
                dict.Add(welcomeTextElemsEN[i], welcomeTextElemsUA[i]);
            }

            result = BasePageObject.CheckTranslation(dict, welcomeTextElemsUA);
            Assert.IsTrue(result == null, "The word {0} didn't match dictionary", result);
        }

        [Test]
        public void LoginAsAdminWithNonValidData()
        {
            driver.GoToURL();
            WelcomePage welcome = new WelcomePage();
            welcome.Init(driver);
            var login = welcome.SignIn();
            var home = (LoginPage)login.Login("admin1@gmail.com", "Admin5677");
            Assert.IsTrue(home.IsErrorPresent());
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
    }
}
