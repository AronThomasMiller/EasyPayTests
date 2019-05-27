using EasyPayLibrary;
using EasyPayLibrary.Translations;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using SeleniumExtentReportTest;
using System;

namespace EasyPayTests
{
    public class BaseTest
    {
        string browser;
        protected TranslationValues t;
        protected DriverWrapper driver;
        protected WelcomePage welcome;
        protected SeleniumExtentReport report;

        [OneTimeSetUp]
        public void BeforeClass()
        {
            report = new SeleniumExtentReport();
            report.BeforeClass();
        }

        [SetUp]
        public virtual void PreCondition()
        {
            report.BeforeTest();
            t = TranslationProvider.GetTranslation("ua");
            browser = TestContext.Parameters.Get("browser");
            driver = new DriverFactory().GetDriver(browser);

            driver.Maximaze();
            driver.GoToURL();
            welcome = new WelcomePage();
            welcome.Init(driver);
        }

        [TearDown]
        public virtual void PostCondition()
        {
            report.AfterTest(driver);
            driver.Quit();
        }

        [OneTimeTearDown]
        public void AfterClass()
        {
            report.AfterClass();
        }

        public void LogProgress(string message)
        {
            TestContext.Out.WriteLine("\n<br>" + message);
        }
    }
}