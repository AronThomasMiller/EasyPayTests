using EasyPayLibrary.ManagerSidebar;

namespace EasyPayLibrary.Pages.Manager
{
    public class InspectorsListPage : BasePageObject
    {
        //type of element
        WebElementWrapper panel;
        //create pom for table
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

        public void ClickToRemoveInspector(string name)
        {
            btnRemoveInspector = driver.GetByXpath($"//a[contains(text(),'{name}')]/../..//td[2]/button");
            btnRemoveInspector.Click();
        }

        public void ClickOnAddInspectorsButton()
        {
            btnAddInspector = driver.GetByXpath("//button[@onclick='getFreeInspectors()']");
            btnAddInspector.Click();
        }
        public SchedulePage NavigateToInspectorsSchedule(string name)
        {
            ClickOnInspector(name);
            return GetPOM<SchedulePage>(driver);
        }

        public RemoveInspectorPage RemoveInspector(string name)
        {
            ClickToRemoveInspector(name);
            return GetPOM<RemoveInspectorPage>(driver);
        }


        public AddInspectorsPage ClickToAddInspector()
        {
            ClickOnAddInspectorsButton();
            return GetPOM<AddInspectorsPage>(driver);
        }
        
        public string VerifyListOfInspectorsIsNotEmpty()
        {
            panel = driver.GetByXpath("//div[@id='tab-inspectors']//td[1]");
            return panel.ToString();
        }
    }
}