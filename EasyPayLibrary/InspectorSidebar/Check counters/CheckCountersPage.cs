using EasyPayLibrary.HomePages;
using EasyPayLibrary.InspectorSidebar.Check_counters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPayLibrary.InspectorSidebar
{
    public class CheckCountersPage : HomePageInspector
    {
        public WebElementWrapper dropdown;
        public UtilityPageRows utility;

        public override void Init(DriverWrapper driver)
        {
            dropdown = driver.GetByXpath("//span[@class='input-group-addon dropdown-toggle']");
            base.Init(driver);
        }

        public void ClickOnDropDown()
        {
            dropdown.Click();
        }

        public IEnumerable<WebElementWrapper> ReturnListOfDropDown()
        {
            var listOfDropdown = driver.GetElementsByXpath("//li[@data-value]");
            return listOfDropdown;
        }

        public UtilityPageTable SelectAddress(string text)
        {
            ClickOnDropDown();
            var addresses = ReturnListOfDropDown();
            ClickFromDropDown(addresses, text);
            return GetPOM<UtilityPageTable>(driver);
        }

        public void ClickFromDropDown(IEnumerable<WebElementWrapper> addresses, string text)
        {
            foreach (var element in addresses)
            {
                if (element.GetText() == text)
                {
                    element.Click();
                }
            }
        }
    }
}
