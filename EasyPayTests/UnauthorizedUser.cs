using EasyPayLibrary;
using EasyPayLibrary.Pages.UnauthorizedUserPages;
using EasyPayLibrary.Pages.UnauthorizedUserPages.Gmail;
using NUnit.Framework;

namespace EasyPayTests
{
    class UnauthorizedUser:BaseTest
    {
        [TestCase("Name", "Surname", "+380123456789", "gangstatester@gmail.com", "Fakesoft15")]
        public void CreateAccount(string name, string surname, string phoneNumber, string email, string password)
        {
            driver.GoToURL();
            WelcomePage welcomePage = new WelcomePage();
            welcomePage.Init(driver);

            var googlePage = welcomePage.SignUp().Register(name, surname, phoneNumber, email, password);

            //var googlePage = (GmailEmailPage)welcomePage.SignIn().Login(email, password);

            var passPage = googlePage.EnterEmail(email);
            var emailsPage = passPage.EnterPassword("Fakesoft15");
            var mailPage = emailsPage.OpenMail();
            var loginPage = mailPage.ConfirmEmail();
            var homePage = (HomePageUser)loginPage.Login(email, password);

            Assert.AreEqual("http://localhost:8080/home", driver.getUrl());
        }
    }
}
