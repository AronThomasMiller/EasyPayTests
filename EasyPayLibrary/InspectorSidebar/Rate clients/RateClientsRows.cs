﻿using EasyPayLibrary.Wrappers;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPayLibrary.InspectorSidebar
{
    public class RateClientsRows : BasePageObject
    {
        string name;
        WebElementWrapper rate;     

        public RateClientsRows(WebElementWrapper element, DriverWrapper driver)
        {
            name = element.GetByXpath(".//td[1]").GetText();            
            rate = element.GetByXpath(".//td[3]");
            base.Init(driver);
        }

        public string GetName()
        {
            return name;
        }

        public WebElementWrapper Rate(int starNumber, bool andHalf = false)
        {            
            starNumber = starNumber * 12;
            starNumber += (andHalf) ? 6 : 0;
            var element = rate.GetByXpath(".//span");
            var clickOnStar = new Actions(driver.GetDriver());
            clickOnStar.MoveToElement(element.GetElement(), (starNumber), 5).Click().Build().Perform();
            var errorOrSuccess = driver.GetByXpath("//h4[@class='ui-pnotify-title']");
            return errorOrSuccess;
        }
    }
}