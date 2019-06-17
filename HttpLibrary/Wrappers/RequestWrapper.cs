using System;
using FileManager;
using Newtonsoft.Json;
using RestSharp;

namespace HttpLibrary
{
    public class RequestWrapper
    {
        public IRestRequest Request { get; set; }

        public Methods MethodOfRequest
        {
            set => Request.Method = (Method)value;
        }

        public enum Methods
        {
            PUT = Method.PUT,
            POST = Method.POST,
            DELETE = Method.DELETE,
            GET = Method.GET
        }

        public RequestWrapper(string source, Methods method)
        {
            Request = new RestRequest(source, (Method)method);
        }

        public RequestWrapper AddJsonBody(object obj)
        {
            Request.AddJsonBody(obj);
            return this;
        }

        public RequestWrapper(string resource)
        {
            Request = new RestRequest(resource);
        }

        public RequestWrapper AddJsonFile(string pathToFile)
        {
            var data = FileMaster.GetAllTextFromFile(pathToFile);
            Request = Request.AddJsonBody(data);
            return this; 
        }

        public void AddHeader(string name, string value)
        {
            Request.AddHeader(name, value);
        }
    }
}
