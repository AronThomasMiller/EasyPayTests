using System;
using System.Text;

using AventStack.ExtentReports;
using System.IO;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using System.Threading;
using EasyPayLibrary;

namespace SeleniumExtentReportTest
{
    [TestFixture]
    public class SeleniumExtentReport
    {
        protected ExtentReports _extent;
        protected ExtentTest _test;
        DriverWrapper driver;

        struct ContextOfTest
        {
            public TestStatus status;
            public string stacktrace;
            public string errorMessage;
        }

        [OneTimeSetUp]
        public void BeforeClass()
        {
            try
            {
                //To create report directory and add HTML report into it
                var TestClassName = TestContext.CurrentContext.Test.ClassName;
                _extent = new ExtentReports();
                var dir = AppDomain.CurrentDomain.BaseDirectory.Replace("\\bin\\Debug", "");
                DirectoryInfo di = Directory.CreateDirectory(dir + "\\Test_Execution_Reports");
                var htmlReporter = new ExtentHtmlReporter(dir + "\\Test_Execution_Reports" + "\\" + TestClassName + "\\Automation_Report" + ".html");

                _extent.AddSystemInfo("Environment", "EasyPay");
                _extent.AddSystemInfo("User Name", "");
                _extent.AttachReporter(htmlReporter);
            }
            catch (Exception e)
            {
                throw (e);
            }
        }

        [SetUp]
        public void BeforeTest()
        {
            try
            {
                _test = _extent.CreateTest(TestContext.CurrentContext.Test.Name);
            }
            catch (Exception e)
            {
                throw (e);
            }
        }

        [TearDown]
        public void AfterTest()
        {
            try
            {
                ContextOfTest test;
                test.status = TestContext.CurrentContext.Result.Outcome.Status;
                test.stacktrace = "" +TestContext.CurrentContext.Result.StackTrace + "";
                test.errorMessage = TestContext.CurrentContext.Result.Message;
                Status logstatus;
                switch (test.status)
                {
                    case TestStatus.Failed:
                        logstatus = Status.Fail;
                        AddTestHTML(logstatus, test);
                        AddScreenShotHTML(logstatus);
                        break;
                    case TestStatus.Skipped:
                        logstatus = Status.Skip;
                        AddTestHTML(logstatus, test);
                        break;
                    default:
                        logstatus = Status.Pass;
                        AddTestHTML(logstatus, test);
                        break;
                }
            }
            catch (Exception e)
            {
                throw (e);
            }
        }

        [OneTimeTearDown]
        public void AfterClass()
        {
            try
            {
                _extent.Flush();
            }
            catch (Exception e)
            {
                throw (e);
            }
        }

        private void AddTestHTML(Status logstatus, ContextOfTest test)
        {
            var log = "Test ended with " + logstatus;
            if (test.errorMessage != null && test.errorMessage != "")
                log += " – " + test.errorMessage;

            _test.Log(logstatus, log);
        }

        private void AddScreenShotHTML(Status logstatus)
        {
            string screenShotPath = driver.GetScreenshot();
            _test.Log(logstatus, "Snapshot below: " + _test.AddScreenCaptureFromPath(screenShotPath));
        }
    }
}