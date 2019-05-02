using EasyPayLibrary.ManagerSidebar;

namespace EasyPayLibrary.Pages.Manager
{
    public class InspectorsListPage : BasePageObject
    {
        WebElementWrapper panel;
        WebElementWrapper inspector;
        WebElementWrapper btnAddInspector;
        WebElementWrapper olegAdamov;
        WebElementWrapper btnRemoveInspector;

        public override void Init(DriverWrapper driver)
        {
            olegAdamov = driver.GetByXpath("//a[contains(text(),'Oleg Adamov')]");
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

        public SchedulePage ClickOnInspectorOlegAdamov()
        {
            olegAdamov.Click();
            return GetPOM<SchedulePage>(driver);
        }

        public string VerifyListOfInspectorsNotEmpty()
        {
            panel = driver.GetByXpath("//div[@class='x_content']");
            return panel.ToString();
        }
    }
}