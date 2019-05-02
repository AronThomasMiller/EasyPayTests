using EasyPayLibrary;
using EasyPayLibrary.Pages.UnauthorizedUserPages;
using EasyPayLibrary.Pages.UnauthorizedUserPages.Gmail;
using NUnit.Framework;
using System.Collections.Generic;

namespace EasyPayTests
{
    public class UnauthorizedUserTest : BaseTest
    {
        [TestCase("Name", "Surname", "+380123456789", "gangstatester@gmail.com", "Fakesoft15")]
        public void CreateAccount(string name, string surname, string phoneNumber, string email, string password)
        {
            driver.GoToURL();
            WelcomePage welcomePage = new WelcomePage();
            welcomePage.Init(driver);

            var googlePage = welcomePage.SignUp().Register(name, surname, phoneNumber, email, password);

            //var googlePage = (GmailEmailPage)welcomePage.SignIn().Login(email, password);
            //delete from users where email = 'gangstatester@gmail.com'

            var passPage = googlePage.EnterEmail(email);
            var emailsPage = passPage.EnterPassword(password);
            var mailPage = emailsPage.OpenMail();
            var loginPage = mailPage.ConfirmEmail();
            var homePage = (HomePageUser)loginPage.Login(email, password);

            Assert.IsTrue(driver.getUrl().Contains("http://localhost:8080/home"));
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
    }
}
