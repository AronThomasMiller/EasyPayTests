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
    class CriticalTests:BaseTest
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
    }
}
