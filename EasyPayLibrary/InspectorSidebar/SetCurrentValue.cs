using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPayLibrary.Pages.Inspector
{
   public  class SetCurrentValue : UtilityPage
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
            btnApply.ClickOnIt();
        }
   }
}
