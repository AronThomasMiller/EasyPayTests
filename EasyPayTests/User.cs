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
            LogProgress("User is going to Home page");
            homePage = loginPage.LoginAsUser("user1@gmail.com", "Admin123");
        }
        
/// <summary>
/// 
/// </summary>
        [Test]
        public void ScheduleNotAvailable()
        {
            LogProgress("Getting sidebar menus");
            var list = homePage.GetList();
            foreach (var element in list)
            {
                Assert.AreEqual(element.GetText() == "Schedule", "Element found");
            }
        }
/////////        
        [Test]
        public void UserIsAbleToLogin()
        {
            LogProgress("User is logging");
            var actualRole = GeneralPage.GetRole(driver);
            var expectedRole = "USER";
            Assert.AreEqual(expectedRole, actualRole, "User isn't loged in");
        }        
         
        [Test]
        public void PersonalCabinetAccess()
        {
            LogProgress("User is going to profile");
            var profilePage = homePage.GoToProfile();
            var userNameIsVisible = profilePage.NameIsVisible();
            var userSurnameIsVisible = profilePage.SurnameIsVisible();
            var userPhoneNumberIsVisible = profilePage.PhoneNumberIsVisible();
            Assert.IsTrue(userNameIsVisible, "User`s name isn't visible in profile page");
            Assert.IsTrue(userSurnameIsVisible, "User`s Surname isn't visible in profile page");
            Assert.IsTrue(userPhoneNumberIsVisible, "User`s PhoneNumber isn't visible in profile page");
        }
/// <summary>
/// /
/// </summary>
        [Test]
        public void PersonalInfoMatch()
        {
            LogProgress("User is going to profile");
            var profilePage = homePage.GoToProfile();
            var actualName = profilePage.GetName();
            var actualSurname = profilePage.GetSurname();
            var actualPhomeNumber = profilePage.GetPhoneNumber();
            var expectedName = "Masha";
            var expectedSurname = "Chuikina";
            var expectedPhomeNumber = "+380968780876";
            Assert.AreEqual(expectedName, actualName, "Wrong name");
            Assert.AreEqual(expectedSurname, actualSurname, "Wrong surname");
            Assert.AreEqual(expectedPhomeNumber, actualPhomeNumber, "Wrong name");
        }
/// <summary>
/// //
/// </summary>
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
        
        [Test]
        public void SelectAddresseUtilities()
        {
            LogProgress("User is going to Utilities");
            var utilities = homePage.NavigateToUtilities();
            LogProgress("User choosing Address");
            var result = utilities.SelectAddress("Чернівці City, вулиця Шевченка Str., 44/54");
            Assert.AreEqual("Чернівці City, вулиця Шевченка Str., 44/54", result,"Address is not selected");
        }

        [Test]
        public void RateInspectors()
        {
            LogProgress("User is going to RateInspectors");
            var rateInspectors = homePage.NavigateToRateInspectors();
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
            var paymentsHistory = homePage.NavigateToPaymentHistory();
            LogProgress("User choosing address ");
            var result = paymentsHistory.SelectAddress("Чернівецька область, Чернівці, вулиця Пушкіна 12");
            Assert.AreEqual("Чернівецька область, Чернівці, вулиця Пушкіна 12", result,"Adress is not selected");
        }

        [Test]
        public void DisconnectUtilities()
        {
            using(var conn = new DatabaseManipulation.DatabaseMaster())
            {
                conn.Open();
                conn.ChangeInDB("update counters set is_active = true where debt_id = 23");
            }
            LogProgress("User is going to utilities");
            var utilities = homePage.NavigateToUtilities();
            LogProgress("User choosing address ");
            utilities.SelectAddress("Чернівці City, вулиця Шевченка Str., 44/54");
            LogProgress("User disconects Utility");
            var newUtilities = utilities.Disconect();
            LogProgress("User choosing address ");
            newUtilities.SelectAddress("Чернівці City, вулиця Шевченка Str., 44/54");
            var result = newUtilities.VerifyThatUtilitiExist();
            Assert.IsNull(result, "Utility wasn't disconnected");
        }

        [Test(Description = "Repeat 2 times")]
        public void ChangeMetrics()
        {
            LogProgress("User is going to Payment ");
            var pay = homePage.NavigateToPayment();
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
            var rateinspectors = homePage.NavigateToRateInspectors();
            LogProgress("User is going to log out ");
            var logOut = rateinspectors.LogOut();
            LogProgress("User is logging as Manager ");
            var loginManager = logOut.LoginAsManager("manager1@gmail.com", "Admin123");
            LogProgress("User is going to Inspectors List ");
            var rateInspectors = loginManager.NavigateToInspectorsList();
            var res = rateInspectors.VerifyListOfInspectorsNotEmpty();
            Assert.IsNotEmpty(res, "List of Inspector is empty");
        }

        [Test]
        public void ListOfUtilitiesNotEmpty()
        {
            LogProgress("User is going to Payment History ");
            var paymentsHistory = homePage.NavigateToPaymentHistory();
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
