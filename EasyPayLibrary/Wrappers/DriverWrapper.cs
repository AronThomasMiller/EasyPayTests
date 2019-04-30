using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPayLibrary
{
    public class DriverWrapper 
    {
        IWebDriver driver { get; set; }
        public DriverWrapper(IWebDriver Driver)
        {
            driver = Driver;
        }

        public string getUrl() { return driver.Url; }

        public List<WebElementWrapper> GetElementsByXpath(string xpath, int timeoutInSeconds = 5)
        {
            GetByXpath(xpath);
            var elements = driver.FindElements(By.XPath(xpath));
            var result = elements.Select(x => new WebElementWrapper(x));
            return result.ToList();
        }

        public WebElementWrapper GetByXpath(string xpath, int timeoutInSeconds = 5)
        {
            if (timeoutInSeconds > 0)
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                var result = new WebElementWrapper(wait.Until(condition: ExpectedConditions.ElementIsVisible(By.XPath(xpath))));
                return result;
            }
            else
            {
                var result = new WebElementWrapper(driver.FindElement(By.XPath(xpath)));
                return result;
            }
        }
        
        public void GoToURL()
        {
            string url = ConfigurationManager.AppSettings["URL"];
            driver.Url = url;            
        }

        public void GoToURL(string url)
        {
            driver.Navigate().GoToUrl(url);
        }

        public void Refresh()
        {
            driver.Navigate().Refresh();
        }

        public void Quit()
        {
            if (driver == null) return;
            driver.Quit();
            driver = null;
        }
        
        public void Maximaze()
        {
            driver.Manage().Window.Maximize();
        }

        public void ChangeFrame(string name)
        {
            driver.SwitchTo().Frame(name);
        }


        public void WaitUntillUrlContainString(string str, int timeInSec = 20)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeInSec));
#pragma warning disable CS0618 // Type or member is obsolete
            wait.Until(condition: ExpectedConditions.UrlContains(str));
#pragma warning restore CS0618 // Type or member is obsolete
        }
        

        public void SwitchToWindow()
        {
            driver.SwitchTo().Window(driver.WindowHandles.Last());
        }

        public Actions MoveToElement()
        {
            return new Actions(driver);
        }
    }
}
