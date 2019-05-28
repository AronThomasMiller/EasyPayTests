using OpenQA.Selenium;
using System.Collections.Generic;

namespace EasyPayLibrary
{
    public abstract class SidebarBase : BasePageObject
    {
        public static string GetRole(DriverWrapper driver)
        {
            try
            {
                return driver.GetByXpath("//div[@class='menu_section']//h3", 2).GetText();
            }
            catch (WebDriverTimeoutException)
            {
                return null;
            }
        }

        public IEnumerable<WebElementWrapper> GetListOfSideBarComponents()
        {
            return driver.GetElementsByXpath("//ul[@class='nav side-menu']/li/a//span");
        }
    }
}