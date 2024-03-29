﻿using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPayLibrary.Wrappers
{
    public class ActionsWrapper
    {
        public Actions action;

        public ActionsWrapper(DriverWrapper driver, WebElementWrapper element, int x, int y)
        {
            action = driver.MoveToElement();
            element.MoveToElement(action, x, y).Build().Perform();
        }
    }
}
