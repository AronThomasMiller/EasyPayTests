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
            base.Init(driver);
            btnRemove = driver.GetByXpath("//button[@id='removeInspector']");
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
