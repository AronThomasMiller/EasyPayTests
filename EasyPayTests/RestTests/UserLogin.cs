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
            var loginSource = new LoginResource(client);

            var testData = FileMaster.GetAllTextFromFile($"{TestSuitDataPlace}\\TestPost.json");
            var user = JsonConvert.DeserializeObject<LoginModel>(testData);
            var loginedUser = loginSource.Login(user);
            Console.WriteLine(loginedUser.Token);

            Assert.That(loginedUser, Is.Not.Null, "Login gone unsuccesful");
            Assert.That(loginedUser.Email, Is.EqualTo(user.Email), "Email doesn't match original one");
            Assert.That(loginedUser.Password, Is.EqualTo(user.Password), "Password doesn't match original one");
        }

        [Test]
        public void LoginNegativeEmail()
        {
            var loginSource = new LoginResource(client);

            var testData = FileMaster.GetAllTextFromFile($"{TestSuitDataPlace}\\TestPost.json");
            var user = JsonConvert.DeserializeObject<LoginModel>(testData);
            user.Email += "1";
            var loginedUser = loginSource.Login(user);

            Assert.That(loginedUser, Is.Not.Null, "Login gone unsuccesful");
        }

        [Test]
        public void LoginNegativePassword()
        {
            var loginSource = new LoginResource(client);

            var testData = FileMaster.GetAllTextFromFile($"{TestSuitDataPlace}\\TestPost.json");
            var userData = JsonConvert.DeserializeObject<LoginModel>(testData);
            userData.Password += "1";
            var loginedUser = loginSource.Login(userData);

            Assert.That(loginedUser, Is.Not.Null, "Login gone unsuccesful");
        }
    }
}
