using EasyPayLibrary;
using EasyPayLibrary.Pages.Inspector;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.XPath;
using static EasyPayLibrary.Pages.Inspector.ClientsPage;

namespace EasyPayTests
{
    public class InspectorTest
    {
        private DriverWrapper driver;
        
        [SetUp]
        public void PreCondition()
        {
            driver = new DriverFactory().GetDriver();
            driver.Maximaze(); 
            driver.GoToURL();
        }

        [Test]
        public void SignInInspectorCorrect()
        {
            WelcomePage welcomePage = new WelcomePage();
            welcomePage.Init(driver);
            var loginPage = welcomePage.SignIn();            
            var homePage = loginPage.LoginInspector("inspector1@gmail.com", "Admin123");           
            var header = driver.GetByXpath("//h3[contains(text(),'Inspector')]");
            Assert.AreEqual(header.GetText(), "INSPECTOR");
        }

        [Test]
        public void SignInInspectorIncorrect()
        {
            WelcomePage welcomePage = new WelcomePage();
            welcomePage.Init(driver);
            var loginPage = welcomePage.SignIn();
            loginPage.LoginIncorrect("inspectr1@gmail.com", "Admin123");
            var result = driver.GetByXpath("//h4[@class='ui-pnotify-title']");
            Assert.AreEqual(result.GetText(), "Error");
        }

        //schedule Page
        [Test]
        public void ScheduleAvailable()
        {
            WelcomePage welcomePage = new WelcomePage();
            welcomePage.Init(driver);
            var loginPage = welcomePage.SignIn();
            var homePageInspector = loginPage.LoginInspector("inspector1@gmail.com", "Admin123");
            var schedulePage = homePageInspector.EnterOnSchedule();
            var result = schedulePage.ScheduleIsDisplayed();            
            Assert.True(result, "Not found calendar");
        }

        [Test]
        public void ScheduleNotAvailable()
        {
            WelcomePage welcomePage = new WelcomePage();
            welcomePage.Init(driver);
            var loginPage = welcomePage.SignIn();
            var homePageUser= loginPage.LoginUser("user1@gmail.com", "Admin123");
            var list = homePageUser.GetList();           
            foreach (var element in list)
            {
                Assert.False(element.GetText() == "Schedule", "Element found");
            }
        }

        //Check counters Page
        [Test]
        public void AccessListAddresses()
        {
            WelcomePage welcomePage = new WelcomePage();
            welcomePage.Init(driver);
            var loginPage = welcomePage.SignIn();
            var homePage = loginPage.LoginInspector("inspector1@gmail.com", "Admin123");
            var checkCounters = homePage.EnterOnCheckCounters();
            checkCounters.ClickOnDropDown();
            var addresses = checkCounters.ReturnListOfDropDown();           
            foreach (var element in addresses)
            {
                Assert.True(element.IsDisplayed(), "Element not found");
            }
        }

        [Test]
        public void AbleActivateOrDeactivateMetrix()
        {
            WelcomePage welcomePage = new WelcomePage();
            welcomePage.Init(driver);
            var loginPage = welcomePage.SignIn();
            var homePage = loginPage.LoginInspector("inspector1@gmail.com", "Admin123");
            var checkCounters = homePage.EnterOnCheckCounters();
            var utility = checkCounters.SelectAddress("вулиця Університетська 2/5, Чернівці, Чернівецька область");
            var result = utility.DoSomeAction("Activate", checkCounters);
            Assert.AreEqual(result.GetText(), "Success");
            driver.Refresh();
        }

        [Test]
        public void AbleFixedOrUnfixedMetrix()
        {
            WelcomePage welcomePage = new WelcomePage();
            welcomePage.Init(driver);
            var loginPage = welcomePage.SignIn();
            var homePage = loginPage.LoginInspector("inspector1@gmail.com", "Admin123");
            var checkCounters = homePage.EnterOnCheckCounters();
            var utility = checkCounters.SelectAddress("вулиця Університетська 2/5, Чернівці, Чернівецька область");
            var result = utility.DoSomeAction("Fix", checkCounters);
            Assert.AreEqual(result.GetText(), "Success");
            driver.Refresh();
        }

        [Test]
        public void AbleSetNewValueMetrix()
        {
            string address = "вулиця Університетська 2/5, Чернівці, Чернівецька область";
            WelcomePage welcomePage = new WelcomePage();
            welcomePage.Init(driver);
            var loginPage = welcomePage.SignIn();
            var homePage = loginPage.LoginInspector("inspector1@gmail.com", "Admin123");
            var checkCounters = homePage.EnterOnCheckCounters();
            var utility = checkCounters.SelectAddress(address);
            var setCurrentValue = utility.ClickOnSetNewValue(address);
            setCurrentValue.FillNewCurrentValue("44");
            setCurrentValue.ClickOnBtnApply();
            var result = setCurrentValue.ErrorOrSuccess();
            Assert.AreEqual(result.GetText(), "Success");
        }

        //Rate client page
        [Test]
        public void ListOfClientsAble()
        {
            WelcomePage welcomePage = new WelcomePage();
            welcomePage.Init(driver);
            var loginPage = welcomePage.SignIn();
            var homePage = loginPage.LoginInspector("inspector1@gmail.com", "Admin123");
            var rateClients = homePage.EnterOnRateClient();
            var result = rateClients.ElementsIsDisplayed();            
            Assert.True(result, "List of clients empty");
        }

        [Test]
        public void RateClients()
        {
            WelcomePage welcomePage = new WelcomePage();
            welcomePage.Init(driver);
            var loginPage = welcomePage.SignIn();
            var homePage = loginPage.LoginInspector("inspector1@gmail.com", "Admin123");
            var rateClients = homePage.EnterOnRateClient();                
            var clientPage = rateClients.ReturnRateClients();
            var result = clientPage.Rate("Mariya Chuikina", 1, 2);
            Assert.AreEqual(result.GetText(), "Success");
        }

        [TearDown]
        public void PostCondition()
        {
            driver.Quit();
        }
    }
}
