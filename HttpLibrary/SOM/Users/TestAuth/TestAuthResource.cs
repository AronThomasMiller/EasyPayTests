using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static HttpLibrary.RequestWrapper;

namespace HttpLibrary.SOM.Users.TestAuth
{
    public class TestAuthResource:BaseROM
    {
        public TestAuthResource(ClientWrapper client) : base("/Users/TestAuth")
        {
            this.client = client;
        }

        public bool TestAuthentication(string token)
        {
            var request = new RequestWrapper(resource, Methods.GET);
            request.AddHeader("Authorization", $"Bearer {token}");
            var response = client.Execute(request);
            var status = response.StatusCode;
            return status == HttpStatusCode.OK;
        }
    }
}
