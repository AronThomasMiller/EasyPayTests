using EasyPayLibrary;
using EasyPayLibrary.Admin;
using EasyPayLibrary.Changes;
using EasyPayLibrary.Inspector;
using EasyPayLibrary.Manager;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EasyPayTests
{
    public class UserTest
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
        public void AddAddresses()
        {

            WelcomePage welcome = new WelcomePage();
            welcome.Init(driver);
            var login = welcome.SignIn();
            var home = (HomePageUser)login.Login("user1@gmail.com", "Admin123");
            var addresses = home.OpenAddresses();
            addresses.EnterAllFields("Небесної сотні", "4Б", "Небесної сотні", "Чернівці", "Чернівецька область", "12345", "Україна", "45");
            var error = addresses.Error();
            Assert.IsNull(error);
                       
        }

        [Test]
        public void SelectAddresseUtilities()
        {
            WelcomePage welcome = new WelcomePage();
            welcome.Init(driver);
            var login = welcome.SignIn();
            var home = (HomePageUser)login.Login("user1@gmail.com", "Admin123");
            var utilities = home.OpenUtilities();
            var result = utilities.SelectAddress("Чернівці City, вулиця Шевченка Str., 44/54");
            Assert.AreEqual("Чернівці City, вулиця Шевченка Str., 44/54", result);


        }

        [Test]
        public void RateInspectors()
        {
            WelcomePage welcome = new WelcomePage();
            welcome.Init(driver);
            var login = welcome.SignIn();
            var home = (HomePageUser)login.Login("user1@gmail.com", "Admin123");
            var rateInspectors = home.OpenRateInspectors();
            var inspectorsPage = rateInspectors.ReturnRateInspectors();
            var result = inspectorsPage.Rate("Makar Portnov", 3, 2);
            Assert.AreEqual(result.GetText(), "Success");



        }
        [Test]
        public void PayDebt()
        {
            WelcomePage welcome = new WelcomePage();
            welcome.Init(driver);
            var login = welcome.SignIn();
            var home = (HomePageUser)login.Login("user1@gmail.com", "Admin123");
            var pay = home.OpenPayments();
            pay.EnterDebtInfo("вулиця Нагірна 5, Чернівці, Чернівецька область", "45");
            driver.Switch();
            pay.MakePayment("Sutnuk23nazar@gmail.com", "4242424242424242", "04 / 24", "424", "12");
            

        }
        [Test]
        public void SelectAddresseOnPaymentsHistory()
        {
            WelcomePage welcome = new WelcomePage();
            welcome.Init(driver);
            var login = welcome.SignIn();
            var home = (HomePageUser)login.Login("user1@gmail.com", "Admin123");
            var paymentsHistory = home.OpenPaymentsHistory();
            var result = paymentsHistory.SelectAddress("Чернівецька область, Чернівці, вулиця Пушкіна 12");
            Assert.AreEqual("Чернівецька область, Чернівці, вулиця Пушкіна 12", result);


        }
        [Test]
        public void DisconnectUtilities()
        {
            WelcomePage welcome = new WelcomePage();
            welcome.Init(driver);
            var login = welcome.SignIn();
            var home = (HomePageUser)login.Login("user1@gmail.com", "Admin123");
            var utilities = home.OpenUtilities();
            utilities.SelectAddress("Чернівці City, вулиця Маяковського Str., 16/24");
            var newUtilities = utilities.Disconect();
            newUtilities.SelectAddress("Чернівці City, вулиця Маяковського Str., 16/24");
            var result = newUtilities.VerifyThatUtilitiExist();
            Assert.IsEmpty(result, "HELLO VASYA");




        }
        [Test]
        public void ChangeMatrix()
        {
            WelcomePage welcome = new WelcomePage();
            welcome.Init(driver);
            var login = welcome.SignIn();
            var home = (HomePageUser)login.Login("user1@gmail.com", "Admin123");
            var pay = home.OpenPayments();
            pay.ChangeMatrix("вулиця Нагірна 5, Чернівці, Чернівецька область", "42");
            driver.Refresh();
            pay.SelectAddress("вулиця Нагірна 5, Чернівці, Чернівецька область");
            Assert.Negative(pay.GetBalance());


        }
        [Test]
        public void CallInspectorForConcreteDate()
        {
            WelcomePage welcome = new WelcomePage();
            welcome.Init(driver);
            var login = welcome.SignIn();
            var home = (HomePageUser)login.Login("user1@gmail.com", "Admin123");
            var utilities = home.OpenUtilities();
            utilities.CallInspector("Чернівці City, вулиця Толстого Str., 2/");
            var logOut = utilities.SubmitCall();
            var secondEnter = logOut.LogOut();
            var schedule = (HomePageInspector)login.Login("inspector2@gmail.com", "Admin123");
            var sched = schedule.OpenSchedule();
            Assert.IsNotNull(sched.GetCallByAddress("вулиця Толстого 2"),"No address match");

        }
        [Test]
        public void ListOfInspectorsNotEmpty()
        {
            WelcomePage welcome = new WelcomePage();
            welcome.Init(driver);
            var login = welcome.SignIn();
            var home = (HomePageUser)login.Login("user1@gmail.com", "Admin123");
            var rateinspectors = home.OpenRateInspectors();
            var logOut = rateinspectors.LogOut();
            var loginManager = (HomePageManager)logOut.Login("manager1@gmail.com", "Admin123");
            var rateInspectors = loginManager.OpenPagewithInspector();
            var res = rateInspectors.VerifyListOfInspectorsNotEmpty();
            Assert.IsNotEmpty(res);

        }
        [Test]
        public void ListOfUtilitiesNotEmpty()
        {
            WelcomePage welcome = new WelcomePage();
            welcome.Init(driver);
            var login = welcome.SignIn();
            var home = (HomePageUser)login.Login("user1@gmail.com", "Admin123");
            var paymentsHistory = home.OpenPaymentsHistory();
            var logOut = paymentsHistory.LogOut();
            var loginAdmin = (HomePageAdmin)logOut.Login("admin1@gmail.com", "Admin123");
            var utilities = loginAdmin.OpenUtilities();
            var res = utilities.VerifyUtilitiesListIsNotEmpty();
            Assert.IsNotEmpty(res);

        }




        [TearDown]
        public void PostCondition()
        {
          //  driver.Quit();
        }
    }
}
