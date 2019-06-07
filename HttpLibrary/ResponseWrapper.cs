using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace HttpLibrary
{
    public class ResponseWrapper
    {
        public IRestResponse Response { get; set; }

        public ResponseWrapper(IRestResponse response)
        {
            Response = response;
        }

        public string Content => Response.Content;
        public HttpStatusCode StatusCode => Response.StatusCode;
    }
}
