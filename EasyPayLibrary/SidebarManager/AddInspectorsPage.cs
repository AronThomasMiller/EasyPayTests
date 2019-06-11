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
        WebElementWrapper optionInspector;        
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
            optionInspector = driver.GetByXpath($"//option[contains(text(),'{name}')]");
            optionInspector.Click();
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

        public string GetCaption()
        {
            var caption = driver.GetByXpath("//h3[@id='busy']").GetText();
            return caption;
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
