using OpenQA.Selenium;
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

        public void ClickOnIt()
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
            throw new NotImplementedException();
        }

        public string GetAttribute(string attribute)
        {
            return element.GetAttribute(attribute);
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

    }
}
