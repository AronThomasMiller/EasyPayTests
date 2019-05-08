using EasyPayLibrary;
using EasyPayLibrary.Translations;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using System;

namespace EasyPayTests
{
    public class BaseTest
    {
        string browser;
        protected TranslationValues t;
        protected DriverWrapper driver;
        protected WelcomePage welcome;

        [SetUp]
        public virtual void PreCondition()
        {
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
            if ((TestContext.CurrentContext.Result.Outcome == ResultState.Failure) || (TestContext.CurrentContext.Result.Outcome == ResultState.Error))
            {
                driver.getScreenshot();
            }

            driver.Quit();
        }
    }
}