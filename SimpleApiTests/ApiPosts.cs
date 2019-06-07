using HttpLibrary;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using static HttpLibrary.RequestWrapper;

namespace SimpleApiTests
{
    public class ApiPosts : BaseTest
    {
        private List<Post> GetPosts()
        {
            string dataFile = "PostInfo.json";
            var jsonString = Post.FromJsonFile(ApiDataPlace + dataFile);
            return JsonConvert.DeserializeObject<List<Post>>(jsonString);
        }

        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            TestsuitDataPlace += @"ApiPosts\";
            TestName = TestContext.CurrentContext.Test.MethodName;
            request = new RequestWrapper("/api/posts");
        }

        [Test(Author = "Boris")]
        public void TestGet()
        {
            request.MethodOfRequest = Methods.GET;
            var response = client.Execute(request);
            var status = response.StatusCode;
            Assert.AreEqual(HttpStatusCode.OK, status);
            var expectedListOfPosts = GetPosts();
            var actualListOfPosts = JsonConvert.DeserializeObject<List<Post>>(response.Content);
            Assert.AreEqual(expectedListOfPosts, actualListOfPosts);
        }

        [TestCase("2bf2a204-d089-4dd2-920e-da8550a7882d", Author = "Boris")]
        public void TestGetById(string inputId)
        {
            request = new RequestWrapper($"/api/posts/{inputId}", Methods.GET);
            var response = client.Execute(request);
            var status = response.StatusCode;
            Assert.AreEqual(HttpStatusCode.OK, status);
            var responsePost = JsonConvert.DeserializeObject<Post>(response.Content);
            Assert.AreEqual(inputId, responsePost.Id);
        }

        [Test(Author = "Boris")]
        public void TestPost()
        {
            var DataForTestPath = $@"{TestsuitDataPlace}{TestName}.json";
            var testData = Post.FromJsonFile(DataForTestPath);
            Assert.NotNull(testData, "Test data is empty");

            request.MethodOfRequest = Methods.POST;
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

        }
    }
}
