using HttpLibrary.Containers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static HttpLibrary.RequestWrapper;

namespace HttpLibrary.SOM.Users
{
    public class UsersSource : BaseSOM
    {
        private UsersSource(string source)
        {
            this.source = source;
        }

        public UsersSource(ClientWrapper client) : this("/Users")
        {
            this.client = client;
        }

        public UserData AddUser(AddApiUser user)
        {
            var request = new RequestWrapper(source, Methods.POST);
            request.AddJsonBody(user);
            var response = client.Execute(request);

            var postStatus = response.StatusCode;
            if (postStatus != HttpStatusCode.OK) return null;

            return JsonConvert.DeserializeObject<UserData>(response.Content);
        }
    }
}
