using HttpLibrary;
using RestSharp;
using System.Configuration;

namespace SimpleApiTests
{
    public class ClientFactory
    {
        public static ClientWrapper GetClient()
        {
            return new ClientWrapper(ConfigurationManager.AppSettings.Get("ApiServer"));
        }
    }
}
