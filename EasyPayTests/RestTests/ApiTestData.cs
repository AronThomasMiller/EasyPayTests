using HttpLibrary;
using NUnit.Framework;
using System;
using System.Configuration;
using System.IO;

namespace SimpleApiTests
{
    public static class ApiTestData
    {
        public static Api Api { get; }
        public static readonly string AllTestSuitesDataPlace;
        public static readonly string FilesToReplace;

        static ApiTestData()
        {
            string projectLocation;
#if DEBUG
            projectLocation = AppDomain.CurrentDomain.BaseDirectory.Replace("\\bin\\Debug", "");
#else
                projectLocation = AppDomain.CurrentDomain.BaseDirectory.Replace("\\bin\\Release", "");
#endif
            AllTestSuitesDataPlace = $"{projectLocation}TestData";
            FilesToReplace = $"{AllTestSuitesDataPlace}\\FilesToReplace";

            var apiUrl = TestContext.Parameters.Get("ApiUrl");
            apiUrl = (apiUrl == null) ? ConfigurationManager.AppSettings.Get("ApiUrl") : apiUrl;
            var apiPath = $"{projectLocation}SimpleApi";
            Api = new Api(apiUrl, apiPath);
        }
    }
}