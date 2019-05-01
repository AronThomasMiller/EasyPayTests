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
    class ManagerTestsTania : BaseTest
    {
        [Test]
        public void ReviewInformation()
        {
            WelcomePage page = new WelcomePage();
            page.Init(driver);
            var loginPage = page.SignIn();
            var homePage = (HomePageManager)loginPage.Login("manager1@gmail.com", "Admin123");
            var listOfInspectors = homePage.NavigateToInspectorsListPage();
            var schedule = listOfInspectors.ChooseInspector("Oleg Adamov");
            var btnAddInspector = schedule.GetAddScheduleItem();
            Assert.IsTrue(btnAddInspector.IsDisplayed());
        }

        [Test]
        public void AddTasksToInspectorsSchedule()
        {
            WelcomePage page = new WelcomePage();
            page.Init(driver);
            var loginPage = page.SignIn();
            var homePage = (HomePageManager)loginPage.Login("manager1@gmail.com", "Admin123");
            var listOfInspectors = homePage.NavigateToInspectorsListPage();
            var schedule = listOfInspectors.ChooseInspector("Oleg Adamov");
            var addItem = schedule.AddItem();
            var deleteItem = addItem.ApplyToAdd("20190510", "вулиця Руська 241/245, Чернівці, Чернівецька область");

            Assert.IsTrue(schedule.GetTask().IsDisplayed());
            // postCondition
            var confirm = deleteItem.DeleteItem();
            confirm.ApplyToDelete();
            //
        }

        [Test]
        public void EditTasksToInspectorsSchedule()
        {
            WelcomePage page = new WelcomePage();
            page.Init(driver);
            var loginPage = page.SignIn();
            var homePage = (HomePageManager)loginPage.Login("manager1@gmail.com", "Admin123");
            var listOfInspectors = homePage.NavigateToInspectorsListPage();
            var schedule = listOfInspectors.ChooseInspector("Oleg Adamov");

            // preCondition
            var addItem = schedule.AddItem();
            var chooseItemToEdit = addItem.ApplyToAdd("20190510", "вулиця Руська 241/245, Чернівці, Чернівецька область");
            //

            var editItem = chooseItemToEdit.EditItem();
            var deleteItem = editItem.ApplyToEdit("20190510", "вулиця Горіхівська 100/2, Чернівці, Чернівецька область");

            Assert.IsTrue(schedule.GetTask().IsDisplayed());
            // postCondition
            var confirm = deleteItem.DeleteItem();
            confirm.ApplyToDelete();
            //
        }

        [Test]
        public void DeleteTasksFromInspectorsSchedule()
        {
            WelcomePage page = new WelcomePage();
            page.Init(driver);
            var loginPage = page.SignIn();
            var homePage = (HomePageManager)loginPage.Login("manager1@gmail.com", "Admin123");
            var listOfInspectors = homePage.NavigateToInspectorsListPage();
            var schedule = listOfInspectors.ChooseInspector("Oleg Adamov");

            //preCondition
            var addItem = schedule.AddItem();
            var deleteItem = addItem.ApplyToAdd("20190510", "вулиця Руська 241/245, Чернівці, Чернівецька область");
            //

            var confirm = deleteItem.DeleteItem();
            confirm.ApplyToDelete();
            //var task = schedule.GetTask();
            //Assert.IsTrue(!task.IsDisplayed());

        }

        [Test]
        public void NotAvailableToAddInspector()
        {
            WelcomePage page = new WelcomePage();
            page.Init(driver);
            var loginPage = page.SignIn();
            var homePage = (HomePageManager)loginPage.Login("manager1@gmail.com", "Admin123");
            var listOfInspectors = homePage.NavigateToInspectorsListPage();

            // preCondition
            var addIvan = listOfInspectors.ClickToAddInspector();
            addIvan.AddInspector("Ivan Ivanov");
            driver.Refresh();
            //

            var close = listOfInspectors.ClickToAddInspector();
            Assert.IsTrue(close.GetCaption().IsDisplayed());
            close.CloseWindow();
            driver.Refresh();

            // postCondition
            var removeIvan = listOfInspectors.RemoveInspector("Ivan Ivanov");
            removeIvan.ConfirmRemoving();
            //
        }

        [Test]
        public void RemoveInspector()
        {
            WelcomePage page = new WelcomePage();
            page.Init(driver);
            var loginPage = page.SignIn();
            var homePage = (HomePageManager)loginPage.Login("manager1@gmail.com", "Admin123");
            var listOfInspectors = homePage.NavigateToInspectorsListPage();

            // preCondition
            var addIvan = listOfInspectors.ClickToAddInspector();
            addIvan.AddInspector("Ivan Ivanov");
            driver.Refresh();
            //

            var removeIvan = listOfInspectors.RemoveInspector("Ivan Ivanov");
            removeIvan.ConfirmRemoving();
        }

        [Test]
        public void AddInspector()
        {
            WelcomePage page = new WelcomePage();
            page.Init(driver);
            var loginPage = page.SignIn();
            var homePage = (HomePageManager)loginPage.Login("manager1@gmail.com", "Admin123");
            var listOfInspectors = homePage.NavigateToInspectorsListPage();
            var addIvan = listOfInspectors.ClickToAddInspector();
            addIvan.AddInspector("Ivan Ivanov");
            driver.Refresh();

            Assert.IsTrue(listOfInspectors.GetInspector("Ivan Ivanov").IsDisplayed());

            // postCondition
            var removeIvan = listOfInspectors.RemoveInspector("Ivan Ivanov");
            removeIvan.ConfirmRemoving();
            //
        }

        [Test]
        public void SetNewPrice()
        {
            WelcomePage page = new WelcomePage();
            page.Init(driver);
            var loginPage = page.SignIn();
            var homePage = (HomePageManager)loginPage.Login("manager1@gmail.com", "Admin123");
            var setNewPrice = homePage.GetPricesToEdit();
            setNewPrice.ClickOnSetNewPriceButton();
            setNewPrice.SetNewPrice("7");
            driver.Refresh();
            var actualPrice = setNewPrice.GetCurrentPrice();

            Assert.AreEqual("Current price: ₴7", actualPrice);


        }

        [Test]
        public void SetFuturePrice()
        {
            WelcomePage page = new WelcomePage();
            page.Init(driver);
            var loginPage = page.SignIn();
            var homePage = (HomePageManager)loginPage.Login("manager1@gmail.com", "Admin123");
            var setFuturePrice = homePage.GetPricesToEdit();
            setFuturePrice.ClickOnSetFuturePriceButton();
            setFuturePrice.SetFuturePrice("20", "2019-05-02");
            driver.Refresh();
            var actualPrice = setFuturePrice.GetFuturePrice();
            var actualActivationDate = setFuturePrice.GetActivationDate();
            Assert.AreEqual("Future price: ₴20", actualPrice);
            Assert.AreEqual("Next activation date: 2 MAY 2019", actualActivationDate);

        }
    }
}
