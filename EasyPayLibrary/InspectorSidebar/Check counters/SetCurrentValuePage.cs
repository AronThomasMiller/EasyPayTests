using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPayLibrary.InspectorSidebar
{
    public class SetCurrentValuePage : BasePageObject
    {
        public WebElementWrapper fieldNewCurrentValue;
        public WebElementWrapper btnApply;

        public override void Init(DriverWrapper driver)
        {
            fieldNewCurrentValue = driver.GetByXpath("//input[@id='newCurrentValue']");
            btnApply = driver.GetByXpath("//div[@class='modal fade in']//button[2]");
            base.Init(driver);
        }

        public void FillNewCurrentValue(string text)
        {
            fieldNewCurrentValue.SendText(text);
        }

        public void ClickOnBtnApply()
        {
            btnApply.Click();
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
    }
}
