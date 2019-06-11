using FileManager;
using HttpLibrary;
using HttpLibrary.Containers;
using Newtonsoft.Json;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using static HttpLibrary.RequestWrapper;

namespace SimpleApiTests
{
    class ApiPostsRate
    {
        private readonly static string ApiResourse = "/api/posts/rate";
        protected string TestSuitDataPlace => ApiTestData.AllTestSuitesDataPlace + "\\ApiPostsRate";

        [SetUp]
        public void SetUp()
        {
            ApiTestData.Api.DeleteDataFile("PostRate.json");
        }

        //[Test]
        //public void TestPost()
        //{
        //    var client = ClientFactory.GetClient(ApiTestData.Api.Url);

        //    var testData = FileMaster.GetAllTextFromFile($"{TestSuitDataPlace}\\TestPost.json");
        //    var startList = JsonConvert.DeserializeObject<List<BasePostRate>>(testData);
        //    float expectedAvgOfRates = 0;
        //    foreach (var rate in startList)
        //    {
        //        expectedAvgOfRates += rate.Rate;
        //        var postRequest = new RequestWrapper(ApiResourse, Methods.POST);
        //        postRequest.AddJsonBody(rate);
        //        var response = client.Execute(postRequest);

        //        var reponseCode = response.StatusCode;
        //        Assert.AreEqual(HttpStatusCode.OK, reponseCode);
        //        var reponseContent = response.Content;
        //        var postedRate = JsonConvert.DeserializeObject<Post>(reponseContent);

        //        Assert.AreEqual(rate.PostId, postedRate.Id);
        //    }
        //    expectedAvgOfRates /= startList.Count;

        //    var postIdOfAddedRates = startList.First().PostId;
        //    var getRequest = new RequestWrapper($"{ApiPosts.ApiResourse}/{postIdOfAddedRates}", Methods.GET);
        //    var getResponse = client.Execute(getRequest);
        //    var getStatus = getResponse.StatusCode;
        //    Assert.AreEqual(HttpStatusCode.OK, getStatus);

        //    var getContent = getResponse.Content;
        //    var getResultPost = JsonConvert.DeserializeObject<Post>(getContent);
        //    var actualAvgOfRates = getResultPost.Rate;
        //    Assert.AreEqual(expectedAvgOfRates, actualAvgOfRates);
        //}
    }
}
