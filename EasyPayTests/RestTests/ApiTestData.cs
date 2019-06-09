using HttpLibrary;
using NUnit.Framework;
using System;
using System.IO;

namespace SimpleApiTests
{
    public static class ApiTestData
    {
        public static Api Api { get; }
        public static readonly string AllTestSuitesDataPlace;

        static ApiTestData()
        {
            string projectLocation;
#if DEBUG
            projectLocation = AppDomain.CurrentDomain.BaseDirectory.Replace("\\bin\\Debug", "");
#else
                projectLocation = AppDomain.CurrentDomain.BaseDirectory.Replace("\\bin\\Release", "");
#endif
            AllTestSuitesDataPlace = $"{projectLocation}\\TestData\\";

            var apiUrl = TestContext.Parameters.Get("ApiUrl");
            var apiPath = $"{projectLocation}\\SimpleApi\\";
            Api = new Api(apiUrl, apiPath);
        }
    }
}