using EasyPayLibrary.Pages.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPayLibrary.ManagerSidebar
{
    public class AddInspectorsPage : BasePageObject
    {
        //what variable inspector means? what type it is?
        WebElementWrapper inspector;
        //what it is "allInspectorsAreBusy"?
        WebElementWrapper allInspectorsAreBusy;
        WebElementWrapper btnAdd;
        WebElementWrapper btnClose;

        public override void Init(DriverWrapper driver)
        {
            base.Init(driver);
            btnAdd = driver.GetByXpath("//button[@data-locale-item='add']");
        }
        //by POM you should make list of inspectors as separate class, and list of inspectors which are able to add too
        public void ClickOnInspector(string name)
        {
            inspector = driver.GetByXpath($"//option[contains(text(),'{name}')]");
            inspector.Click();
        }

        public void ClickOnAddButton()
        {
            btnAdd.Click();
        }

        public void ClickOnCloseButton()
        {
            btnClose = driver.GetByXpath("//div[@id='add-inspector-modal']//button[@class='btn btn-default']");
            btnClose.Click();
        }

        public WebElementWrapper GetCaption()
        {
            allInspectorsAreBusy = driver.GetByXpath("//h3[@id='busy']");
            return allInspectorsAreBusy;
        }
        
        public InspectorsListPage AddInspector(string name)
        {
            //Should be method SelectInspectorByName, it have to use POMListOfInspectors
            ClickOnInspector(name);
            ClickOnAddButton();
            return GetPOM<InspectorsListPage>(driver);
        }

        public InspectorsListPage CloseWindow()
        {
            ClickOnCloseButton();
            return GetPOM<InspectorsListPage>(driver);
        }
    }
}
