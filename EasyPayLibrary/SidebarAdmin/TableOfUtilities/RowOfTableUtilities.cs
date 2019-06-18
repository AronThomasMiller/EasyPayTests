using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPayLibrary
{
    public class RowOfTableUtilities:BasePageObject
    {
        WebElementWrapper companyName;
        WebElementWrapper address;
        WebElementWrapper idefCode;
        WebElementWrapper manager;
        WebElementWrapper btnChangeManager;

        public RowOfTableUtilities(WebElementWrapper element, DriverWrapper driver)
        {
            base.Init(driver);
            companyName = element.GetByXpath(".//td[2]");
            address = element.GetByXpath(".//td[3]");
            idefCode = element.GetByXpath(".//td[4]");
            manager = element.GetByXpath(".//td[5]");
            btnChangeManager = element.GetByXpath(".//td[7]//button[2]");
        }
        public RowOfTableUtilities()
        {

        }

        public string getNameCompany()
        {
            return companyName.GetText();
        }

        public string getAddress()
        {
            return address.GetText();
        }

        public string getIdefCode()
        {
            return idefCode.GetText();
        }

        public string getNameManager()
        {
            return manager.GetText();
        }

        public ChangeManagerPage ChangeManager()
        {
            btnChangeManager.Click();
            return GetPOM<ChangeManagerPage>(driver);
        }
    }
}
