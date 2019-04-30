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
        public void ReviewInformation()
        {
            WelcomePage page = new WelcomePage();
            page.Init(driver);
            var loginPage = page.SignIn();
            var homePage = loginPage.Login("manager1@gmail.com", "Admin123");
            var listOfInspectors = homePage.GetInspectorsList();
            var schedule = listOfInspectors.ChooseOlegAdamov();
            var btnAddInspector = schedule.GetAddScheduleItem();
            Assert.IsTrue(btnAddInspector.IsDisplayed());
        }

        [Test]
        public void AddTasksToInspectorsSchedule()
        {
            WelcomePage page = new WelcomePage();
            page.Init(driver);
            var loginPage = page.SignIn();
            var homePage = loginPage.Login("manager1@gmail.com", "Admin123");
            var listOfInspectors = homePage.GetInspectorsList();
            var schedule = listOfInspectors.ChooseOlegAdamov();
            var addItem = schedule.AddItem();
            var deleteItem = addItem.ApplyToAdd("20190430", "вулиця Руська 241/245, Чернівці, Чернівецька область");

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
            var homePage = loginPage.Login("manager1@gmail.com", "Admin123");
            var listOfInspectors = homePage.GetInspectorsList();
            var schedule = listOfInspectors.ChooseOlegAdamov();

            // preCondition
            var addItem = schedule.AddItem();
            var chooseItemToEdit = addItem.ApplyToAdd("20190430", "вулиця Руська 241/245, Чернівці, Чернівецька область");
            //

            var editItem = chooseItemToEdit.EditItem();
            var deleteItem = editItem.ApplyToEdit("20190430", "вулиця Горіхівська 100/2, Чернівці, Чернівецька область");

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
            var homePage = loginPage.Login("manager1@gmail.com", "Admin123");
            var listOfInspectors = homePage.GetInspectorsList();
            var schedule = listOfInspectors.ChooseOlegAdamov();

            //preCondition
            var addItem = schedule.AddItem();
            var deleteItem = addItem.ApplyToAdd("20190430", "вулиця Руська 241/245, Чернівці, Чернівецька область");
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
            var homePage = loginPage.Login("manager1@gmail.com", "Admin123");
            var listOfInspectors = homePage.GetInspectorsList();

            // preCondition
            var addIvan = listOfInspectors.ClickToAddInspector();
            addIvan.AddIvanIvanov();
            driver.Refresh();
            //

            var close = listOfInspectors.ClickToAddInspector();
            Assert.IsTrue(close.GetCaption().IsDisplayed());
            close.CloseWindow();
            driver.Refresh();

            // postCondition
            var removeIvan = listOfInspectors.RemoveIvanIvanov();
            removeIvan.ConfirmRemoving();
            //
        }

        [Test]
        public void RemoveInspector()
        {
            WelcomePage page = new WelcomePage();
            page.Init(driver);
            var loginPage = page.SignIn();
            var homePage = loginPage.Login("manager1@gmail.com", "Admin123");
            var listOfInspectors = homePage.GetInspectorsList();

            // preCondition
            var addIvan = listOfInspectors.ClickToAddInspector();
            addIvan.AddIvanIvanov();
            driver.Refresh();
            //

            var removeIvan = listOfInspectors.RemoveIvanIvanov();
            removeIvan.ConfirmRemoving();
        }

        [Test]
        public void AddInspector()
        {
            WelcomePage page = new WelcomePage();
            page.Init(driver);
            var loginPage = page.SignIn();
            var homePage = loginPage.Login("manager1@gmail.com", "Admin123");
            var listOfInspectors = homePage.GetInspectorsList();
            var addIvan = listOfInspectors.ClickToAddInspector();
            addIvan.AddIvanIvanov();
            driver.Refresh();

            Assert.IsTrue(listOfInspectors.GetIvanIvanov().IsDisplayed());

            // postCondition
            var removeIvan = listOfInspectors.RemoveIvanIvanov();
            removeIvan.ConfirmRemoving();
            //
        }

        [Test]
        public void SetNewPrice()
        {
            WelcomePage page = new WelcomePage();
            page.Init(driver);
            var loginPage = page.SignIn();
            var homePage = loginPage.Login("manager1@gmail.com", "Admin123");
            var setNewPrice = homePage.GetPricesToEdit();
            setNewPrice.ClickOnSetNewPriceButton();
            setNewPrice.SetNewPrice("7");
            var actualPrice = setNewPrice.GetCurrentPrice();
            Assert.AreEqual("Current price: ₴7", actualPrice);


        }

        [Test]
        public void SetFuturePrice()
        {
            WelcomePage page = new WelcomePage();
            page.Init(driver);
            var loginPage = page.SignIn();
            var homePage = loginPage.Login("manager1@gmail.com", "Admin123");
            var setFuturePrice = homePage.GetPricesToEdit();
            setFuturePrice.ClickOnSetFuturePriceButton();
            setFuturePrice.SetFuturePrice("20", "2019-05-02");
            driver.Refresh();
            var actualPrice = setFuturePrice.GetFuturePrice();
            var actualActivationDate = setFuturePrice.GetActivationDate();
            Assert.AreEqual("Future price: ₴20", actualPrice);
            Assert.AreEqual("Next activation date: 2 MAY 2019", actualActivationDate);

        }

        [TearDown]
        public void PostCondition()
        {
            driver.Quit();
        }
    }
}
