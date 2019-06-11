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
    public class PostsRatesSource : BaseSOM
    {
        private PostsRatesSource(string source)
        {
            this.source = source;
        }

        public PostsRatesSource(ClientWrapper client) : this("/api/posts/rate")
        {
            base.client = client;
        }

        public Post AddRate(BasePostRate rate)
        {
            var postRequest = new RequestWrapper(source, Methods.POST);
            postRequest.AddJsonBody(rate);
            var response = client.Execute(postRequest);

            var reponseCode = response.StatusCode;
            
            if (reponseCode != HttpStatusCode.OK) return null;

            var reponseContent = response.Content;
            var postedRate = JsonConvert.DeserializeObject<Post>(reponseContent);
            return postedRate;
        }
    }
}
