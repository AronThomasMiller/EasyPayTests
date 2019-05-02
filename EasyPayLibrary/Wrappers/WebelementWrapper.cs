using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
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

        internal SelectElement selectElement()
        {
            return new SelectElement(element);
        }

        public WebElementWrapper GetByXpath(string xpath)
        {
            return new WebElementWrapper(element.FindElement(By.XPath(xpath)));
        }

        public string GetAttribute(string attribute)
        {
            return element.GetAttribute(attribute);
        }
        public IWebElement GetElement()
        {
            return element;
        }

        public Actions MoveToElement(Actions actions, int x, int y)
        {
            return actions.MoveToElement(element, x, y);
        }

        public void sendBackSpace()
        {
            element.SendKeys(Keys.Backspace);
        }

        public void sendEnter()
        {
            element.SendKeys(Keys.Enter);
        }
    }
}
