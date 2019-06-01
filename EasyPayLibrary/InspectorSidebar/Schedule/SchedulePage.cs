using EasyPayLibrary.HomePages;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPayLibrary.InspectorSidebar
{
    public class SchedulePage : HomePageInspector
    {
        //table, page, calendar
        public WebElementWrapper schedule;

        public override void Init(DriverWrapper driver)
        {
            schedule = driver.GetByXpath("//div[@class='fc-view-container']");
            base.Init(driver);
        }
        //use property instead one-line function
        public bool ScheduleIsDisplayed()
        {
            return schedule.IsDisplayed();
        }
        //call is element or what?, if it returns element so it should say about it
        public WebElementWrapper GetCallByAddress(string address)
        {
            try
            {
                return driver.GetByXpath($"//span[contains(text(),'{address}')]");
            }
            catch (WebDriverTimeoutException)
            {
                return null;
            }
        }
    }
}
