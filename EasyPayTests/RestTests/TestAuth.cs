using FileManager;
using HttpLibrary;
using HttpLibrary.Containers;
using HttpLibrary.SOM.Users.Login;
using HttpLibrary.SOM.Users.TestAuth;
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
    class TestAuth
    {
        protected ClientWrapper client;

        [SetUp]
        public void SetUp()
        {
            client = ClientFactory.GetClient(ApiTestData.Api.Url);
            ApiTestData.Api.WriteToApiDataFile(ApiTestData.FilesToReplace, "UserData", "json");
        }

        [Test]
        public void TestAuthentication()
        {
            var loginSource = new LoginSource(client);

            var testData = FileMaster.GetAllTextFromFile($"{UserLogin.TestSuitDataPlace}\\TestPost.json");
            var userData = JsonConvert.DeserializeObject<LoginModel>(testData);
            var loginedUser = loginSource.Login(userData);

            Assert.That(loginedUser, Is.Not.Null, "Logined unsuccesful");
            Assert.That(loginedUser.Email, Is.EqualTo(userData.Email), "Logined unsuccesful");

            var testAuthSource = new TestAuthSource(client);
            var canLogin = testAuthSource.TestAuthentication(loginedUser.Token);

            Assert.That(canLogin, Is.True, $"User with email: {loginedUser.Email} can not login");
        }
    }
}
