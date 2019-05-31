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
    [TestFixture]
    [Category("All")]
    [Category("Manager")]
    [Parallelizable(ParallelScope.Fixtures)]
    public class Manager : BaseTest
    {
        HomePageManager homePage;

        [SetUp]
        public override void PreCondition()
        {
            base.PreCondition();
            LogProgress("Manager is signing in");
            var loginPage = welcomePage.SignIn();
            homePage = loginPage.LoginAsManager("manager1@gmail.com", "Admin123");
        }

        [Test]
        public void ReviewInformation()
        {
            LogProgress("Manager is going to list of inspectors");
            var listOfInspectors = homePage.NavigateToInspectorsList();
            LogProgress("Manager is choosing Oleg Adamov");
            var schedule = listOfInspectors.NavigateToInspectorsSchedule("Oleg Adamov");
            var btnAddInspector = schedule.GetAddScheduleItem();
            Assert.IsTrue(btnAddInspector.IsDisplayed());
        }

        [Test]
        public void AddTasksToInspectorsSchedule()
        {
            LogProgress("Manager is going to list of inspectors");
            var listOfInspectors = homePage.NavigateToInspectorsList();
            LogProgress("Manager is choosing Oleg Adamov");
            var schedule = listOfInspectors.NavigateToInspectorsSchedule("Oleg Adamov");
            LogProgress("Manager is adding an item to inspector's schedule");
            var addItem = schedule.AddItem();
            var deleteItem = addItem.ApplyToAdd("20190530", "вулиця Руська 241/245, Чернівці, Чернівецька область");

            Assert.IsTrue(schedule.GetTask().IsDisplayed(), "Schedule isn't displayed");
            // postCondition
            LogProgress("Manager is remowing an item from inspector's schedule");
            var confirm = deleteItem.DeleteItem();
            confirm.ApplyToDelete();
        }

        [Test]
        public void EditTasksToInspectorsSchedule()
        {
            LogProgress("Manager is going to list of inspectors");
            var listOfInspectors = homePage.NavigateToInspectorsList();
            LogProgress("Manager is choosing Oleg Adamov");
            var schedule = listOfInspectors.NavigateToInspectorsSchedule("Oleg Adamov");

            // preCondition
            LogProgress("Manager is adding an item to inspector's schedule");
            var addItem = schedule.AddItem();
            var chooseItemToEdit = addItem.ApplyToAdd("20190530", "вулиця Руська 241/245, Чернівці, Чернівецька область");

            LogProgress("Manager is editing an item in inspector's schedule");
            var editItem = chooseItemToEdit.EditItem();
            var deleteItem = editItem.ApplyToEdit("20190531", "вулиця Горіхівська 100/2, Чернівці, Чернівецька область");
            Assert.IsTrue(schedule.GetTask().IsDisplayed(), "Schedule isn't displayed");

            // postCondition
            LogProgress("Manager is remowing an item from inspector's schedule");
            var confirm = deleteItem.DeleteItem();
            confirm.ApplyToDelete();
        }

        [Test]
        public void DeleteTasksFromInspectorsSchedule()
        {
            LogProgress("Manager is going to list of inspectors");
            var listOfInspectors = homePage.NavigateToInspectorsList();
            LogProgress("Manager is choosing Oleg Adamov");
            var schedule = listOfInspectors.NavigateToInspectorsSchedule("Oleg Adamov");

            //preCondition
            LogProgress("Manager is adding an item to inspector's schedule");
            var addItem = schedule.AddItem();
            var deleteItem = addItem.ApplyToAdd("20190530", "вулиця Руська 241/245, Чернівці, Чернівецька область");

            LogProgress("Manager is remowing an item from inspector's schedule");
            var confirm = deleteItem.DeleteItem();
            confirm.ApplyToDelete();
        }

        [Test]
        public void NotAvailableToAddInspector()
        {
            LogProgress("Manager is going to list of inspectors");
            var listOfInspectors = homePage.NavigateToInspectorsList();

            // preCondition
            LogProgress("Manager is adding Ivan Ivanov to the list of inspectors");
            var addIvan = listOfInspectors.ClickToAddInspector();
            addIvan.AddInspector("Ivan Ivanov");
            driver.Refresh();

            LogProgress("Manager is trying to add an inspector to the list of inspectors");
            var close = listOfInspectors.ClickToAddInspector();
            var actualCaption = close.GetCaption();
            Assert.AreEqual("All inspectors are busy", actualCaption, "Busy isn't displayed");            
            close.CloseWindow();
            driver.Refresh();

            // postCondition
            LogProgress("Manager is removing Ivan Ivanov from the list of inspectors");
            var removeIvan = listOfInspectors.RemoveInspector("Ivan Ivanov");
            removeIvan.ConfirmRemoving();
            
            
        }

        [Test]
        public void RemoveInspector()
        {
            LogProgress("Manager is going to list of inspectors");
            var listOfInspectors = homePage.NavigateToInspectorsList();

            // preCondition
            LogProgress("Manager is adding Ivan Ivanov to the list of inspectors");
            var addIvan = listOfInspectors.ClickToAddInspector();
            addIvan.AddInspector("Ivan Ivanov");
            driver.Refresh();

            LogProgress("Manager is removing Ivan Ivanov from the list of inspectors");
            var removeIvan = listOfInspectors.RemoveInspector("Ivan Ivanov");
            removeIvan.ConfirmRemoving();
        }

        [Test]
        public void AddInspector()
        {
            LogProgress("Manager is going to list of inspectors");
            var listOfInspectors = homePage.NavigateToInspectorsList();
            LogProgress("Manager is adding Ivan Ivanov to the list of inspectors");
            var addIvan = listOfInspectors.ClickToAddInspector();
            addIvan.AddInspector("Ivan Ivanov");
            driver.Refresh();

            Assert.IsTrue(listOfInspectors.GetInspector("Ivan Ivanov").IsDisplayed(), "Ivan Ivanov isn't displayed");

            // postCondition
            LogProgress("Manager is removing Ivan Ivanov from the list of inspectors");
            var removeIvan = listOfInspectors.RemoveInspector("Ivan Ivanov");
            removeIvan.ConfirmRemoving();
        }

        [Test]
        public void SetNewPrice()
        {
            LogProgress("Manager is going to utility price page");
            var setNewPrice = homePage.NavigateToUtilityPrice();
            LogProgress("Manager is setting a new price");
            setNewPrice.ClickOnSetNewPriceButton();
            var formSetNewPrice = setNewPrice.ClickOnSetNewPriceButton();
            formSetNewPrice.SetNewPrice("7");
            driver.Refresh();
            var actualPrice = setNewPrice.GetCurrentPrice();
            Assert.AreEqual("Current price: ₴7", actualPrice, "Wrong price");
        }

        [Test]
        public void SetFuturePrice()
        {
            LogProgress("Manager is going to utility price page");
            var setFuturePrice = homePage.NavigateToUtilityPrice();
            LogProgress("Manager is setting a future price");
            setFuturePrice.ClickOnSetFuturePriceButton();
            var formSetFuturePrice = setFuturePrice.ClickOnSetFuturePriceButton();
            formSetFuturePrice.SetFuturePrice("20", "2019-05-30");
            driver.Refresh();
            var actualPrice = setFuturePrice.GetFuturePrice();
            var actualActivationDate = setFuturePrice.GetActivationDate();
            Assert.AreEqual("Future price: ₴20", actualPrice, "Wrong price");
            Assert.AreEqual("Next activation date: 30 MAY 2019", actualActivationDate, "Wrong  activation date");
        }

        [Test]
        public void VerifyThatManagerHasAccesToAccount()
        {
            Assert.IsTrue(driver.GetUrl().Contains("http://localhost:8080/home"), "Wrong Url");
            Assert.AreEqual("MANAGER", GeneralPage.GetRole(driver), "manager can't access his account");
        }

        [Test]
        public void VerifyScheduleIsVisible()
        {
            LogProgress("Manager is navigating to inspectors list page");
            var inspectorPage = homePage.NavigateToInspectorsList();
            LogProgress("Manager is choosing inspector: Oleg Adamov");
            var schedulePage = inspectorPage.NavigateToInspectorsSchedule("Oleg Adamov");
            LogProgress("Manager is clicking on Add Schedule Item Button");
            var addScheduleItemPage = schedulePage.AddItem();
            LogProgress("Manager is entering date and address");
            addScheduleItemPage.ApplyToAdd("2019-05-01", "Немирівська вулиця 1/2, Чернівці, Чернівецька область");
            var isAddressFromScheduleDisplayed = addScheduleItemPage.IsAddressFromScheduleDisplayed();
            Assert.AreEqual(true, isAddressFromScheduleDisplayed, "Address from schedule is not displayed");
        }

        [Test]
        public void VerifyHistoryIsVisible()
        {
            using (var conn = new DatabaseManipulation.DatabaseMaster())
            {
                var prevMonthDate = DateTime.Today.AddMonths(-1);
                var currentMothDate = DateTime.Today;
                var todayStr = currentMothDate.ToString().Replace('.', '-');
                var prevMothStr = prevMonthDate.ToString().Replace('.', '-');
                conn.Open();
                conn.ChangeInDB("Truncate table schedule_history");
                conn.ChangeInDB($"insert into schedule_history values (16,'Overdue visit','{todayStr}','OVERDUE','{todayStr}',16,109)");
                conn.ChangeInDB($"insert into schedule_history values (17,'Overdue visit','{prevMothStr}','OVERDUE','{prevMothStr}',16,109)");
            }

            var inspectorPage = homePage.NavigateToInspectorsList();
            LogProgress("Manager is choosing inspector: Oleg Adamov");
            var schedulePage = inspectorPage.NavigateToInspectorsSchedule("Oleg Adamov");
            LogProgress("Manager is clicking on tab history");
            var tabHistory = schedulePage.ClickOnTabHistory();
            LogProgress("Manager is clicking on current month button");
            var tabCurrentMonth = tabHistory.ClickOnCurrentMonthButton();
            var currentMonthContainsAddress = tabHistory.CurrentMonthContainsAddress("вулиця Пушкіна ", $"{DateTime.Today.ToString("dd.M.yyyy")}");
            Assert.AreEqual(true, currentMonthContainsAddress, "Current month history is not visible");
            var tabPreviousMonth = tabHistory.ClickOnPreviousMonthButton();
            var previousMonthContainsAddress = tabHistory.PreviousMonthContainsAddress($"{DateTime.Today.AddMonths(-1).ToString("dd.M.yyyy")}");
            Assert.AreEqual(true, previousMonthContainsAddress, $"Previous month history doesn't contain date: {DateTime.Today.AddMonths(-1).ToString("dd.M.yyyy")}");
        }

        [Test]
        public void VerifyStatisticsIsVisible()
        {
            LogProgress("Manager is navigating to inspectors list page");
            var inspectorPage = homePage.NavigateToInspectorsList();
            LogProgress("Manager is choosing inspector: Oleg Adamov");
            var schedulePage = inspectorPage.NavigateToInspectorsSchedule("Oleg Adamov");
            LogProgress("Manager is clicking on tab statistics");
            var tabStatistics = schedulePage.ClickOnTabStatistics();
            var isCurrentAppointmentVisible = tabStatistics.IsCurrentAppointmentVisible();
            var isPreviousAppointmentsVisible = tabStatistics.IsPreviousAppointmentsVisible();
            Assert.AreEqual(true, isCurrentAppointmentVisible, "Current appointment is not visible");
            Assert.AreEqual(true, isPreviousAppointmentsVisible, "Previous appointment is not visible");
        }

        [Test]
        public void VerifyCurrentPriceAndFuturePrice()
        {
            LogProgress("Manager is navigating to utility price page");
            var utilityPricePage = homePage.NavigateToUtilityPrice();
            LogProgress("Manager is setting new price");
            var formSetNewPrice = utilityPricePage.ClickOnSetNewPriceButton();
            formSetNewPrice.SetNewPrice("24");
            utilityPricePage.Init(driver);
            LogProgress("Manager is setting new future price");
            var formSetFuturePrice = utilityPricePage.ClickOnSetFuturePriceButton();
            formSetFuturePrice.SetFuturePrice("30", "2019-05-01");
            Assert.AreEqual("Current price: ₴24", "Current price: ₴24", "Current price is not 24");
            Assert.AreEqual("Future price: ₴30", "Future price: ₴30", "Future price is not 30");
        }
    }
}
