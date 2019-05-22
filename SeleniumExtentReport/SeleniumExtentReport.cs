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
                var dir = AppDomain.CurrentDomain.BaseDirectory.Replace("\\bin\\Release", "");
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

                if (test.status == Status.Fail)
                {
                    string screenShotPath = driver.GetScreenshot(screenFolder);
                    AddTestHTML(test, screenShotPath);
                }
                else
                {
                    AddTestHTML(test);
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

        private void AddTestHTML(ContextOfTest test)
        {
            htmlTestReport.Log(test.status, "Test ended with " + test.status);
        }

        private void AddTestHTML(ContextOfTest test, string screenShotPath)
        {
            htmlTestReport.Log(test.status, "Test ended with " + test.status + " – " + test.errorMessage);
            AddScreenShotHTML(test.status, screenShotPath);
        }
    }
}