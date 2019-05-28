using System;
using System.Text;

using AventStack.ExtentReports;
using System.IO;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using System.Threading;
using EasyPayLibrary;
using System.Xml.Serialization;
using System.Xml.Linq;
using System.Xml;
using NUnit.Framework.Internal;

namespace SeleniumExtentReportTest
{
    [TestFixture]
    public class SeleniumExtentReport
    {
        protected ExtentReports htmlTestSuitReport;
        protected ExtentTest htmlTestReport;
        protected string screenFolder;

        struct ContextOfTest
        {
            public Status status;
            public string stacktrace;
            public string errorMessage;
        }

        [OneTimeSetUp]
        public void BeforeClass()
        {
            try
            {
                var TestClassName = TestContext.CurrentContext.Test.ClassName;

                htmlTestSuitReport = new ExtentReports();

                string dir;
#if DEBUG
                dir = AppDomain.CurrentDomain.BaseDirectory.Replace("\\bin\\Debug", "");
#else
                dir = AppDomain.CurrentDomain.BaseDirectory.Replace("\\bin\\Release", "");
#endif
                DirectoryInfo di = Directory.CreateDirectory(dir + "\\Test_Execution_Reports");

                screenFolder = dir + "\\Test_Execution_Reports\\Screen";
                di = Directory.CreateDirectory(screenFolder);


                var outputDir = dir + "\\Test_Execution_Reports" + "\\" + TestClassName + "\\";

                var htmlReporter = new ExtentHtmlReporter(outputDir + "Automation_Report" + ".html");

                htmlTestSuitReport.AddSystemInfo("Who want to ATQC?", "");
                htmlTestSuitReport.AttachReporter(htmlReporter);
            }

            catch (Exception e)
            {
                throw (e);
            }
        }

        [SetUp]
        public void BeforeTest()
        {
            var currentTest = TestContext.CurrentContext.Test.Name;
            try
            {
                htmlTestReport = htmlTestSuitReport.CreateTest(currentTest);
            }
            catch (Exception e)
            {
                throw (e);
            }
        }

        [TearDown]
        public void AfterTest(DriverWrapper driver)
        {
            try
            {
                ContextOfTest test;
                test.status = GetStatus(TestContext.CurrentContext.Result.Outcome.Status);
                test.stacktrace = "" + TestContext.CurrentContext.Result.StackTrace + "";
                test.errorMessage = TestContext.CurrentContext.Result.Message;
                var output = TestExecutionContext.CurrentContext.CurrentResult.Output;
                MediaEntityModelProvider mediaModel = null;

                if (test.status == Status.Fail)
                {
                    string screenShotPath = driver.GetScreenshot(screenFolder);
                    AddTestHTML(test, screenShotPath, output, mediaModel);
                }
                else
                {
                    AddTestHTML(test, output, mediaModel);
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
                htmlTestSuitReport.Flush();
            }
            catch (Exception e)
            {
                throw (e);
            }
        }

        private Status GetStatus(TestStatus testStatus)
        {
            switch (testStatus)
            {
                case TestStatus.Failed:
                    return Status.Fail;
                case TestStatus.Skipped:
                    return Status.Skip;
                default:
                    return Status.Pass;
            }
        }

        private void AddScreenShotHTML(Status logstatus, string screenShotPath)
        {
            htmlTestReport.Log(logstatus, "Snapshot below: " + htmlTestReport.AddScreenCaptureFromPath(screenShotPath));
        }

        private void AddTestHTML(ContextOfTest test, string output, MediaEntityModelProvider mediaModel)
        {
            var isStackTraceNullOrEmpty = string.IsNullOrEmpty(test.stacktrace);
            var isErrorMessageNullOrEmpty = string.IsNullOrEmpty(test.errorMessage);

            htmlTestReport.Log(test.status,
          "Test ended with " + test.status +
          (!isStackTraceNullOrEmpty ? "\n<br>\n<br>" + test.stacktrace + "\n<br>\n<br>" : "\n<br>\n<br>")
          + (!isErrorMessageNullOrEmpty ? test.errorMessage + "\n<br>\n<br>" : string.Empty)
          + output, mediaModel);
        }

        private void AddTestHTML(ContextOfTest test, string screenShotPath, string output, MediaEntityModelProvider mediaModel)
        {
            var isStackTraceNullOrEmpty = string.IsNullOrEmpty(test.stacktrace);
            var isErrorMessageNullOrEmpty = string.IsNullOrEmpty(test.errorMessage);

            htmlTestReport.Log(test.status,
          "Test ended with " + test.status +
          (!isStackTraceNullOrEmpty ? "\n<br>\n<br>" + test.stacktrace + "\n<br>\n<br>" : "\n<br>\n<br>")
          + (!isErrorMessageNullOrEmpty ? test.errorMessage + "\n<br>\n<br>" : string.Empty)
          + output, mediaModel);
            AddScreenShotHTML(test.status, screenShotPath);
        }
    }
}