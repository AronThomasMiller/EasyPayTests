using EasyPayLibrary;
using EasyPayLibrary.Pages.Manager;
using NUnit.Framework;

namespace EasyPayTests
{
    public class ManagerTest: BaseTest
    {
        [TestCase("manager1@gmail.com","Admin123")]
        public void VerifyThatManagerHasAccesToAccount(string email, string password)
        {
            driver.GoToURL();
            WelcomePage welcome = new WelcomePage();
            welcome.Init(driver);

            var loginPage = welcome.SignIn();
            var homePage = (HomePageManager)loginPage.Login(email, password);

            Assert.IsTrue(driver.getUrl().Contains("http://localhost:8080/home"));
            Assert.AreEqual("MANAGER", GeneralPage.GetRole(driver));
        }
    }
}
