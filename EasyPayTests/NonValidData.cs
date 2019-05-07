using EasyPayLibrary;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPayTests
{
    public class NonValidData
    {
        DriverWrapper driver;
        HomePageAdmin home;

        [SetUp]
        public void PreCondition()
        {
            driver = new DriverFactory().GetDriver();
            driver.Maximaze();
            driver.GoToURL();            
        }

        [TearDown]
        public void PostCondition()
        {
            if ((TestContext.CurrentContext.Result.Outcome == ResultState.Failure) || (TestContext.CurrentContext.Result.Outcome == ResultState.Error))
            {
                driver.getScreenshot();
            }
            driver.Quit();
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
