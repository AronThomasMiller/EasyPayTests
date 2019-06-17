using FileManager;
using HttpLibrary;
using HttpLibrary.Containers;
using HttpLibrary.SOM.Api.Comments;
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
    public class ApiComments
    {
        protected string TestSuitDataPlace => $"{ApiTestData.AllTestSuitesDataPlace}\\Api\\Comments";
        protected ClientWrapper client;
        private string token;

        [SetUp]
        public void SetUp()
        {
            client = ClientFactory.GetClient(ApiTestData.Api.Url);
            ApiTestData.Api.WriteToApiDataFile(ApiTestData.FilesToReplace, "PostInfo", "json");
            ApiTestData.Api.WriteToApiDataFile(ApiTestData.FilesToReplace, "UserData", "json");
            ApiTestData.Api.WriteToApiDataFile(ApiTestData.FilesToReplace, "CommentInfo", "json");
            
            var loginSource = new LoginResource(client);
            var testData = FileMaster.GetAllTextFromFile($"{ApiTestData.AllTestSuitesDataPlace}\\User\\Login\\TestPost.json");
            var user = JsonConvert.DeserializeObject<LoginModel>(testData);
            var loginedUser = loginSource.Login(user);
            token = loginedUser.Token;
        }

        [Test]
        public void AddComment()
        {
            var json = FileMaster.GetAllTextFromFile($"{TestSuitDataPlace}\\TestPost.json");
            var testComment = JsonConvert.DeserializeObject<CommentBase>(json);

            var commentResource = new CommentsResource(client);
            var commentWasAdded = commentResource.AddComment(testComment, token);
            Assert.That(commentWasAdded, Is.True, "Comment wasn't added");
        }

        [Test]
        public void GetComment()
        {
            var testData = FileMaster.GetAllTextFromFile($"{TestSuitDataPlace}\\TestPost.json");
            var comments = JsonConvert.DeserializeObject<CommentBase>(testData);
            var postId = comments.PostId;

            var commentResource = new CommentsResource(client);
            var commentById = commentResource.GetCommentByPostId(postId, token);
            Assert.That(commentById, Is.Not.Null, "No commentfound");
            Assert.That(commentById.PostId, Is.EqualTo(postId),"Comment id, doesn't match required id");
        }
    }
}
