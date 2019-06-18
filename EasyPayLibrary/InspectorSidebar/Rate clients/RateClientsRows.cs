using EasyPayLibrary.Wrappers;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPayLibrary.InspectorSidebar
{
    //It is class which describe only one row
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

        //use property instead one-line function
        public string GetName()
        {
            return name;
        }

        public void Rate(int starNumber, bool andHalf = false)
        {            
            starNumber = starNumber * 12;
            starNumber += (andHalf) ? 6 : 0;
            var element = rate.GetByXpath("./span");
            var clickOnStar = new Actions(driver.GetDriver);
            clickOnStar.MoveToElement(element.GetElement(), (starNumber), 5).Click().Build().Perform();           
        }

        public bool IsRated(int starNumber, bool andHalf = false)
        {
            Rate(starNumber, andHalf);
            var messageBox = driver.GetByXpath("//h4[@class='ui-pnotify-title']");
            var textOfMessageBox = messageBox.GetText();
            if (textOfMessageBox == "Success")
                return true;
            else
                return false;
        }
    }
}
