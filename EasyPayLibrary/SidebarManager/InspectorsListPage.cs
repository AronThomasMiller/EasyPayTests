using EasyPayLibrary.ManagerSidebar;

namespace EasyPayLibrary.Pages.Manager
{
    public class InspectorsListPage : BasePageObject
    {
        //type of element
        WebElementWrapper panel;
        //create pom for table
        WebElementWrapper optionInspector;
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
            optionInspector = GetInspector(name);
            optionInspector.Click();
        }

        public void ClickToRemoveInspector(string name)
        {
            btnRemoveInspector = driver.GetByXpath($"//a[contains(text(),'{name}')]/../..//td[2]/button");
            btnRemoveInspector.Click();
        }

        public void ClickOnAddInspectorButton()
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
            ClickOnAddInspectorButton();
            return GetPOM<AddInspectorsPage>(driver);
        }

        public string VerifyListOfInspectorsIsNotEmpty()
        {
            panel = driver.GetByXpath("//div[@class='x_content']");
            //for what in string
            //if you look like this it will return something but not result which depends on table with inpectors
            return panel.ToString();
        }
    }
}