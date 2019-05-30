using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPayLibrary
{
    public class DriverFactory
    {
        public DriverWrapper GetDriver(string browser)
        {
            return (browser == null) ? ChooseDriver(ConfigurationManager.AppSettings["browser"]) : ChooseDriver(browser);
        }

        private DriverWrapper ChooseDriver(string browser)
        {
            IWebDriver driver = null;
            switch (browser)
            {
                case "Chrome":
                    driver = new ChromeDriver();
                    break;
                case "Firefox":
                    driver = new FirefoxDriver();
                    break;
                case "Edge":
                    driver = new EdgeDriver();
                    break;

            }
            return new DriverWrapper(driver);
        }
    }
}
