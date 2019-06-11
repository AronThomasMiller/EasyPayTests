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
    public class PostsSource:BaseSOM
    {
        private PostsSource(string source)
        {
            this.source = source;
        }

        public PostsSource(ClientWrapper client):this("/api/posts")
        {
            this.client = client;
        }

        public IEnumerable<Post> GetAllPosts()
        {
            var getRequest = new RequestWrapper(source, Methods.GET);
            
            var getResponse = client.Execute(getRequest);
            var getStatus = getResponse.StatusCode;

            if (getStatus != HttpStatusCode.OK) return null;

            var responseListOfPosts = getResponse.Content;
            var list = JsonConvert.DeserializeObject<IEnumerable<Post>>(responseListOfPosts);

            return list;
        }

        public Post GetPostById(string id)
        {
            var getRequest = new RequestWrapper($"{source}/{id}", Methods.GET);

            var getResponse = client.Execute(getRequest);
            var getStatus = getResponse.StatusCode;
            
            if (getStatus != HttpStatusCode.OK) return null;

            var responsePost = getResponse.Content;
            var postById = JsonConvert.DeserializeObject<Post>(responsePost);
            return postById;
        }

        public Post AddPost(BasePost post)
        {
            var request = new RequestWrapper(source, Methods.POST);
            request.AddJsonBody(post);

            var postResponse = client.Execute(request);
            var postStatus = postResponse.StatusCode;

            if (postStatus != HttpStatusCode.OK) return null;

            var postContent = postResponse.Content;
            var deserContent = JsonConvert.DeserializeObject<Post>(postContent);
            return deserContent;
        }

        public Post UpdatePost(Post post)
        {
            var request = new RequestWrapper(source, Methods.PUT);

            request.AddJsonBody(post);

            var putResponse = client.Execute(request);
            var putStatus = putResponse.StatusCode;

            if (putStatus != HttpStatusCode.OK) return null;

            var putContent = putResponse.Content;
            var deserContent = JsonConvert.DeserializeObject<Post>(putContent);
            return deserContent;
        }

        public bool DeletePost(string id)
        {
            var deleteRequest = new RequestWrapper($"{source}/{id}", Methods.DELETE);
            var deleteResponse = client.Execute(deleteRequest);
            var deleteStatus = (int)deleteResponse.StatusCode;
            return deleteStatus <= 400;
        }
    }
}
