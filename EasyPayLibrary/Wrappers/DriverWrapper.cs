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
        public IWebDriver driver { get; set; }
        public DriverWrapper(IWebDriver Driver)
        {
            driver = Driver;
        }

        public List<WebElementWrapper> GetElementsByXpath(string xpath, int timeoutInSeconds = 5)
        {
            var elements = driver.FindElements(By.XPath(xpath));
            var result = elements.Select(x => new WebElementWrapper(x));
            return result.ToList();
        }

        public WebElementWrapper GetByXpath(string xpath, int timeoutInSeconds = 5)
        {
            if (timeoutInSeconds > 0)
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
#pragma warning disable CS0618 // Type or member is obsolete

                try
                {
                var result = new WebElementWrapper(wait.Until(condition: ExpectedConditions.ElementIsVisible(By.XPath(xpath))));
#pragma warning restore CS0618 // Type or member is obsolete
                return result;
                }
                catch (WebDriverTimeoutException)
                {
                    return null;
                }
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
        public Actions MoveToElement()
        {
            return new Actions(driver);
        }
        public void Switch()
        {
            driver.SwitchTo().Frame(driver.FindElement(By.XPath("/html/body/iframe")));
        }
        
        public void Maximaze()
        {
            driver.Manage().Window.Maximize();
        }
    }
}
