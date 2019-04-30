using EasyPayLibrary;
using NUnit.Framework;
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
        protected DriverWrapper driver;
        [SetUp]
        public void PreCondition()
        {
            driver = new DriverFactory().GetDriver();
            driver.Maximaze();
        }

        [TearDown]
        public void PostCondition()
        {
            driver.Quit();
        }
    }
}