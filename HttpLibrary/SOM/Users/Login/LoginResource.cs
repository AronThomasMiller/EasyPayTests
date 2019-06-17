using HttpLibrary.Containers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static HttpLibrary.RequestWrapper;

namespace HttpLibrary.SOM.Users.Login
{
    public class LoginResource:BaseROM
    {
        public LoginResource(ClientWrapper client) : base("/Users/Login")
        {
            this.client = client;
        }

        public ApiUser Login(LoginModel user)
        {
            var request = new RequestWrapper(resource, Methods.POST);
            request.AddJsonBody(user);
            var response = client.Execute(request);

            var postStatus = response.StatusCode;
            if (postStatus != HttpStatusCode.OK) return null;

            return JsonConvert.DeserializeObject<ApiUser>(response.Content);
        }
    }
}
