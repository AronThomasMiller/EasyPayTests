using HttpLibrary.Containers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static HttpLibrary.RequestWrapper;

namespace HttpLibrary.SOM.Api
{
    public class PostsResource:BaseROM
    {
        public PostsResource(ClientWrapper client):base("/api/posts")
        {
            this.client = client;
        }

        public IEnumerable<PostInfo> GetAllPosts()
        {
            var getRequest = new RequestWrapper(resource, Methods.GET);
            
            var getResponse = client.Execute(getRequest);
            var getStatus = getResponse.StatusCode;

            if (getStatus != HttpStatusCode.OK) return null;

            var responseListOfPosts = getResponse.Content;
            var list = JsonConvert.DeserializeObject<IEnumerable<PostInfo>>(responseListOfPosts);

            return list;
        }

        public PostInfo GetPostById(string id)
        {
            var getRequest = new RequestWrapper($"{resource}/{id}", Methods.GET);

            var getResponse = client.Execute(getRequest);
            var getStatus = getResponse.StatusCode;
            
            if (getStatus != HttpStatusCode.OK) return null;

            var responsePost = getResponse.Content;
            var postById = JsonConvert.DeserializeObject<PostInfo>(responsePost);
            return postById;
        }

        public PostInfo AddPost(BasePost post)
        {
            var request = new RequestWrapper(resource, Methods.POST);
            request.AddJsonBody(post);

            var postResponse = client.Execute(request);
            var postStatus = postResponse.StatusCode;

            if (postStatus != HttpStatusCode.OK) return null;

            var postContent = postResponse.Content;
            var deserContent = JsonConvert.DeserializeObject<PostInfo>(postContent);
            return deserContent;
        }

        public PostInfo UpdatePost(PostInfo post)
        {
            var request = new RequestWrapper(resource, Methods.PUT);

            request.AddJsonBody(post);

            var putResponse = client.Execute(request);
            var putStatus = putResponse.StatusCode;

            if (putStatus != HttpStatusCode.OK) return null;

            var putContent = putResponse.Content;
            var deserContent = JsonConvert.DeserializeObject<PostInfo>(putContent);
            return deserContent;
        }

        public bool DeletePost(string id)
        {
            var deleteRequest = new RequestWrapper($"{resource}/{id}", Methods.DELETE);
            var deleteResponse = client.Execute(deleteRequest);
            var deleteStatus = (int)deleteResponse.StatusCode;
            return deleteStatus <= 400;
        }
    }
}
