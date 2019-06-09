using HttpLibrary;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Net;
using static HttpLibrary.RequestWrapper;

namespace SimpleApiTests
{
    [Parallelizable(ParallelScope.Fixtures)]
    public class ApiPosts
    {
        private readonly static string ApiResourse = "/api/posts";
        protected string TestSuitDataPlace => ApiTestData.AllTestSuitesDataPlace + "ApiPosts\\";


        [Test(Author = "Boris")]
        public void TestGet()
        {
            var client = ClientFactory.GetClient(ApiTestData.Api.Url);
            var request = new RequestWrapper(ApiResourse, Methods.GET);
            
            var response = client.Execute(request);
            var status = response.StatusCode;
            Assert.AreEqual(HttpStatusCode.OK, status);
            var expectedListOfPosts = ApiTestData.Api.GetFileDataFromAPI<Post>("PostInfo.json");
            var actualListOfPosts = JsonConvert.DeserializeObject<List<Post>>(response.Content);
            Assert.AreEqual(expectedListOfPosts, actualListOfPosts);
        }
        
        [TestCase("2bf2a204-d089-4dd2-920e-da8550a7882d", Author = "Boris")]
        public void TestGetById(string inputId)
        {
            var client = ClientFactory.GetClient(ApiTestData.Api.Url);
            var getRequest = new RequestWrapper($"{ApiResourse}/{inputId}", Methods.GET);
            var getResponse = client.Execute(getRequest);
            var getStatus = getResponse.StatusCode;
            Assert.AreEqual(HttpStatusCode.OK, getStatus);
            var responsePost = JsonConvert.DeserializeObject<Post>(getResponse.Content);
            Assert.AreEqual(inputId, responsePost.Id);
        }

        [Test(Author = "Boris")]
        public void TestPost()
        {
            var DataForTestPath = $"{TestSuitDataPlace}TestPost.json";
            var testData = Post.FromJsonFile(DataForTestPath);
            Assert.NotNull(testData, "Test data is empty");

            var client = ClientFactory.GetClient(ApiTestData.Api.Url);
            var request = new RequestWrapper(ApiResourse, Methods.POST);

            request.AddJsonFile(DataForTestPath);

            var postResponse = client.Execute(request);
            var postStatus = postResponse.StatusCode;
            var postContent = postResponse.Content;
            Assert.AreEqual(HttpStatusCode.OK, postStatus);
            Assert.NotNull(postContent, "Nothing added");
        }

        [Test(Author = "Boris")]
        public void TestPut()
        {
            var DataForTestPath = $"{TestSuitDataPlace}TestPut.json";
            var testData = Post.FromJsonFile(DataForTestPath);
            var fileSize = testData.Length;
            Assert.AreNotEqual(0, fileSize, "Test data is empty");

            var client = ClientFactory.GetClient(ApiTestData.Api.Url);
            var request = new RequestWrapper(ApiResourse, Methods.PUT);

            request.AddJsonFile(DataForTestPath);
            
            var putResponse = client.Execute(request);
            var putStatus = putResponse.StatusCode;
            var putContent = putResponse.Content;
            Assert.AreEqual(HttpStatusCode.OK, putStatus);
            Console.WriteLine(putContent);
            Assert.NotNull(putContent, "Nothing updated");
        }

        [TestCase("a1af5731-2b80-4ba3-96e5-b06cd24e272c", Author = "Boris")]
        public void TestDelete(string inputId)
        {
            var client = ClientFactory.GetClient(ApiTestData.Api.Url);
            var request = new RequestWrapper($"{ApiResourse}/?{inputId}", Methods.DELETE);

            var response = client.Execute(request);
            var status = response.StatusCode;
            Assert.AreEqual(HttpStatusCode.OK, status);

        }
    }
}
