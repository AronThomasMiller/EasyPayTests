using EasyPayLibrary;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPayTests
{
    public class ManagerTests
    {
        DriverWrapper driver;
        [SetUp]
        public void PreCondition()
        {
            driver = new DriverFactory().GetDriver();
            driver.Maximaze();
            driver.GoToURL();
        }

        [Test]
        public void VerifyScheduleIsVisible()
        {
            WelcomePage welcomePage = new WelcomePage();
            welcomePage.Init(driver);
            var loginPage = welcomePage.SignIn();
            var homePage = loginPage.Login("manager1@gmail.com", "Admin123");
            var inspectorPage = homePage.ClickInspectorsPage();
            var schedulePage = inspectorPage.ClickOnInspectorOlegAdamov();
            var addScheduleItemPage = schedulePage.ClickOnAddScheduleButton();
            addScheduleItemPage.ChooseDateAndTime("2019-05-01");
            addScheduleItemPage.ChooseAddress("Немирівська вулиця 1/2, Чернівці, Чернівецька область");
            addScheduleItemPage.Apply();
            Assert.IsTrue(addScheduleItemPage.IsAddressFromScheduleDisplayed(), "Address from schedule is not displayed");
        }

        [Test]
        public void VerifyHistoryIsVisible()
        {
            WelcomePage welcomePage = new WelcomePage();
            welcomePage.Init(driver);
            var loginPage = welcomePage.SignIn();
            var homePage = loginPage.Login("manager1@gmail.com", "Admin123");
            var inspectorPage = homePage.ClickInspectorsPage();
            var schedulePage = inspectorPage.ClickOnInspectorOlegAdamov();
            var tabHistory = schedulePage.ClickOnTabHistory();
            var tabCurrentMonth = tabHistory.ClickOnCurrentMonthButton();
            Assert.IsTrue(tabHistory.IsHistoryCurrentMonthVisible(), "Current month history is not visible");
            var tabPreviousMonth = tabHistory.ClickOnPreviousMonthButton();
            Assert.IsTrue(tabHistory.IsHistoryPreviousMonthVisible(), "Previous month history is not visible");
        }

        [Test]
        public void VerifyStatisticsIsVisible()
        {
            WelcomePage welcomePage = new WelcomePage();
            welcomePage.Init(driver);
            var loginPage = welcomePage.SignIn();
            var homePage = loginPage.Login("manager1@gmail.com", "Admin123");
            var inspectorPage = homePage.ClickInspectorsPage();
            var schedulePage = inspectorPage.ClickOnInspectorOlegAdamov();
            var tabStatistics = schedulePage.ClickOnTabStatistics();
            Assert.IsTrue(tabStatistics.IsCurrentAppointmentVisible() , "Current appointment is not visible");
            Assert.IsTrue(tabStatistics.IsPreviousAppointmentsVisible(), "Previous appointment is not visible");
        }

        [Test]
        public void VerifyCurrentPriceAndFuturePrice()
        {
            WelcomePage welcomePage = new WelcomePage();
            welcomePage.Init(driver);
            var loginPage = welcomePage.SignIn();
            var homePage = loginPage.Login("manager1@gmail.com", "Admin123");
            var utilityPricePage = homePage.ClickUtilityPricePage();
            utilityPricePage.SetNewPrice("24");
            utilityPricePage = BasePageObject.GetPOM<UtilityPricePage>(driver);
            utilityPricePage = utilityPricePage.SetFuturePrice("30" , "2019-05-01");
            Assert.AreEqual(utilityPricePage.CurrentPrice , "Current price: ₴24", "Current price is not 24");
            Assert.AreEqual(utilityPricePage.FuturePrice, "Future price: ₴30", "Future price is not 30");
        }

        [TearDown]
        public void PostCondition()
        {
            driver.Quit();
        }
    }
}
