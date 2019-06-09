using HttpLibrary;
using RestSharp;
using System.Configuration;

namespace SimpleApiTests
{
    public class ClientFactory
    {
        public static ClientWrapper GetClient(string apiUrl)
        {
            return (apiUrl == null)
                ? new ClientWrapper(ConfigurationManager.AppSettings.Get("ApiUrl"))
                : new ClientWrapper(apiUrl);
        }
    }
}
