using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPayLibrary.Pages
{
    public class ActionsWrapper
    {
        public Actions action;
        public ActionsWrapper(DriverWrapper driver, WebElementWrapper element, int x, int y)
        {
            action = driver.MoveToElement();
            action = element.MoveToElement(action, x, y);
        }
    }
}