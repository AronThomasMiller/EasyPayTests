using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HttpLibrary
{
    public class ClientWrapper
    {
        public IRestClient Client { get; set; }

        public ClientWrapper(string apiUrl)
        {
            Client = new RestClient(apiUrl);
        }

        public ResponseWrapper Execute(RequestWrapper request)
        {
            var req = request.Request;
            return new ResponseWrapper(Client.Execute(req));
        }
    }
}
