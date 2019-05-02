using EasyPayLibrary;
using EasyPayLibrary.Pages.Manager;
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
    public class Manager
    {
        DriverWrapper driver;
        HomePageManager homePage;

        [SetUp]
        public void PreCondition()
        {
            driver = new DriverFactory().GetDriver();
            driver.Maximaze();
            driver.GoToURL();
            WelcomePage page = new WelcomePage();
            page.Init(driver);
            var loginPage = page.SignIn();
            homePage = (HomePageManager)loginPage.Login("manager1@gmail.com", "Admin123");
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
        public void ReviewInformation()
        {
            var listOfInspectors = homePage.NavigateToInspectorsList();
            var schedule = listOfInspectors.NavigateToInspectorsSchedule("Oleg Adamov");
            var btnAddInspector = schedule.GetAddScheduleItem();
            Assert.IsTrue(btnAddInspector.IsDisplayed());
        }

        [Test]
        public void AddTasksToInspectorsSchedule()
        {
            var listOfInspectors = homePage.NavigateToInspectorsList();
            var schedule = listOfInspectors.NavigateToInspectorsSchedule("Oleg Adamov");
            var addItem = schedule.AddItem();
            var deleteItem = addItem.ApplyToAdd("20190510", "вулиця Руська 241/245, Чернівці, Чернівецька область");

            Assert.IsTrue(schedule.GetTask().IsDisplayed());
            // postCondition
            var confirm = deleteItem.DeleteItem();
            confirm.ApplyToDelete();
        }

        [Test]
        public void EditTasksToInspectorsSchedule()
        {
            var listOfInspectors = homePage.NavigateToInspectorsList();
            var schedule = listOfInspectors.NavigateToInspectorsSchedule("Oleg Adamov");

            // preCondition
            var addItem = schedule.AddItem();
            var chooseItemToEdit = addItem.ApplyToAdd("20190510", "вулиця Руська 241/245, Чернівці, Чернівецька область");

            var editItem = chooseItemToEdit.EditItem();
            var deleteItem = editItem.ApplyToEdit("20190510", "вулиця Горіхівська 100/2, Чернівці, Чернівецька область");

            Assert.IsTrue(schedule.GetTask().IsDisplayed());
            // postCondition
            var confirm = deleteItem.DeleteItem();
            confirm.ApplyToDelete();
        }

        [Test]
        public void DeleteTasksFromInspectorsSchedule()
        {
            var listOfInspectors = homePage.NavigateToInspectorsList();
            var schedule = listOfInspectors.NavigateToInspectorsSchedule("Oleg Adamov");

            //preCondition
            var addItem = schedule.AddItem();
            var deleteItem = addItem.ApplyToAdd("20190510", "вулиця Руська 241/245, Чернівці, Чернівецька область");

            var confirm = deleteItem.DeleteItem();
            confirm.ApplyToDelete();
        }

        [Test]
        public void NotAvailableToAddInspector()
        {
            var listOfInspectors = homePage.NavigateToInspectorsList();

            // preCondition
            var addIvan = listOfInspectors.ClickToAddInspector();
            addIvan.AddInspector("Ivan Ivanov");
            driver.Refresh();

            var close = listOfInspectors.ClickToAddInspector();
            Assert.IsTrue(close.GetCaption().IsDisplayed());
            close.CloseWindow();
            driver.Refresh();

            // postCondition
            var removeIvan = listOfInspectors.RemoveInspector("Ivan Ivanov");
            removeIvan.ConfirmRemoving();
        }

        [Test]
        public void RemoveInspector()
        {
            var listOfInspectors = homePage.NavigateToInspectorsList();

            // preCondition
            var addIvan = listOfInspectors.ClickToAddInspector();
            addIvan.AddInspector("Ivan Ivanov");
            driver.Refresh();

            var removeIvan = listOfInspectors.RemoveInspector("Ivan Ivanov");
            removeIvan.ConfirmRemoving();
        }

        [Test]
        public void AddInspector()
        {
            var listOfInspectors = homePage.NavigateToInspectorsList();
            var addIvan = listOfInspectors.ClickToAddInspector();
            addIvan.AddInspector("Ivan Ivanov");
            driver.Refresh();

            Assert.IsTrue(listOfInspectors.GetInspector("Ivan Ivanov").IsDisplayed());

            // postCondition
            var removeIvan = listOfInspectors.RemoveInspector("Ivan Ivanov");
            removeIvan.ConfirmRemoving();
        }

        [Test]
        public void SetNewPrice()
        {
            var setNewPrice = homePage.NavigateToUtilityPrice();
            setNewPrice.ClickOnSetNewPriceButton();
            setNewPrice.SetNewPrice("7");
            driver.Refresh();
            var actualPrice = setNewPrice.GetCurrentPrice();
            Assert.AreEqual("Current price: ₴7", actualPrice);
        }

        [Test]
        public void SetFuturePrice()
        {
            var setFuturePrice = homePage.NavigateToUtilityPrice();
            setFuturePrice.ClickOnSetFuturePriceButton();
            setFuturePrice.SetFuturePrice("20", "2019-05-05");
            driver.Refresh();
            var actualPrice = setFuturePrice.GetFuturePrice();
            var actualActivationDate = setFuturePrice.GetActivationDate();
            Assert.AreEqual("Future price: ₴20", actualPrice);
            Assert.AreEqual("Next activation date: 5 MAY 2019", actualActivationDate);
        }

        [Test]
        public void VerifyThatManagerHasAccesToAccount()
        {
            Assert.IsTrue(driver.getUrl().Contains("http://localhost:8080/home"));
            Assert.AreEqual("MANAGER", GeneralPage.GetRole(driver));
        }

        [Test]
        public void VerifyScheduleIsVisible()
        {
            var inspectorPage = homePage.NavigateToInspectorsList();
            var schedulePage = inspectorPage.NavigateToInspectorsSchedule("Oleg Adamov");
            var addScheduleItemPage = schedulePage.AddItem();
            addScheduleItemPage.ApplyToAdd("2019-05-01", "Немирівська вулиця 1/2, Чернівці, Чернівецька область");
            Assert.IsTrue(addScheduleItemPage.IsAddressFromScheduleDisplayed(), "Address from schedule is not displayed");
        }

        [Test]
        public void VerifyHistoryIsVisible()
        {
            var inspectorPage = homePage.NavigateToInspectorsList();
            var schedulePage = inspectorPage.NavigateToInspectorsSchedule("Oleg Adamov");
            var tabHistory = schedulePage.ClickOnTabHistory();
            var tabCurrentMonth = tabHistory.ClickOnCurrentMonthButton();
            Assert.IsTrue(tabHistory.IsHistoryCurrentMonthVisible("Нагірна", "15.4.2019"), "Current month history is not visible");
            var tabPreviousMonth = tabHistory.ClickOnPreviousMonthButton();
            Assert.IsTrue(tabHistory.IsHistoryPreviousMonthVisible("21.4.2019"), "Previous month history is not visible");
        }

        [Test]
        public void VerifyStatisticsIsVisible()
        {
            var inspectorPage = homePage.NavigateToInspectorsList();
            var schedulePage = inspectorPage.NavigateToInspectorsSchedule("Oleg Adamov");
            var tabStatistics = schedulePage.ClickOnTabStatistics();
            Assert.IsTrue(tabStatistics.IsCurrentAppointmentVisible(), "Current appointment is not visible");
            Assert.IsTrue(tabStatistics.IsPreviousAppointmentsVisible(), "Previous appointment is not visible");
        }

        [Test]
        public void VerifyCurrentPriceAndFuturePrice()
        {
            var utilityPricePage = homePage.NavigateToUtilityPrice();
            utilityPricePage.SetNewPrice("24");
            utilityPricePage.Init(driver);
            utilityPricePage.SetFuturePrice("30", "2019-05-01");
            Assert.AreEqual("Current price: ₴24", "Current price: ₴24", "Current price is not 24");
            Assert.AreEqual("Future price: ₴30", "Future price: ₴30", "Future price is not 30");
        }
    }
}
