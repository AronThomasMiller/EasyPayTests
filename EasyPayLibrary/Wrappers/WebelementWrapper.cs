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
            return new WebElementWrapper(element.FindElement(By.XPath(xpath)));
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
