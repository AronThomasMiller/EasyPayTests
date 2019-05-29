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
    [Category("All")]
    [Category("Inspector")]
    [Parallelizable(ParallelScope.Fixtures)]
    public class Inspector : BaseTest
    {
        HomePageInspector homePage;
        string address = "вулиця Університетська 2/5, Чернівці, Чернівецька область";

        [SetUp]
        public override void PreCondition()
        {
            base.PreCondition();
            var loginPage = welcomePage.SignIn();
            LogProgress("Try authorized as 'Inspector's' role");
            homePage = loginPage.LoginAsInspector("inspector1@gmail.com", "Admin123");
        }

        [Test]
        public void SignInInspectorCorrect()
        {
            var header = driver.GetByXpath("//h3[contains(text(),'Inspector')]");
            Assert.AreEqual(header.GetText(), "INSPECTOR", "Inspector isn't loged in");
        }

        //schedule Page
        [Test]
        public void ScheduleAvailable()
        {
            LogProgress("Try navigate to Schedule page");
            var schedulePage = homePage.NavigateToSchedule();
            var result = schedulePage.ScheduleIsDisplayed();
            Assert.True(result, "Not found calendar");
        }


        //Check counters Page
        [Test]
        public void AccessListAddresses()
        {
            LogProgress("Try navigate to Check Counters page");
            var checkCounters = homePage.NavigateToCheckCounters();
            LogProgress($"Try sellect address + {address}");
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
            LogProgress("Try navigate to Check Counters page");
            var checkCountersPage = homePage.NavigateToCheckCounters();
            LogProgress($"Try sellect address + {address}");
            var utility = checkCountersPage.SelectAddress(address);
            LogProgress("Try activate or deactivate metrix");
            var result = utility.DoSomeAction("Activate", checkCountersPage);
            Assert.AreEqual(result.GetText(), "Success");
            driver.Refresh();
        }

        [Test]
        public void AbleFixedOrUnfixedMetrix()
        {
            LogProgress("Try navigate to Check Counters page");
            var checkCounters = homePage.NavigateToCheckCounters();
            LogProgress($"Try sellect address + {address}");
            var utility = checkCounters.SelectAddress(address);
            LogProgress("Try fix or unfixed metrix");
            var result = utility.DoSomeAction("Fix", checkCounters);
            Assert.AreEqual(result.GetText(), "Success");
            driver.Refresh();
        }

        [Test]
        public void AbleSetNewValueMetrix()
        {
            LogProgress("Try navigate to Check Counters page");
            var checkCounters = homePage.NavigateToCheckCounters();
            LogProgress($"Try sellect address + {address}");
            var utility = checkCounters.SelectAddress(address);
            LogProgress("Try set new value metrix");
            var setCurrentValue = utility.ClickOnSetNewValue(address);
            LogProgress("Try set value '44' metrix");
            setCurrentValue.FillNewCurrentValue("44");
            LogProgress("Try click on btn apply");
            setCurrentValue.ClickOnBtnApply();
            var result = setCurrentValue.ErrorOrSuccess();
            Assert.AreEqual(result.GetText(), "Success");
        }

        [Test]
        public void ListOfClientsAble()
        {
            LogProgress("Try navigate to Rate clients page");
            var rateClients = homePage.NavigateToRateClients();
            var result = rateClients.ElementsIsDisplayed();
            Assert.True(result, "List of clients empty");
        }

        [Test(Description = "Repeat 2 times")]
        public void RateClients()
        {
            LogProgress("Try navigate to Rate clients page");
            var rateClients = homePage.NavigateToRateClients();
            var clientPage = rateClients.ReturnRateClients();
            var firstRow = clientPage.GetLastRow();
            LogProgress("Try click on stars rate");
            var result = firstRow.Rate(4, true);
            Assert.AreEqual(result.GetText(), "Success");
        }
    }
}
