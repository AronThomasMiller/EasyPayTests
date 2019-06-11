using HttpLibrary;
using System.Configuration;

namespace HttpLibrary
{
    public static class ClientFactory
    {
        public static ClientWrapper GetClient(string apiUrl)
        {
            return new ClientWrapper(apiUrl);
        }
    }
}
