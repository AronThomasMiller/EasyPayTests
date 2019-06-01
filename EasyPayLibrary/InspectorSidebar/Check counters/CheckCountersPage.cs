using EasyPayLibrary.HomePages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPayLibrary.InspectorSidebar
{
    public class CheckCountersPage : HomePageInspector
    {
        //dropdown of what? first i thought it is dropdown of profile, write what contains in dropdown
        public WebElementWrapper dropdown;
        //public UtilityPage utility;

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

        public UtilityPage SelectAddress(string text)
        {
            ClickOnDropDown();
            var addresses = ReturnListOfDropDown();
            ForEach(addresses, text);
            return GetPOM<UtilityPage>(driver);
        }

        //ForEach means that it will be lookout of whole IEnumerable type object, but in this fuction you click on specific address by text, so describe it meaningfully
        public void ForEach(IEnumerable<WebElementWrapper> addresses, string text)
        {
            //forech construction can be more easily
            //var addressSelectedByText = addresses.First(element => element.GetText() == text);
            //addressSelectedByText.Click();
            foreach (var element in addresses)
            {
                if (element.GetText() == text)
                {
                    //if there will be two same addresses it will cause exception
                    //in this case you need to use "return;" after click, cause after click elements will become unclickable
                    //but this code will click one more time
                    element.Click();
                }
            }
        }
    }
}
