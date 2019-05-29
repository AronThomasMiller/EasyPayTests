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
            var loginPage = welcome.SignIn();
            homePage = (HomePageUser)loginPage.Login("user1@gmail.com", "Admin123");
        }
        

        [Test]
        public void ScheduleNotAvailable()
        {
            var list = homePage.GetList();
            foreach (var element in list)
            {
                Assert.False(element.GetText() == "Schedule", "Element found");
            }
        }
        
        [Test]
        public void UserIsAbleToLogin()
        {          
            Assert.AreEqual(homePage.GetRoleText(), "USER","user isn't loged in");
        }        

        [Test]
        public void PersonalCabinetAccess()
        {
            var profile = homePage.GoToProfile();
            Assert.IsTrue(profile.NameIsVisible(),"Name isn't visible");
            Assert.IsTrue(profile.SurnameIsVisible(), "Surname isn't visible");
            Assert.IsTrue(profile.PhoneNumberIsVisible(), "PhoneNumber isn't visible");
        }

        [Test]
        public void PersonalInfoMatch()
        {
            var profile = homePage.GoToProfile();
            Assert.AreEqual("Masha",profile.GetName(), "Wrong name");
            Assert.AreEqual("Chuikina", profile.GetSurname(), "Wrong surname");
            Assert.AreEqual("+380968780876", profile.GetPhoneNumber(), "Wrong name");
        }

        [Test]
        public void IsNameChanging()
        {
            var profile = homePage.GoToProfile();            
            profile.SetName("Masha");            
            profile.UpdateProfile();            
            Assert.True(profile.IsSuccessAlertDisplayed());
            Assert.AreEqual("Masha", profile.GetName(),"Name doesn't change");
        }
        
        [Test]
        public void SelectAddresseUtilities()
        {
            var utilities = homePage.NavigateToUtilities();
            var result = utilities.SelectAddress("Чернівці City, вулиця Шевченка Str., 44/54");
            Assert.AreEqual("Чернівці City, вулиця Шевченка Str., 44/54", result,"Address is not selected");
        }

        [Test]
        public void RateInspectors()
        {
            var rateInspectors = homePage.NavigateToRateInspectors();
            var inspectorsPage = rateInspectors.ReturnRateInspectors();
            var result = inspectorsPage.Rate("Oleg Adamov", (float)4.5);
            Assert.AreEqual(result.GetText(), "Success");
        }

        [Test]
        public void SelectAddresseOnPaymentsHistory()
        {
            var paymentsHistory = homePage.NavigateToPaymentHistory();
            var result = paymentsHistory.SelectAddress("Чернівецька область, Чернівці, вулиця Пушкіна 12");
            Assert.AreEqual("Чернівецька область, Чернівці, вулиця Пушкіна 12", result,"Adress is not selected");
        }

        [Test]
        public void DisconnectUtilities()
        {
            var utilities = homePage.NavigateToUtilities();
            utilities.SelectAddress("Чернівці City, вулиця Шевченка Str., 44/54");
            var newUtilities = utilities.Disconect();
            newUtilities.SelectAddress("Чернівці City, вулиця Шевченка Str., 44/54");
            var result = newUtilities.VerifyThatUtilitiExist();
            Assert.IsNull(result, "Utility wasn't disconnected");
        }

        [Test(Description = "Repeat 2 times")]
        public void ChangeMetrics()
        {
            var pay = homePage.NavigateToPayment();
            pay.ChangeMetrics("вулиця Нагірна 5, Чернівці, Чернівецька область", "42");
            pay.SelectAddress("вулиця Нагірна 5, Чернівці, Чернівецька область");
            Assert.Negative(pay.GetBalance(),"Incorrect value");
        }

        [Test]
        public void ListOfInspectorsNotEmpty()
        {
            var rateinspectors = homePage.NavigateToRateInspectors();
            var logOut = rateinspectors.LogOut();
            var loginManager = (HomePageManager)logOut.Login("manager1@gmail.com", "Admin123");
            var rateInspectors = loginManager.NavigateToInspectorsList();
            var res = rateInspectors.VerifyListOfInspectorsNotEmpty();
            Assert.IsNotEmpty(res, "List of Inspector is empty");
        }

        [Test]
        public void ListOfUtilitiesNotEmpty()
        {
            var paymentsHistory = homePage.NavigateToPaymentHistory();
            var logOut = paymentsHistory.LogOut();
            var loginAdmin = (HomePageAdmin)logOut.Login("admin1@gmail.com", "Admin123");
            var utilities = loginAdmin.NavigateToUtilities();
            var res = utilities.TableOfUtilitiesIsVisible();
            Assert.IsTrue(res, "List of Utilities is empty");
        }
    }
}
