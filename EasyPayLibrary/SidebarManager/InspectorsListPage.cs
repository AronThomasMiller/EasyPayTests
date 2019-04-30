using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPayLibrary
{
    public class InspectorsListPage : BasePageObject
    {
        WebElementWrapper inspector;
        WebElementWrapper btnAddInspector;
        
        WebElementWrapper btnRemoveInspector;

        public override void Init(DriverWrapper driver)
        {
            base.Init(driver);
        }

        public WebElementWrapper GetInspector(string name)
        {
            return driver.GetByXpath($"//a[contains(text(),'{name}')]");
        }

        
        public void ClickOnInspector(string name)
        {
            inspector = GetInspector(name);
            inspector.Click();

        }        

        public void ClickToDeleteInspector(string name)
        {
            btnRemoveInspector = driver.GetByXpath($"//a[contains(text(),'{name}')]/../..//td[2]/button");
            btnRemoveInspector.Click();
        }

        
        public void ClickOnAddInspectorsButton()
        {
            btnAddInspector = driver.GetByXpath("//button[@onclick='getFreeInspectors()']");
            btnAddInspector.Click();
        }
        public SchedulePage ChooseInspector(string name)
        {
            ClickOnInspector(name);
            return GetPOM<SchedulePage>(driver);
        }        

        public RemoveInspectorPage RemoveInspector(string name)
        {
            ClickToDeleteInspector(name);
            return GetPOM<RemoveInspectorPage>(driver);
        }
       

        public AddInspectorsPage ClickToAddInspector()
        {
            ClickOnAddInspectorsButton();
            return GetPOM<AddInspectorsPage>(driver);
        }
    }
}
