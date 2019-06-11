using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static HttpLibrary.RequestWrapper;

namespace HttpLibrary.SOM.Users.TestAuth
{
    public class TestAuthSource:BaseSOM
    {

        private TestAuthSource(string source)
        {
            this.source = source;
        }

        public TestAuthSource(ClientWrapper client) : this("/Users/TestAuth")
        {
            this.client = client;
        }

        public bool TestAuthentication(string token)
        {
            var request = new RequestWrapper(source, Methods.GET);
            request.AddHeader("Authorization", $"Bearer {token}");
            var response = client.Execute(request);
            var status = response.StatusCode;
            return status == HttpStatusCode.OK;
        }
    }
}
