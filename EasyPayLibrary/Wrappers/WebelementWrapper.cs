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

        public string GetText() => element.Text;

        public void Click()
        {
            element.Click();
        }
        public void Enter()
        {
            element.SendKeys(Keys.Enter);
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
            return new WebElementWrapper(element).GetByXpath(xpath);
        }

        public SelectElement selectElement()
        {
            return new SelectElement(element);
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
