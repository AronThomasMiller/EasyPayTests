using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPayLibrary
{
    public class WebElementWrapper
    {
        IWebElement element;

        public void SendText(string text)
        {
            element.Clear();
            element.SendKeys(text);
        }

        public string GetCssValue(string name)
        {
            return element.GetCssValue(name);
        }

        public string GetText() => element.Text;

        public void Click()
        {
            element.Click();
        }

        public bool IsDisplayed()
        {
            bool result;
            try
            {
                result = element.Displayed;
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public WebElementWrapper(IWebElement web)
        {
            element = web;
        }

        public WebElementWrapper GetByXpath(string xpath)
        {
            return new WebElementWrapper(element.FindElement(By.XPath(xpath)));
        }
        //private By selector;
        //private string XPath;
        //public IWebElement WebElement { get; set; }
        //public WebElementWrapper(IWebElement element)
        //{
        //    WebElement = element;
        //}
        //public WebElementWrapper ByXpath(string xpath)
        //{
        //    selector = By.XPath(xpath);
        //    XPath = xpath;
        //    return this;
        //}

        public string GetAttribute(string attribute)
        {
            return element.GetAttribute(attribute);
        }
                public IWebElement GetElement()
        {
            return element;
        }

        public string GetCssValue(string css)
        {
            return element.GetCssValue(css);
        }
    }
}
