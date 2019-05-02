﻿using EasyPayLibrary.User;
using EasyPayLibrary.Wrappers;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPayLibrary.Changes
{
    public class RateInspectorsPage : GeneralPage
    {
        public RateInspectorsForm rate;
        public override void Init(DriverWrapper driver)
        {
            rate = GetPOM<RateInspectorsForm>(driver);
            base.Init(driver);
        }
        public RateInspectorsPage ReturnRateInspectors()
        {
            return GetPOM<RateInspectorsPage>(driver);
        }
        public WebElementWrapper Rate(string name, float star)
        {
            WebElementWrapper element = driver.GetByXpath($"//td[contains(text(),'{name}')]/..//td[4]/span");
            Actions clickOnStar = new Actions(driver.GetDriver());
            clickOnStar.MoveToElement(element.GetElement(), (int)(6 * star), 5).Click().Build().Perform();
            var errorOrSuccess = driver.GetByXpath("//h4[@class='ui-pnotify-title']");
            return errorOrSuccess;
        }

    }
}