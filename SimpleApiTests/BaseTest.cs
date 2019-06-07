using HttpLibrary;
using System;
using System.IO;

namespace SimpleApiTests
{
    public class BaseTest
    {
        protected string ApiDataPlace;
        protected string TestsuitDataPlace;
        protected string TestName;
        protected ClientWrapper client;
        protected RequestWrapper request;
        
        public virtual void SetUp()
        {
            string projectLocation;
#if DEBUG
            projectLocation = AppDomain.CurrentDomain.BaseDirectory.Replace("\\bin\\Debug", "");
#else
                projectLocation = AppDomain.CurrentDomain.BaseDirectory.Replace("\\bin\\Release", "");
#endif
            ApiDataPlace = $@"{projectLocation}\SimpleAPi\Data\";
            TestsuitDataPlace = $@"{projectLocation}TestData\";
            DirectoryInfo di = Directory.CreateDirectory(TestsuitDataPlace);
            client = ClientFactory.GetClient();
        }
    }
}