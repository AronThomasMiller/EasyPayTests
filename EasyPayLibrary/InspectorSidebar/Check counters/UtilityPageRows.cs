using DatabaseManipulation;
using EasyPayLibrary.InspectorSidebar.Check_counters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPayLibrary.InspectorSidebar
{
    public class UtilityPageRows : CheckCountersPage
    {
        public WebElementWrapper btnActivate;
        public WebElementWrapper btnDeactivate;
        public WebElementWrapper btnFixed;
        public WebElementWrapper btnUnfixed;
        public WebElementWrapper btnSetNewValue;
        public WebElementWrapper columnActivate;
        public WebElementWrapper columnFixed;
        

        public UtilityPageRows (WebElementWrapper element, DriverWrapper driver)
        {
            btnActivate = element.GetByXpath("./td/button[1]");
            btnDeactivate = element.GetByXpath("./td/button[1]");
            btnFixed = element.GetByXpath("./td/button[2]");
            btnUnfixed = element.GetByXpath("./td/button[2]");
            btnSetNewValue = element.GetByXpath("./td/button[4]");
            columnActivate = element.GetByXpath("./td[@class ='is-active'][@data-value]");
            columnFixed = element.GetByXpath("./td[@class ='is-fixed'][@data-value]");
            base.Init(driver);
        }

        public bool isSuccsess()
        {
            var messageBox = driver.GetByXpath("//h4[@class='ui-pnotify-title']");
            var textOfMessageBox = messageBox.GetText();
            if (textOfMessageBox == "Success")
                return true;
            else
                return false;
        }

        public void ActivateUtility()
        {
            btnActivate.Click();
        }

        public void DeactivateUtility()
        {
            btnDeactivate.Click();
        }

        public void FixedUtility()
        {
            btnFixed.Click();
        }

        public void UnfixedUtility()
        {
            btnUnfixed.Click();
        }

        public void SetNewValueUtility()
        {
            btnSetNewValue.Click();
        }

        public bool IsActivate()
        {
            ActivateUtility();
            var success = isSuccsess();
            return success;
        }

        public bool IsDeactivate()
        {
            DeactivateUtility();
            var success = isSuccsess();
            return success;
        }

        public bool IsFixed()
        {
            FixedUtility();
            var success = isSuccsess();
            return success;
        }

        public bool IsUnfixed()
        {
            UnfixedUtility();
            var success = isSuccsess();
            return success;
        }

        public SetCurrentValuePage SetNewValueUtility(string address)
        {
            btnSetNewValue.Click();
            return GetPOM<SetCurrentValuePage>(driver);
        }

        public void SelectNewAddress(string text)
        {
            var checkCounters = driver.GetByXpath("//span[@class='input-group-addon dropdown-toggle']");
            checkCounters.Click();
            var addresses = driver.GetElementsByXpath("//li[@data-value]");
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
