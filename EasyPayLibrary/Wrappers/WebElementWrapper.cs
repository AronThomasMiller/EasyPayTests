using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPayLibrary
{
    public class WebElementWrapper
    {
        public IWebElement element;

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
            return element.Displayed;
        }

        public WebElementWrapper(IWebElement web)
        {
            element = web;
        }

        public WebElementWrapper GetByXpath(string xpath)
        {
            throw new NotImplementedException();
        }


        public Actions MoveToElement(Actions actions, int x, int y)
        {
            return actions.MoveToElement(element, x, y);
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
