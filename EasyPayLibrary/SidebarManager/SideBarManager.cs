using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPayLibrary.Manager
{
    class SideBarManager: BaseSidebar
    {
        protected WebElementWrapper manage;
        public override void Init(DriverWrapper driver)
        {
            manage = driver.GetByXpath("//a[@href='/manager/schedule/']");
            base.Init(driver);
        }
        public InspectorsPage GoToInspectors()
        {
            manage.Click();
            return GetPOM<InspectorsPage>(driver);
        }

    }
}
