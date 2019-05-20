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
    [Category("Manager")]
    [Parallelizable(ParallelScope.Fixtures)]
    public class Manager:BaseTest
    {
        HomePageManager homePage;

        [SetUp]
        public override void PreCondition()
        {
            base.PreCondition();
            var loginPage = welcome.SignIn();
            homePage = (HomePageManager)loginPage.Login("manager1@gmail.com", "Admin123");
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

            Assert.IsTrue(schedule.GetTask().IsDisplayed(),"Schedule isn't dosplayed");
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

            Assert.IsTrue(schedule.GetTask().IsDisplayed(),"Schedule isn't dosplayed");
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
            Assert.IsTrue(close.GetCaption().IsDisplayed(),"Busy isn't displayed");
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

            Assert.IsTrue(listOfInspectors.GetInspector("Ivan Ivanov").IsDisplayed(),"Ivan Ivanov isn't displayed");

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
            Assert.AreEqual("Current price: ₴7", actualPrice,"Wrong price");
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
            Assert.AreEqual("Future price: ₴20", actualPrice,"Wrong price");
            Assert.AreEqual("Next activation date: 5 MAY 2019", actualActivationDate,"Wrong  activation date");
        }

        [Test]
        public void VerifyThatManagerHasAccesToAccount()
        {
            Assert.IsTrue(driver.getUrl().Contains("http://localhost:8080/home"),"Wrong Url");
            Assert.AreEqual("MANAGER", GeneralPage.GetRole(driver),"manager can't access his account");
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
            Assert.IsTrue(tabHistory.IsHistoryCurrentMonthVisible("Нагірна", "10.5.2018"), "Current month history is not visible");
            var tabPreviousMonth = tabHistory.ClickOnPreviousMonthButton();
            Assert.IsTrue(tabHistory.IsHistoryPreviousMonthVisible("21.4.2019"), "Previous month history doesn't contain date: 21.4.2019");
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
