using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPayLibrary.ManagerSidebar
{
    public class DeleteScheduleItemPage : BasePageObject
    {
        WebElementWrapper btnApply;

        public override void Init(DriverWrapper driver)
        {
            btnApply = driver.GetByXpath("//button[@class='btn btn-primary js-remove-apply']");
            base.Init(driver);
        }

        public void ClickOnApplyButton()
        {
            btnApply.Click();
        }

        public SchedulePage ApplyToDelete()
        {
            ClickOnApplyButton();
            return GetPOM<SchedulePage>(driver);
        }
    }
}
