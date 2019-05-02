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
    public class User
    {
        TranslationValues t;
        DriverWrapper driver;
        HomePageUser homePage;
        string userEmail = "user1@gmail.com";

        [SetUp]
        public void PreCondition()
        {
            t = TranslationProvider.GetTranslation("ua");
            driver = new DriverFactory().GetDriver();
            driver.Maximaze();
            driver.GoToURL();
            WelcomePage welcomePage = new WelcomePage();
            welcomePage.Init(driver);
            var loginPage = welcomePage.SignIn();
            homePage = (HomePageUser)loginPage.Login("user1@gmail.com", "Admin123");

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
            Assert.AreEqual(homePage.GetRoleText(), "USER");
        }

        //[Test]
        //public void UserIsUnableToLoginNonValidData()
        //{
        //    WelcomePage welcome = new WelcomePage();
        //    welcome.Init(driver);
        //    var login = welcome.SignIn();
        //    var test = (LoginPage)login.Login("user1@gmail.com", "Admin12345");

        //    Assert.IsTrue(test.IsErrorPresent());                        
        //}

        [Test]
        public void PersonalCabinetAccess()
        {
            var profile = homePage.GoToProfile();
            Assert.IsTrue(profile.NameIsVisible());
            Assert.IsTrue(profile.SurnameIsVisible());
            Assert.IsTrue(profile.PhoneNumberIsVisible());
        }

        [Test]
        public void PersonalInfoMatch()
        {
            var profile = homePage.GoToProfile();
            Assert.AreEqual("Masha",profile.GetName());
            Assert.AreEqual("Chuikina", profile.GetSurname());
            Assert.AreEqual("+380968780876", profile.GetPhoneNumber());
        }

        [Test]
        public void IsNameChanging()
        {
            var profile = homePage.GoToProfile();            
            profile.SetName("Masha");            
            profile.UpdateProfile();            
            Assert.True(profile.IsSuccessAlertDisplayed());
            Assert.AreEqual("Masha", profile.GetName());
        }

        [Test]
        public void IsPersonalInfoTranslationIsCorrect()
        {
            var profile = homePage.GoToProfile();
            ProfilePage changed = profile.ChangeToUKR();
            profile.Init(driver);
            var name = profile.GetName();            
            Assert.AreEqual(t.Mariya.ToLower(),name.ToLower());
            var surname = profile.GetSurname();
            Assert.AreEqual(t.Chuikina.ToLower(), surname.ToLower());
        }

        [Test]
        public void NameCanContainUALetters()
        {
            var profile = homePage.GoToProfile();
            profile.SetName("Вася");
            profile.UpdateProfile();            
            Assert.IsFalse(profile.IsErrorAlertDisplayed());            
        }

        [Test]
        public void CheckTranslationOnHomeUsersPage()
        {
            homePage.ChangeToUKR();
            homePage.Init(driver);
            var role = homePage.GetRoleText();            
            Assert.AreEqual(t.User.ToLower(),role.ToLower());            
            var addresses = homePage.GetAddressesText();
            Assert.AreEqual(t.Addresses.ToLower(), addresses.ToLower());
            var connectedUtilities = homePage.GetConnectedUtilitiesText();
            Assert.AreEqual(t.ConnectedUtilities.ToLower(), connectedUtilities.ToLower());
            var payments = homePage.GetPaymentsText();
            Assert.AreEqual(t.Payments.ToLower(), payments.ToLower());
            var paymentsHistory = homePage.GetPaymentsHistoryText();
            Assert.AreEqual(t.PaymentsHistory.ToLower(), paymentsHistory.ToLower());
            var rateInspectors = homePage.GetRateInspectorsText();
            Assert.AreEqual(t.RateInspectors.ToLower(), rateInspectors.ToLower());
            var mainPageTitle = homePage.GetMainPageTitleText();
            Assert.AreEqual(t.MainPage.ToLower(), mainPageTitle.ToLower());
            var xTitle = homePage.GetXTitleText();
            Assert.AreEqual(t.SomeText.ToLower(), xTitle.ToLower());
        }

        [TestCase((float)12.4, "4242424242424242", "012020", "434", "58004", "Чернівецька область", "Чернівці", "вулиця Толстого 2", "Pat \"Chernivtsihaz\"")]
        public void PayAndCheckOneInPaymentHistory(float sumToPay, string cardNumber, string dateOfCard, string cvc, string zipCode, string region, string city, string street, string utility)
        {           
            Assert.IsTrue(driver.getUrl().Contains("http://localhost:8080/home"));

            var payPage = homePage.NavigateToPayment();

            var address = street + ", " + city + ", " + region;
            homePage = payPage.Pay(address, utility, sumToPay, userEmail, cardNumber, dateOfCard, cvc, zipCode);

            var paymentHistoryPage = homePage.NavigateToPaymentHistory();

            address = region + ", " + city + ", " + street;
            Assert.AreEqual(DateTime.Today.ToString("d") + "_" + sumToPay.ToString().Replace(',', '.'), paymentHistoryPage.GetLastPayInString(address, utility));
        }

        [Test]
        public void AddAddresses()
        { 
            var addresses = homePage.NavigateToAddresses();
            addresses.EnterAllFields("Небесної сотні", "4Б", "Небесної сотні", "Чернівці", "Чернівецька область", "12345", "Україна", "45");
            var error = addresses.Error();
            Assert.IsNull(error);
        }

        [Test]
        public void SelectAddresseUtilities()
        {
            var utilities = homePage.NavigateToUtilities();
            var result = utilities.SelectAddress("Чернівці City, вулиця Шевченка Str., 44/54");
            Assert.AreEqual("Чернівці City, вулиця Шевченка Str., 44/54", result);
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
        public void PayDebt()
        {
            var pay = homePage.NavigateToPayment();
            //pay.Pay("вулиця Нагірна 5, Чернівці, Чернівецька область", "45");
            //driver.Switch();
            //pay.MakePayment("Sutnuk23nazar@gmail.com", "4242424242424242", "04 / 24", "424", "12");
        }

        [Test]
        public void SelectAddresseOnPaymentsHistory()
        {
            var paymentsHistory = homePage.NavigateToPaymentHistory();
            var result = paymentsHistory.SelectAddress("Чернівецька область, Чернівці, вулиця Пушкіна 12");
            Assert.AreEqual("Чернівецька область, Чернівці, вулиця Пушкіна 12", result);
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

        [Test]
        public void ChangeMetrics()
        {
            var pay = homePage.NavigateToPayment();
            pay.ChangeMetrics("вулиця Нагірна 5, Чернівці, Чернівецька область", "42");
            pay.SelectAddress("вулиця Нагірна 5, Чернівці, Чернівецька область");
            Assert.Negative(pay.GetBalance());
        }

        [Test]
        public void CallInspectorForConcreteDate()
        {
            var utilities = homePage.NavigateToUtilities();
            utilities.CallInspector("Чернівці City, вулиця Толстого Str., 2/");
            var logOut = utilities.SubmitCall();
            var secondEnter = logOut.LogOut();
            var schedule = (HomePageInspector)secondEnter.Login("inspector2@gmail.com", "Admin123");
            var sched = schedule.NavigateToSchedule();
            Assert.IsNotNull(sched.GetCallByAddress("вулиця Толстого 2"), "No address match");
        }

        [Test]
        public void ListOfInspectorsNotEmpty()
        {
            var rateinspectors = homePage.NavigateToRateInspectors();
            var logOut = rateinspectors.LogOut();
            var loginManager = (HomePageManager)logOut.Login("manager1@gmail.com", "Admin123");
            var rateInspectors = loginManager.NavigateToInspectorsList();
            var res = rateInspectors.VerifyListOfInspectorsNotEmpty();
            Assert.IsNotEmpty(res);
        }

        [Test]
        public void ListOfUtilitiesNotEmpty()
        {
            var paymentsHistory = homePage.NavigateToPaymentHistory();
            var logOut = paymentsHistory.LogOut();
            var loginAdmin = (HomePageAdmin)logOut.Login("admin1@gmail.com", "Admin123");
            var utilities = loginAdmin.NavigateToUtilities();
            var res = utilities.TableOfUtilitiesIsVisible();
            Assert.IsTrue(res);
        }
    }
}
