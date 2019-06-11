using FileManager;
using HttpLibrary;
using HttpLibrary.Containers;
using HttpLibrary.SOM.Api;
using Newtonsoft.Json;
using NUnit.Framework;
using SimpleApiTests;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using static HttpLibrary.RequestWrapper;

namespace EasyPayTests.RestTests
{
    class ApiPostsRate
    {
        protected string TestSuitDataPlace => ApiTestData.AllTestSuitesDataPlace + "\\ApiPostsRate";
        protected ClientWrapper client;
        [SetUp]
        public void SetUp()
        {
            client = ClientFactory.GetClient(ApiTestData.Api.Url);
            ApiTestData.Api.DeleteDataFile("PostRate.json");
            ApiTestData.Api.WriteToApiDataFile(ApiTestData.FilesToReplace, "PostInfo", "json");
        }

        [Test]
        public void AddRate()
        {
            var testData = FileMaster.GetAllTextFromFile($"{TestSuitDataPlace}\\TestPost.json");
            var postRateData = JsonConvert.DeserializeObject<List<BasePostRate>>(testData);

            float expectedAvgOfRates = 0;
            foreach (var rate in postRateData)
            {
                expectedAvgOfRates += rate.Rate;

                var rateSource = new PostsRatesSource(client);
                var postedRate = rateSource.AddRate(rate);

                Assert.That(postedRate.Id, Is.EqualTo(rate.PostId), "");
            }
            expectedAvgOfRates /= postRateData.Count;

            var postIdOfAddedRates = postRateData.First().PostId;
            var postSource = new PostsSource(client);
            var getResultPost = postSource.GetPostById(postIdOfAddedRates);
            var actualAvgOfRates = getResultPost.Rate;
            Assert.That(actualAvgOfRates, Is.EqualTo(expectedAvgOfRates));
        }
    }
}
