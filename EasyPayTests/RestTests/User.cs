using FileManager;
using HttpLibrary;
using HttpLibrary.Containers;
using HttpLibrary.SOM.Users;
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
            var usersSource = new UsersSource(client);
            var jsonString = FileMaster.GetAllTextFromFile($"{TestSuitDataPlace}\\TestPost.json");
            var user = JsonConvert.DeserializeObject<AddApiUser>(jsonString);
            usersSource.AddUser(user);
        }
    }
}
