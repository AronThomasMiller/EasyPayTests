using FileManager;
using HttpLibrary;
using HttpLibrary.Containers;
using HttpLibrary.SOM.Users;
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
    public class User
    {
        protected string TestSuitDataPlace => $"{ApiTestData.AllTestSuitesDataPlace}\\User";
        private ClientWrapper client;

        [SetUp]
        public void SetUp()
        {
            ApiTestData.Api.DeleteDataFile("UserData.json");
            client = ClientFactory.GetClient(ApiTestData.Api.Url);
        }

        [Test]
        public void AddUser()
        {
            var usersSource = new UsersResource(client);
            var jsonString = FileMaster.GetAllTextFromFile($"{TestSuitDataPlace}\\TestPost.json");
            var user = JsonConvert.DeserializeObject<AddApiUser>(jsonString);
            var addedUser = usersSource.AddUser(user);
            var addedUserEqualUser = user.Equals(addedUser);
            Assert.That(addedUserEqualUser, Is.True, "Response user data doesn't match original data");
        }
        
        [Test]
        public void AddExistingUserNegative()
        {
            AddUser();
            AddUser();
        }
    }
}
