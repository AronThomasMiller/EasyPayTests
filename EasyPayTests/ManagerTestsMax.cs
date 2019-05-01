using EasyPayLibrary;
using EasyPayLibrary.Pages.Manager;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPayTests
{
    class ManagerTestsMax : BaseTest
    {
        [Test]
        public void VerifyScheduleIsVisible()
        {
            WelcomePage welcomePage = new WelcomePage();
            welcomePage.Init(driver);
            var loginPage = welcomePage.SignIn();
            var homePage = (HomePageManager)loginPage.Login("manager1@gmail.com", "Admin123");
            var inspectorPage = homePage.NavigateToInspectorsListPage();
            var schedulePage = inspectorPage.ClickOnInspectorOlegAdamov();
            var addScheduleItemPage = schedulePage.AddItem();            
            addScheduleItemPage.ApplyToAdd("2019-05-01", "Немирівська вулиця 1/2, Чернівці, Чернівецька область");
            Assert.IsTrue(addScheduleItemPage.IsAddressFromScheduleDisplayed(), "Address from schedule is not displayed");
        }

        [Test]
        public void VerifyHistoryIsVisible()
        {
            WelcomePage welcomePage = new WelcomePage();
            welcomePage.Init(driver);
            var loginPage = welcomePage.SignIn();
            var homePage = (HomePageManager)loginPage.Login("manager1@gmail.com", "Admin123");
            var inspectorPage = homePage.NavigateToInspectorsListPage();
            var schedulePage = inspectorPage.ClickOnInspectorOlegAdamov();
            var tabHistory = schedulePage.ClickOnTabHistory();
            var tabCurrentMonth = tabHistory.ClickOnCurrentMonthButton();
            Assert.IsTrue(tabHistory.IsHistoryCurrentMonthVisible("Нагірна","15.4.2019"), "Current month history is not visible");
            var tabPreviousMonth = tabHistory.ClickOnPreviousMonthButton();
            Assert.IsTrue(tabHistory.IsHistoryPreviousMonthVisible("21.4.2019"), "Previous month history is not visible");
        }

        [Test]
        public void VerifyStatisticsIsVisible()
        {
            WelcomePage welcomePage = new WelcomePage();
            welcomePage.Init(driver);
            var loginPage = welcomePage.SignIn();
            var homePage = (HomePageManager)loginPage.Login("manager1@gmail.com", "Admin123");
            var inspectorPage = homePage.NavigateToInspectorsListPage();
            var schedulePage = inspectorPage.ClickOnInspectorOlegAdamov();
            var tabStatistics = schedulePage.ClickOnTabStatistics();
            Assert.IsTrue(tabStatistics.IsCurrentAppointmentVisible(), "Current appointment is not visible");
            Assert.IsTrue(tabStatistics.IsPreviousAppointmentsVisible(), "Previous appointment is not visible");
        }

        [Test]
        public void VerifyCurrentPriceAndFuturePrice()
        {
            WelcomePage welcomePage = new WelcomePage();
            welcomePage.Init(driver);
            var loginPage = welcomePage.SignIn();
            var homePage = (HomePageManager)loginPage.Login("manager1@gmail.com", "Admin123");
            var utilityPricePage = homePage.GetPricesToEdit();
            utilityPricePage.SetNewPrice("24");
            utilityPricePage.Init(driver);
            utilityPricePage.SetFuturePrice("30", "2019-05-01");
            Assert.AreEqual("Current price: ₴24", "Current price: ₴24", "Current price is not 24");
            Assert.AreEqual("Future price: ₴30", "Future price: ₴30", "Future price is not 30");
        }
    }
}
