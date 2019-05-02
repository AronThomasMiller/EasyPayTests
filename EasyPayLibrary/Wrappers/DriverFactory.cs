using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
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
        public DriverWrapper GetDriver()
        {
            string browser = ConfigurationManager.AppSettings["browser"];
            IWebDriver driver = null;

            switch (browser)
            {
                case "Chrome":
                    driver = new ChromeDriver();
                    break;
                case "Firefox":
                    driver = new FirefoxDriver();
                    break;
            }
            return new DriverWrapper(driver);
        }
    }
}
