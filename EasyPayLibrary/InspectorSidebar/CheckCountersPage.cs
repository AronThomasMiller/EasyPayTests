using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPayLibrary.Pages.Inspector
{
    public class CheckCountersPage : HomePageInspector
    {
        public WebElementWrapper dropdown;
       
        public UtilityPage utility;     

        public override void Init(DriverWrapper driver)
        {
            dropdown = driver.GetByXpath("//span[@class='input-group-addon dropdown-toggle']");
                      
            base.Init(driver);
        }
        
        public void ClickOnDropDown()
        {
            dropdown.ClickOnIt();
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

        public void ForEach(IEnumerable<WebElementWrapper> addresses, string text)
        {
            foreach (var element in addresses)
            {
                if (element.GetText() == text)
                {
                    element.ClickOnIt();
                }                
            }            
        }

       

    }
}
