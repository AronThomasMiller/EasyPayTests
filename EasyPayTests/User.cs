using EasyPayLibrary;
using EasyPayLibrary.HomePages;
using EasyPayLibrary.Pages.Manager;
using EasyPayLibrary.Translations;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EasyPayTests
{
    [TestFixture]
    [Category("All")]
    [Category("User")]
    [Parallelizable(ParallelScope.Fixtures)]
    public class User : BaseTest
    {
        HomePageUser homePage;

        [SetUp]
        public override void PreCondition()
        {
            base.PreCondition();
            LogProgress("User is going to login page");
            var loginPage = welcomePage.SignIn();
            homePage = loginPage.LoginAsUser("user1@gmail.com", "Admin123");
        }
        

        [Test]
        public void ScheduleNotAvailable()
        {
            LogProgress("Getting sidebar menus");
            var list = homePage.GetList();
            foreach (var element in list)
            {
                Assert.False(element.GetText() == "Schedule", "Element found");
            }
        }
        
        [Test]
        public void UserIsAbleToLogin()
        {
            LogProgress("User is logging");
            Assert.AreEqual(GeneralPage.GetRole(driver), "USER","user isn't loged in");
        }        

        [Test]
        public void PersonalCabinetAccess()
        {
            LogProgress("User is going to profile");
            var profile = homePage.GoToProfile();
            Assert.IsTrue(profile.NameIsVisible(),"Name isn't visible");
            Assert.IsTrue(profile.SurnameIsVisible(), "Surname isn't visible");
            Assert.IsTrue(profile.PhoneNumberIsVisible(), "PhoneNumber isn't visible");
        }

        [Test]
        public void PersonalInfoMatch()
        {
            LogProgress("User is going to profile");
            var profile = homePage.GoToProfile();
            Assert.AreEqual("Masha",profile.GetName(), "Wrong name");
            Assert.AreEqual("Chuikina", profile.GetSurname(), "Wrong surname");
            Assert.AreEqual("+380968780876", profile.GetPhoneNumber(), "Wrong name");
        }

        [Test]
        public void IsNameChanging()
        {
            LogProgress("User is going to profile");
            var profile = homePage.GoToProfile();
            LogProgress("User sets his name in profile");
            profile.SetName("Masha");
            LogProgress("User updates his profile");
            profile.UpdateProfile();            
            Assert.True(profile.IsSuccessAlertDisplayed());
            Assert.AreEqual("Masha", profile.GetName(),"Name doesn't change");
        }
        
        /*[Test]
        public void SelectAddresseUtilities()
        {
            LogProgress("User is going to Utilities");
            var utilities = homePage.NavigateToConnectedUtilitiesPage();
            LogProgress("User choosing Address");
            var result = utilities.SelectAddress("Чернівці City, вулиця Шевченка Str., 44/54");
            Assert.AreEqual("Чернівці City, вулиця Шевченка Str., 44/54", result,"Address is not selected");
        }*/

        [Test]
        public void RateInspectors()
        {
            LogProgress("User is going to RateInspectors");
            var rateInspectors = homePage.NavigateToRateInspectorsPage();
            LogProgress("Return RateInspectors Page");
            var inspectorsPage = rateInspectors.ReturnRateInspectors();
            LogProgress("User is going to RateInspectors");
            var result = inspectorsPage.Rate("Oleg Adamov", (float)4.5);
            Assert.AreEqual(result.GetText(), "Success");
        }

        [Test]
        public void SelectAddresseOnPaymentsHistory()
        {
            LogProgress("User is going to PaymentHistory");
            var paymentsHistory = homePage.NavigateToPaymentHistoryPage();
            LogProgress("User choosing address ");
            var result = paymentsHistory.SelectAddress("Чернівецька область, Чернівці, вулиця Пушкіна 12");
            Assert.AreEqual("Чернівецька область, Чернівці, вулиця Пушкіна 12", result,"Adress is not selected");
        }

        /*[Test]
        public void DisconnectUtilities()
        {
            using(var conn = new DatabaseManipulation.DatabaseMaster())
            {
                conn.Open();
                conn.ChangeInDB("update counters set is_active = true where debt_id = 23");
            }
            LogProgress("User is going to utilities");
            var utilities = homePage.NavigateToConnectedUtilitiesPage();
            LogProgress("User choosing address ");
            utilities.SelectAddress("Чернівці City, вулиця Шевченка Str., 44/54");
            LogProgress("User disconects Utility");
            var newUtilities = utilities.Disconect();
            LogProgress("User choosing address ");
            newUtilities.SelectAddress("Чернівці City, вулиця Шевченка Str., 44/54");
            var result = newUtilities.VerifyThatUtilitiExist();
            Assert.IsNull(result, "Utility wasn't disconnected");
        }*/

        [Test(Description = "Repeat 2 times")]
        public void ChangeMetrics()
        {
            LogProgress("User is going to Payment ");
            var pay = homePage.NavigateToPaymentPage();
            LogProgress("User is changing metrics ");
            pay.ChangeMetrics("вулиця Нагірна 5, Чернівці, Чернівецька область", "42");
            LogProgress("User choosing address ");
            pay.SelectAddress("вулиця Нагірна 5, Чернівці, Чернівецька область");
            Assert.Negative(pay.GetBalance(),"Incorrect value");
        }

        [Test]
        public void ListOfInspectorsNotEmpty()
        {
            LogProgress("User is going to Rate Inspectors ");
            var rateinspectors = homePage.NavigateToRateInspectorsPage();
            LogProgress("User is going to log out ");
            var logOut = rateinspectors.LogOut();
            LogProgress("User is logging as Manager ");
            var loginManager = logOut.LoginAsManager("manager1@gmail.com", "Admin123");
            LogProgress("User is going to Inspectors List ");
            var rateInspectors = loginManager.NavigateToInspectorsList();
            var res = rateInspectors.VerifyListOfInspectorsIsNotEmpty();
            Assert.IsNotEmpty(res, "List of Inspector is empty");
        }

        [Test]
        public void ListOfUtilitiesNotEmpty()
        {
            LogProgress("User is going to Payment History ");
            var paymentsHistory = homePage.NavigateToPaymentHistoryPage();
            LogProgress("User is going to log out ");
            var logOut = paymentsHistory.LogOut();
            LogProgress("User is logging as Admin ");
            var loginAdmin = logOut.LoginAsAdmin("admin1@gmail.com", "Admin123");
            LogProgress("User is going to Utilities ");
            var utilities = loginAdmin.NavigateToUtilities();
            var res = utilities.TableOfUtilitiesIsVisible();
            Assert.IsTrue(res, "List of Utilities is empty");
        }
    }
}
