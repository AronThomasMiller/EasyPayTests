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
    [Category("All")]
    [Category("Failures")]
    [Parallelizable(ParallelScope.Fixtures)]
    class Failures:BaseTest
    {
        [Test]
        public void VerifyThatAdminCanEditManager()
        {
            var login = welcomePage.SignIn();
            var home = login.LoginAsAdmin("admin1@gmail.com", "Admin123");
            var utilities = home.NavigateToUtilities();
            utilities.ClickOnChangeManager();
            utilities.SetKeywordToTextBox();
            utilities.SelectManager("Viktoriya Radashko");
            utilities.ClickOnConfirm();
            Assert.AreEqual("Viktoriya Radashko", utilities.getTextFromManagerField(), "Viktoriya Radashko isn't assigned as manager");
        }

        [Test]
        public void CheckTranslationOnHomeUsersPage()
        {
            LogProgress("User is going to Login Page ");
            var loginPage = welcomePage.SignIn();
            LogProgress("User is logging as User");
            var homePage = loginPage.LoginAsUser("user1@gmail.com", "Admin123");
            LogProgress("User is changing language to UKR");
            homePage.ChangeToUA();
            homePage.Init(driver);
            var role = GeneralPage.GetRole(driver);
            StringAssert.AreEqualIgnoringCase(t.User, role, "Wrong role translation");
            var addresses = homePage.GetAddressesText();
            StringAssert.AreEqualIgnoringCase(t.Addresses, addresses, "Wrong address translation");
            var connectedUtilities = homePage.GetConnectedUtilitiesText();
            StringAssert.AreEqualIgnoringCase(t.ConnectedUtilities, connectedUtilities, "Wrong connected utilities translation");
            var payments = homePage.GetPaymentsText();
            StringAssert.AreEqualIgnoringCase(t.Payments, payments, "Wrong payments translation");
            var paymentsHistory = homePage.GetPaymentsHistoryText();
            StringAssert.AreEqualIgnoringCase(t.PaymentsHistory, paymentsHistory, "Wrong payments history translation");
            var rateInspectors = homePage.GetRateInspectorsText();
            StringAssert.AreEqualIgnoringCase(t.RateInspectors, rateInspectors, "Wrong rate inspectors translation");
            var mainPageTitle = homePage.GetMainPageTitleText();
            StringAssert.AreEqualIgnoringCase(t.MainPage, mainPageTitle, "Wrong main title translation");
            var xTitle = homePage.GetXTitleText();
            StringAssert.AreEqualIgnoringCase(t.SomeText, xTitle, "Wrong xtitle translation");
        }
        
        [Test]
        public void Localization()
        {
            welcomePage = welcomePage.TranslatePageToUA();

            var WelcomePageTitle = welcomePage.lblLeadText;
            StringAssert.AreEqualIgnoringCase(t.WelcomePageTitle, WelcomePageTitle);
            var WelcomePageFooter = welcomePage.FooterText;
            StringAssert.AreEqualIgnoringCase(t.WelcomePageFooter, WelcomePageFooter);
            var SignIn = welcomePage.btnSignInText;
            StringAssert.AreEqualIgnoringCase(t.SignIn, SignIn);
            var SignUp = welcomePage.btnSignUpText;
            StringAssert.AreEqualIgnoringCase(t.SignUp, SignUp);

            var LoginPage = welcomePage.SignIn();

            var LoginPageHeader = LoginPage.HeaderText;
            StringAssert.AreEqualIgnoringCase(t.Login, LoginPageHeader);
            var Email = LoginPage.fieldEmailText;
            StringAssert.AreEqualIgnoringCase(t.Email, Email);
            var Password = LoginPage.fieldPasswordText;
            StringAssert.AreEqualIgnoringCase(t.Password, Password);
            var Login = LoginPage.btnLoginText;
            StringAssert.AreEqualIgnoringCase(t.Login, Login);
            var LostYourPassword = LoginPage.LostYourPassword;
            StringAssert.AreEqualIgnoringCase(t.LostYourPassword, LostYourPassword);
            var Or = LoginPage.lblOr;
            StringAssert.AreEqualIgnoringCase(t.Or, Or);
            var NewToSite = LoginPage.NewToSiteText;
            StringAssert.AreEqualIgnoringCase(t.NewToSite, NewToSite);
            var CreateAccount = LoginPage.btnCreateAccountText;
            StringAssert.AreEqualIgnoringCase(t.CreateAccount, CreateAccount);
            var LoginPageFooter = LoginPage.FooterText;
            StringAssert.AreEqualIgnoringCase(t.LoginPageFooter, LoginPageFooter);

            var RegisterPage = LoginPage.NavigateToCreateAccountPage();

            var RegisterPageHeader = RegisterPage.lblHeaderText;
            StringAssert.AreEqualIgnoringCase(t.RegisterPageHeader, RegisterPageHeader);
            var Name = RegisterPage.fieldNameText;
            StringAssert.AreEqualIgnoringCase(t.Name, Name);
            var Surname = RegisterPage.fieldSurnameText;
            StringAssert.AreEqualIgnoringCase(t.Surname, Surname);
            Email = RegisterPage.fieldEmailText;
            StringAssert.AreEqualIgnoringCase(t.Email, Email);
            Password = RegisterPage.fieldPasswordText;
            StringAssert.AreEqualIgnoringCase(t.Password, Password);
            var ConfirmPassword = RegisterPage.fieldConfirmPasswordText;
            StringAssert.AreEqualIgnoringCase(t.ConfirmPassword, ConfirmPassword);
            var Submit = RegisterPage.btnSubmitText;
            StringAssert.AreEqualIgnoringCase(t.Submit, Submit);
            var RegisterPageFooter = RegisterPage.lblFooterText;
            StringAssert.AreEqualIgnoringCase(t.RegisterPageFooter, RegisterPageFooter);
            SignIn = RegisterPage.btnSignInText;
            StringAssert.AreEqualIgnoringCase(t.SignIn, SignIn);
        }

        [Test]
        public void AddAddresses()
        {
            var loginPage = welcomePage.SignIn();
            var homePage = loginPage.LoginAsUser("user1@gmail.com", "Admin123");
            var addresses = homePage.NavigateToAddressesPage();
            addresses.EnterAllFields("Небесної сотні", "4Б", "Небесної сотні", "Чернівці", "Чернівецька область", "12345", "Україна", "45");
            var error = addresses.Error();
            Assert.IsNull(error, "Address is not added");
        }
        
        //[Test]
        //public void CallInspectorForConcreteDate()
        //{
        //    var loginPage = welcomePage.SignIn();
        //    var homePage = loginPage.LoginAsUser("user1@gmail.com", "Admin123");

        //    var utilities = homePage.NavigateToConnectedUtilitiesPage();
        //    utilities.CallInspector("Чернівці City, вулиця Толстого Str., 2/");
        //    var logOut = utilities.SubmitCall();
        //    var secondEnter = logOut.LogOut();
        //    var schedule = secondEnter.LoginAsInspector("inspector2@gmail.com", "Admin123");
        //    var sched = schedule.NavigateToSchedule();
        //    Assert.IsNotNull(sched.GetCallByAddress("вулиця Толстого 2"), "No address match");
        //}

        [Test]
        public void IsPersonalInfoTranslationIsCorrect()
        {
            LogProgress("User is going to Login Page ");
            var loginPage = welcomePage.SignIn();
            LogProgress("User is logging as User");
            var homePage = loginPage.LoginAsUser("user1@gmail.com", "Admin123");
            LogProgress("User is going to Profile ");
            var profile = homePage.GoToProfile();
            LogProgress("User is changing language to UKR");
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
            LogProgress("User is going to Login Page ");
            var loginPage = welcomePage.SignIn();
            LogProgress("User is logging as User");
            var homePage = loginPage.LoginAsUser("user1@gmail.com", "Admin123");
            LogProgress("User is going to Profile ");
            var profile = homePage.GoToProfile();
            LogProgress("User is changing his name with UA characters ");
            profile.SetName("Василь");
            LogProgress("User is updating his profile ");
            profile.UpdateProfile();
            Assert.IsFalse(profile.IsErrorAlertDisplayed(), "error alert isn't displayed");
        }


        [Repeat(11)]
        [TestCase("user1@gmail.com", "Admin123" , (float)12.4, "4242424242424242", "012020", "434", "58004", "Чернівецька область", "Чернівці", "вулиця Сковороди 43/65", "Pat \"Chernivtsihaz\"")]
        public void PayAndCheckOneInPaymentHistory(string userEmail,string password, float sumToPay, string cardNumber, string dateOfCard, string cvc, string zipCode, string region, string city, string street, string utility)
        {
            var loginPage = welcomePage.SignIn();
            LogProgress("Entered to login page");
            var homePage = loginPage.LoginAsUser(userEmail, "Admin123");
            LogProgress($"Trying to login as user email:{userEmail}, password:{password}");

            Assert.IsTrue(driver.GetUrl().Contains("http://localhost:8080/home"));
            LogProgress("Succefully logined");

            var paymentHistoryPage = homePage.NavigateToPaymentHistoryPage();
            LogProgress("Navigating to payment history page");

            var address = region + ", " + city + ", " + street;
            paymentHistoryPage.SelectAddress(address);
            LogProgress($"Selecting address:{address}");
            paymentHistoryPage.SelectUtility(utility);
            LogProgress($"Selecting utility:{utility}");
            var oldTableOfPayments = paymentHistoryPage.InitTable();
            LogProgress("Initing table");
            var oldPayTableRows = oldTableOfPayments.GetAllRows();
            LogProgress("Collecting rows of table");

            var payPage = paymentHistoryPage.NavigateToPaymentPage();
            LogProgress("Navigating to payment page");
            address = street + ", " + city + ", " + region;
            payPage.SelectAddress(address);
            LogProgress($"Selecting address:{address}");

            var utilityDetails = payPage.NavigateToUtilityDetails(utility);
            LogProgress($"Navigating to utility:{utility} details");
            var selectPaymentSum = utilityDetails.NavigateToSelectPaymentSum();
            LogProgress("Navigating to select payment sum page");
            selectPaymentSum.ChooseDownloadCheck();
            LogProgress("Choosing \"Download check\" option");

            var payFrame = selectPaymentSum.PayForSum(sumToPay);
            LogProgress("Navigating to pay frame");
            var homePageAndUrlOfCheck = payFrame.Pay(userEmail, cardNumber, dateOfCard, cvc, zipCode);
            LogProgress($"Entering data - email:{userEmail}, cardnumber:{cardNumber}, date of card:{dateOfCard}, cvc:{cvc}, Zip code:{zipCode}");
            var urlOfCheck = homePageAndUrlOfCheck.Item2;
            LogProgress($"Saving check url{urlOfCheck}");
            homePage = homePageAndUrlOfCheck.Item1;
            
            paymentHistoryPage = homePage.NavigateToPaymentHistoryPage();
            LogProgress("Navigating to payment history page");
            address = region + ", " + city + ", " + street;
            paymentHistoryPage.SelectAddress(address);
            LogProgress($"Selecting address:{address}");
            paymentHistoryPage.SelectUtility(utility);
            LogProgress($"Selecting utility:{utility}");

            var newTableOfPayments = paymentHistoryPage.InitTable();
            LogProgress("Initing table");
            var newPayTableRows = newTableOfPayments.GetAllRows();
            LogProgress("Collecting rows of table");
            CollectionAssert.AreNotEqual(oldPayTableRows, newPayTableRows, "All checks matches old ones, no new check added to history");

            var newLastPay = newTableOfPayments.GetLastRow();
            LogProgress("Collecting last row of table");

            var newLastPayDate = newLastPay.GetDateFromRow();
            Assert.AreEqual(DateTime.Today, newLastPayDate, "Date of last pay doesn't match today date");

            var newLastPaySum = newLastPay.GetSumFromRow();
            Assert.AreEqual(DateTime.Today, newLastPayDate, "Date of last pay doesn't match today date");

            newLastPay.ViewCheck();
            LogProgress("Opening check from last row of table");
            var newLastPayCheck = driver.GetUrl();
            StringAssert.Contains(newLastPayCheck, urlOfCheck, "Url of last check doesn't match today's url of check");
        }
    }
}
