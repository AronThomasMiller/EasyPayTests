using NUnit.Framework;
using System.Threading;

namespace EasyPayLibrary.Pages.Inspector
{
    public class UtilityPage : CheckCountersPage
    {
       
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

        public WebElementWrapper DoSomeAction(string button, CheckCountersPage checkCounters)
        {           
           if (button == "Activate")
           {
                activateOrDeactivate.ClickOnIt();
           }
           else
           {
                if (button == "Fix") fixedOrUnfixed.ClickOnIt();
           }
           return ErrorOrSuccess(); 
        }

        public void SelectNewAddress(string text)
        {
            var checkCounters = driver.GetByXpath("//span[@class='input-group-addon dropdown-toggle']");
            checkCounters.ClickOnIt();
            var addresses  = driver.GetElementsByXpath("//li[@data-value]");
            foreach (var element in addresses)
            {
                if (element.GetText() == text)
                {
                    element.ClickOnIt();
                }
            }

        }

        public SetCurrentValue ClickOnSetNewValue(string address)
        {
            if (fixedOrUnfixed.GetText() == "Set fixed" && activateOrDeactivate.GetText() == "Deactivate")
            {
                setNewValue.ClickOnIt();
                return GetPOM<SetCurrentValue>(driver);
            }

            if (fixedOrUnfixed.GetText() == "Set unfixed" && activateOrDeactivate.GetText() == "Activate")
            {
                fixedOrUnfixed.ClickOnIt();
                activateOrDeactivate.ClickOnIt();
                driver.Refresh();                
                SelectNewAddress(address);
                Thread.Sleep(1000);
                var setNewValue2 = driver.GetByXpath("//td/button[4]");
                setNewValue2.ClickOnIt();                
                return GetPOM<SetCurrentValue>(driver);
            }

            if (fixedOrUnfixed.GetText() == "Set fixed" && activateOrDeactivate.GetText() == "Activate")
            {
                activateOrDeactivate.ClickOnIt();
                driver.Refresh();
                SelectNewAddress(address);
                var setNewValue2 = driver.GetByXpath("//td/button[4]");
                setNewValue2.ClickOnIt();
                return GetPOM<SetCurrentValue>(driver);
            }
        
            if (fixedOrUnfixed.GetText() == "Set unfixed" && activateOrDeactivate.GetText() == "Deactivate")
            {
                fixedOrUnfixed.ClickOnIt();
                driver.Refresh();
                SelectNewAddress(address);
                var setNewValue2 = driver.GetByXpath("//td/button[4]");
                setNewValue2.ClickOnIt();
                return GetPOM<SetCurrentValue>(driver);
            }

            else return null;
        }

        public WebElementWrapper ErrorOrSuccess()
        {
            var errorOrSuccess = driver.GetByXpath("//h4[@class='ui-pnotify-title']");
            return errorOrSuccess;
        }
    }
}