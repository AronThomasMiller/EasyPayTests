using EasyPayLibrary;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPayTests
{
    public class UserTest
    {
        DriverWrapper driver;
        [SetUp]
        public void PreCondition()
        {
            driver = new DriverFactory().GetDriver();
            driver.Maximaze();
        }
        [Test]
        public void Test()
        {
        }

        [TearDown]
        public void PostCondition()
        {
            driver.Quit();
        }
    }
}
