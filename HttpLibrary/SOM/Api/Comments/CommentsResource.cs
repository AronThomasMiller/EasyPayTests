using HttpLibrary.Containers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static HttpLibrary.RequestWrapper;

namespace HttpLibrary.SOM.Api.Comments
{
    public class CommentsResource:BaseROM
    {
        public CommentsResource(ClientWrapper client) : base("/Api/Comments")
        {
            this.client = client;
        }

        public bool AddComment(CommentBase comment, string token)
        {
            var request = new RequestWrapper(resource, Methods.POST);
            request.AddHeader("Authorization", $"Bearer {token}");
            request.AddJsonBody(comment);
            var response = client.Execute(request);
            var status = response.StatusCode;
            return status == HttpStatusCode.OK;
        }

        public CommentInfo GetCommentByPostId(string id, string token)
        {
            var request = new RequestWrapper($"{resource}/{id}", Methods.GET);

            request.AddHeader("Authorization", $"Bearer {token}");
            var response = client.Execute(request);
            var status = response.StatusCode;

            if (status != HttpStatusCode.OK) return null;

            var responseComment = response.Content;
            var commentById = JsonConvert.DeserializeObject<IEnumerable<CommentInfo>>(responseComment);
            return commentById.First();
        }
    }
}
