using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPayLibrary.InspectorSidebar
{
    //inheritance means that object is explicit from base class or has another implementation of methods
    //not that step of pages
    public class UtilityPage : CheckCountersPage
    {
        //what type of elements it is? prefix!
        public WebElementWrapper activateOrDeactivate;
        public WebElementWrapper fixedOrUnfixed;
        public WebElementWrapper setNewValue;

        public override void Init(DriverWrapper driver)
        {
            activateOrDeactivate = driver.GetByXpath("//td/button[1]");
            fixedOrUnfixed = driver.GetByXpath("//td/button[2]");
            setNewValue = driver.GetByXpath("//td/button[4]");
            base.Init(driver);
        }
        //what action? single resposibility - one method = one job
        public WebElementWrapper DoSomeAction(string button, CheckCountersPage checkCounters)
        {
            if (button == "Activate")
            {
                activateOrDeactivate.Click();
            }
            else
            {
                if (button == "Fix") fixedOrUnfixed.Click();
            }
            return ErrorOrSuccess();
        }
        //what with old one?)
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
        //Change
        public SetCurrentValue ClickOnSetNewValue(string address)
        {
            //idk what it do
            //you need to make pre-condition using sql
            //and then use specific button instead using something
            //what will pass in any case
            if (fixedOrUnfixed.GetText() == "Set fixed" && activateOrDeactivate.GetText() == "Deactivate")
            {
                setNewValue.Click();
                return GetPOM<SetCurrentValue>(driver);
            }

            if (fixedOrUnfixed.GetText() == "Set unfixed" && activateOrDeactivate.GetText() == "Activate")
            {
                fixedOrUnfixed.Click();
                activateOrDeactivate.Click();
                driver.Refresh();
                SelectNewAddress(address);
                var setNewValue2 = driver.GetByXpath("//td/button[4]");
                setNewValue2.Click();
                return GetPOM<SetCurrentValue>(driver);
            }

            if (fixedOrUnfixed.GetText() == "Set fixed" && activateOrDeactivate.GetText() == "Activate")
            {
                activateOrDeactivate.Click();
                driver.Refresh();
                SelectNewAddress(address);
                var setNewValue2 = driver.GetByXpath("//td/button[4]");
                setNewValue2.Click();
                return GetPOM<SetCurrentValue>(driver);
            }

            if (fixedOrUnfixed.GetText() == "Set unfixed" && activateOrDeactivate.GetText() == "Deactivate")
            {
                fixedOrUnfixed.Click();
                driver.Refresh();
                SelectNewAddress(address);
                var setNewValue2 = driver.GetByXpath("//td/button[4]");
                setNewValue2.Click();
                return GetPOM<SetCurrentValue>(driver);
            }

            else return null;
        }
        //name doesn't say anything
        public WebElementWrapper ErrorOrSuccess()
        {
            var errorOrSuccess = driver.GetByXpath("//h4[@class='ui-pnotify-title']");
            return errorOrSuccess;
        }
    }
}
