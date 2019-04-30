using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPayLibrary.Admin
{
    class SideBarAdmin: BaseSidebar
    {
        protected WebElementWrapper utilities;
        public override void Init(DriverWrapper driver)
        {
            utilities = driver.GetByXpath("//a[@href='/admin/utilitiesPage']");
            base.Init(driver);
        }

        public UtilitiesPage GoToUtilities()
        {
            utilities.Click();
            return GetPOM<UtilitiesPage>(driver);
        }
 
    }
}
