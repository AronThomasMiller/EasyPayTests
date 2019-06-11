using FileManager;
using HttpLibrary;
using HttpLibrary.Containers;
using HttpLibrary.SOM.Api;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using static HttpLibrary.RequestWrapper;

namespace SimpleApiTests
{
    [Parallelizable(ParallelScope.Fixtures)]
    public class ApiPosts
    {
        protected string TestSuitDataPlace => $"{ApiTestData.AllTestSuitesDataPlace}\\ApiPosts";
        protected IEnumerable<Post> StartPosts;
        private ClientWrapper client;

        [SetUp]
        public void SetUp()
        {
            client = ClientFactory.GetClient(ApiTestData.Api.Url);
            ApiTestData.Api.WriteToApiDataFile(ApiTestData.FilesToReplace, "PostInfo", "json");
            var jsonString = FileMaster.GetAllTextFromFile($"{ApiTestData.FilesToReplace}\\PostInfo.json");
            StartPosts = JsonConvert.DeserializeObject<IEnumerable<Post>>(jsonString);
        }

        [Test(Author = "Boris")]
        public void TestGet()
        {
            var expectedList = StartPosts;
            Assert.That(expectedList, Is.Not.Empty, "Mock data for api is empty");

            var postSource = new PostSource(client);
            var actualList = postSource.GetAllPosts();
            Assert.That(actualList, Is.Not.Empty, "Api sourse isn't empty, but api returns nothing");
            CollectionAssert.AreEqual(expectedList, actualList);
        }

        [TestCase(Author = "Boris")]
        public void TestGetById()
        {
            string inputId = StartPosts.First().Id;
            var postSource = new PostSource(client);
            var postByIdFromSource = postSource.GetPostById(inputId);
            var expectedId = inputId;
            var actualId = postByIdFromSource.Id;
            Assert.That(actualId, Is.EqualTo(expectedId));
        }

        [TestCase(Author = "Boris")]
        public void TestGetByIdNegative()
        {
            var inputId = StartPosts.First().Id;
            var postSource = new PostSource(client);
            var postWasDeleted = postSource.DeletePost(inputId);
            Assert.That(postWasDeleted, Is.True, "Problems with deleting post");
            
            var postByIdFromSource = postSource.GetPostById(inputId);
            var expectedId = inputId;
            var actualId = postByIdFromSource?.Id;
            Assert.That(actualId, Is.EqualTo(expectedId));
        }

        [Test(Author = "Boris")]
        public void TestPost()
        {
            var DataForTestPath = $"{TestSuitDataPlace}\\TestPost.json";
            var testDataJson = FileMaster.GetAllTextFromFile(DataForTestPath);
            var fileSize = testDataJson.Length;
            Assert.That(fileSize, Is.Not.EqualTo(0), "Test data is empty");

            var postSource = new PostSource(client);
            var testDataPost = JsonConvert.DeserializeObject<BasePost>(testDataJson);

            var postResult = postSource.AddPost(testDataPost);
            Assert.That(postResult, Is.Not.Null, "Nothing added");

            var actualBasePost = postResult as BasePost;
            Assert.That(actualBasePost, Is.EqualTo(testDataPost), "Api added wrong data");
        }

        [Test(Author = "Boris")]
        public void TestPut()
        {
            var DataForTestPath = $"{TestSuitDataPlace}\\TestPut.json";
            var testDataJson = FileMaster.GetAllTextFromFile(DataForTestPath);
            var fileSize = testDataJson.Length;
            Assert.That(fileSize, Is.Not.Zero, "Test data is empty");

            var postSource = new PostSource(client);
            var testDataPost = JsonConvert.DeserializeObject<Post>(testDataJson);

            var putReponse = postSource.UpdatePost(testDataPost);

            Assert.That(putReponse, Is.Not.Null, "Nothing updated");
            Assert.That(putReponse, Is.EqualTo(testDataPost), "Update gone wrong, fields missmatch");

            var getUpdatedPost = postSource.GetPostById(putReponse.Id);

            Assert.That(putReponse, Is.EqualTo(testDataPost), "Api returnes not updated data");
        }

        [TestCase(Author = "Boris")]
        public void TestDelete()
        {
            var postToDeleteId = StartPosts.First().Id;
            var expectedList = StartPosts.Where(x => x.Id != postToDeleteId);

            var postSource = new PostSource(client);
            var postWasDeleted = postSource.DeletePost(postToDeleteId);
            Assert.That(postWasDeleted, Is.True, "Problems with deleting post");

            var actualList = postSource.GetAllPosts();
            var apiContainDeleted = actualList.Any(x => x.Id == postToDeleteId);
            Assert.That(apiContainDeleted, Is.False, "Resourse contains deleted id");

            CollectionAssert.AreEqual(expectedList, actualList, $"Api didn't delete post");
        }

        [TestCase(Author = "Boris")]
        public void TestDeleteNegative()
        {
            var postToDeleteId = "not existing id";
            var testDataContainsDeleted = StartPosts.Any(x => x.Id == postToDeleteId);
            Assert.That(testDataContainsDeleted, Is.False, "TestData contains deleted id");

            var expectedList = StartPosts.Where(x => x.Id != postToDeleteId);

            var postSource = new PostSource(client);
            var postWasDeleted = postSource.DeletePost(postToDeleteId);
            Assert.That(postWasDeleted, Is.Not.True, "Api \"can\" delete non-existing post");

            var actualList = postSource.GetAllPosts();

            var apiContainsDeleted = actualList.Any(x => x.Id == postToDeleteId);
            Assert.That(apiContainsDeleted, Is.False, "Resourse contains deleted id");

            var actualListSize = actualList.Count();
            var expectedListSize = expectedList.Count();
            Assert.That(actualListSize, Is.EqualTo(expectedListSize), "Api deletes something not by id logic");
        }
    }
}
