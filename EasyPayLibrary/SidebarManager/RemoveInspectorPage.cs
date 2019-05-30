using EasyPayLibrary.Pages.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPayLibrary.ManagerSidebar
{
    public class RemoveInspectorPage : BasePageObject
    {
        WebElementWrapper btnRemove;

        public override void Init(DriverWrapper driver)
        {
            btnRemove = driver.GetByXpath("//button[@id='removeInspector']");
            base.Init(driver);
        }

        public void ClickOnRemoveButton()
        {
            btnRemove.Click();
        }

        public InspectorsListPage ConfirmRemoving()
        {
            ClickOnRemoveButton();
            return GetPOM<InspectorsListPage>(driver);
        }
    }
}
