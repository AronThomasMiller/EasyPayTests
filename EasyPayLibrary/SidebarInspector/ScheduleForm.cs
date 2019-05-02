using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPayLibrary.Inspector
{
    public class ScheduleForm: BasePageObject
    {
        WebElementWrapper textInfo;
        public override void Init(DriverWrapper driver)
        {
            base.Init(driver);

        }

        public string GetInformation()
        {
            textInfo = driver.GetByXpath("//td[contains(@class,'fc-day fc-widget-content fc-mon fc-today')]");
            return textInfo.GetText();
        }

        public WebElementWrapper GetCallByAddress(string address)
        {
            return driver.GetByXpath($"//span[contains(text(),'{address}')]");
        }
    }
}
