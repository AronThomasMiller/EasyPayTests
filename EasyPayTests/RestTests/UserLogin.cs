using FileManager;
using HttpLibrary;
using HttpLibrary.Containers;
using HttpLibrary.SOM.Users.Login;
using Newtonsoft.Json;
using NUnit.Framework;
using SimpleApiTests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPayTests.RestTests
{
    public class UserLogin
    {
        public static string TestSuitDataPlace => $"{ApiTestData.AllTestSuitesDataPlace}\\User\\Login";
        private ClientWrapper client;

        [SetUp]
        public void SetUp()
        {
            client = ClientFactory.GetClient(ApiTestData.Api.Url);
            ApiTestData.Api.WriteToApiDataFile(ApiTestData.FilesToReplace, "UserData", "json");
        }

        [Test]
        public void Login()
        {
            var loginSource = new LoginSource(client);

            var testData = FileMaster.GetAllTextFromFile($"{TestSuitDataPlace}\\TestPost.json");
            var userData = JsonConvert.DeserializeObject<LoginModel>(testData);
            var loginedUser = loginSource.Login(userData);

            Assert.That(loginedUser, Is.Not.Null, "Logined unsuccesful");
            Assert.That(loginedUser.Email, Is.EqualTo(userData.Email), "Logined unsuccesful");
        }
    }
}
