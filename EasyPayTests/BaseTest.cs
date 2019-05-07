using EasyPayLibrary;
using EasyPayLibrary.Translations;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EasyPayTests
{
    public class BaseTest
    {
        public TranslationValues t;
        public DriverWrapper driver;

        [SetUp]
        public void PreCondition()
        {
            t  = TranslationProvider.GetTranslation("ua");
            driver = new DriverFactory().GetDriver();
            driver.Maximaze();
            driver.GoToURL();
        }

        [TearDown]
        public void PostCondition()
        {
            if (TestContext.CurrentContext.Result.Outcome != ResultState.Success)
            {
                driver.getScreenshot();
            }

            driver.Quit();
        }
    }
}