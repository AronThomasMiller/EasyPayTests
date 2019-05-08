using EasyPayLibrary;
using EasyPayLibrary.HomePages;
using EasyPayLibrary.InspectorSidebar;
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
    [Parallelizable(ParallelScope.Fixtures)]
    public class Inspector:BaseTest
    {
        HomePageInspector homePage;
        string address = "вулиця Університетська 2/5, Чернівці, Чернівецька область";

        [SetUp]
        public override void PreCondition()
        {
            base.PreCondition();
            var loginPage = welcome.SignIn();
            homePage = (HomePageInspector)loginPage.Login("inspector1@gmail.com", "Admin123");
        }

        [Test]
        public void SignInInspectorCorrect()
        {

            var header = driver.GetByXpath("//h3[contains(text(),'Inspector')]");
            Assert.AreEqual(header.GetText(), "INSPECTOR","Inspector isn't loged in");
        }

        //schedule Page
        [Test]
        public void ScheduleAvailable()
        {
            var schedulePage = homePage.NavigateToSchedule();
            var result = schedulePage.ScheduleIsDisplayed();
            Assert.True(result, "Not found calendar");
        }

        
        //Check counters Page
        [Test]
        public void AccessListAddresses()
        {
            var checkCounters = homePage.NavigateToCheckCounters();
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
            var checkCounters = homePage.NavigateToCheckCounters();
            var utility = checkCounters.SelectAddress("вулиця Університетська 2/5, Чернівці, Чернівецька область");
            var result = utility.DoSomeAction("Activate", checkCounters);
            Assert.AreEqual(result.GetText(), "Success");
            driver.Refresh();
        }

        [Test]
        public void AbleFixedOrUnfixedMetrix()
        {
            var checkCounters = homePage.NavigateToCheckCounters();
            var utility = checkCounters.SelectAddress("вулиця Університетська 2/5, Чернівці, Чернівецька область");
            var result = utility.DoSomeAction("Fix", checkCounters);
            Assert.AreEqual(result.GetText(), "Success");
            driver.Refresh();
        }

        [Test]
        public void AbleSetNewValueMetrix()
        {         
            var checkCounters = homePage.NavigateToCheckCounters();
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
            var rateClients = homePage.NavigateToRateClients();
            var result = rateClients.ElementsIsDisplayed();
            Assert.True(result, "List of clients empty");
        }

        [Test]
        public void RateClients()
        {
            var rateClients = homePage.NavigateToRateClients();
            var clientPage = rateClients.ReturnRateClients();
            var result = clientPage.Rate("Masha Chuikina", 1, 2);
            Assert.AreEqual(result.GetText(), "Success");
        }
    }
}
