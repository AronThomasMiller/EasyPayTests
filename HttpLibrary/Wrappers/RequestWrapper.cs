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

        public RequestWrapper AddJsonBody<T>(T obj)
        {
            var serializedToJson = JsonConvert.SerializeObject(obj);
            Request.AddJsonBody(serializedToJson);
            return this;
        }

        public RequestWrapper(string source)
        {
            Request = new RestRequest(source);
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
