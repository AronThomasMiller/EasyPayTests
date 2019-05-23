using EasyPayLibrary;
using EasyPayLibrary.HomePages;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPayTests
{
    [TestFixture]
    [Category("Critical")]
    [Parallelizable(ParallelScope.Fixtures)]
    class Critical:BaseTest
    {
        [Test]
        public void VerifyThatAdminCanEditManager()
        {
            var login = welcome.SignIn();
            var home = (HomePageAdmin)login.Login("admin1@gmail.com", "Admin123");
            var utilities = home.NavigateToUtilities();
            utilities.ClickOnChangeManager();
            utilities.SetKeywordToTextBox();
            utilities.SelectManager("Viktoriya Radashko");
            utilities.ClickOnConfirm();
            Assert.AreEqual("Viktoriya Radashko", utilities.getTextFromManagerField(), "Viktoriya Radashko isn't assigned as manager");
        }

        [Test]
        public void AddAddresses()
        {
            var loginPage = welcome.SignIn();
            var homePage = (HomePageUser)loginPage.Login("user1@gmail.com", "Admin123");
            var addresses = homePage.NavigateToAddresses();
            addresses.EnterAllFields("Небесної сотні", "4Б", "Небесної сотні", "Чернівці", "Чернівецька область", "12345", "Україна", "45");
            var error = addresses.Error();
            Assert.IsNull(error, "Address is not added");
        }
        
        [Test]
        public void CallInspectorForConcreteDate()
        {
            var loginPage = welcome.SignIn();
            var homePage = (HomePageUser)loginPage.Login("user1@gmail.com", "Admin123");

            var utilities = homePage.NavigateToUtilities();
            utilities.CallInspector("Чернівці City, вулиця Толстого Str., 2/");
            var logOut = utilities.SubmitCall();
            var secondEnter = logOut.LogOut();
            var schedule = (HomePageInspector)secondEnter.Login("inspector2@gmail.com", "Admin123");
            var sched = schedule.NavigateToSchedule();
            Assert.IsNotNull(sched.GetCallByAddress("вулиця Толстого 2"), "No address match");
        }

        [Test]
        public void IsPersonalInfoTranslationIsCorrect()
        {
            var loginPage = welcome.SignIn();
            var homePage = (HomePageUser)loginPage.Login("user1@gmail.com", "Admin123");

            var profile = homePage.GoToProfile();
            ProfilePage changed = profile.ChangeToUKR();
            profile.Init(driver);
            var name = profile.GetName();
            StringAssert.AreEqualIgnoringCase(t.Mariya, name, "Wrong name translation");
            var surname = profile.GetSurname();
            StringAssert.AreEqualIgnoringCase(t.Chuikina, surname, "Wrong surname translation");
        }

        [Test]
        public void NameCanContainUALetters()
        {
            var loginPage = welcome.SignIn();
            var homePage = (HomePageUser)loginPage.Login("user1@gmail.com", "Admin123");

            var profile = homePage.GoToProfile();
            profile.SetName("Вася");
            profile.UpdateProfile();
            Assert.IsFalse(profile.IsErrorAlertDisplayed(), "error alert isn't displayed");
        }


        [Repeat(11)]
        [TestCase("user1@gmail.com" , (float)12.4, "4242424242424242", "012020", "434", "58004", "Чернівецька область", "Чернівці", "вулиця Сковороди 43/65", "Pat \"Chernivtsihaz\"")]
        public void PayAndCheckOneInPaymentHistory(string userEmail, float sumToPay, string cardNumber, string dateOfCard, string cvc, string zipCode, string region, string city, string street, string utility)
        {
            var loginPage = welcome.SignIn();
            var homePage = (HomePageUser)loginPage.Login("user1@gmail.com", "Admin123");

            Assert.IsTrue(driver.getUrl().Contains("http://localhost:8080/home"));

            var paymentHistoryPage = homePage.NavigateToPaymentHistory();

            var address = region + ", " + city + ", " + street;
            paymentHistoryPage.SelectAddress(address);
            paymentHistoryPage.SelectUtility(utility);
            var oldTableOfPayments = paymentHistoryPage.InitTable();
            var oldPayTableRows = oldTableOfPayments.GetAllRows();

            var payPage = paymentHistoryPage.NavigateToPayment();
            address = street + ", " + city + ", " + region;
            payPage.SelectAddress(address);
            var utilityDetails = payPage.NavigateToUtilityDetails(utility);
            var selectPaymentSum = utilityDetails.NavigateToSelectPaymentSum();
            selectPaymentSum.ChooseDownloadCheck();
            var payFrame = selectPaymentSum.PayForSum(sumToPay);
            var homePageAndUrlOfCheck = payFrame.Pay(userEmail, cardNumber, dateOfCard, cvc, zipCode);
            var urlOfCheck = homePageAndUrlOfCheck.Item2;
            homePage = homePageAndUrlOfCheck.Item1;


            paymentHistoryPage = homePage.NavigateToPaymentHistory();
            address = region + ", " + city + ", " + street;
            paymentHistoryPage.SelectAddress(address);
            paymentHistoryPage.SelectUtility(utility);

            var newTableOfPayments = paymentHistoryPage.InitTable();
            var newPayTableRows = newTableOfPayments.GetAllRows();

            var newLastPay = newTableOfPayments.GetLastRow();
            var newLastPayDate = newLastPay.GetDateFromRow();
            var newLastPaySum = newLastPay.GetSumFromRow();
            newLastPay.ViewCheck();
            var newLastPayCheck = driver.getUrl();

            Assert.AreEqual(DateTime.Today, newLastPayDate, "Date of last pay doesn't match today date");
            Assert.AreEqual(sumToPay, newLastPaySum, "Sum of last pay doesn't match today's sum of pay");
            StringAssert.Contains(newLastPayCheck, urlOfCheck, "Url of last check doesn't match today's url of check");

            CollectionAssert.AreNotEqual(oldPayTableRows, newPayTableRows, "All checks matches old ones, no new check added to history");
        }
    }
}
