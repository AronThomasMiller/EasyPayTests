namespace EasyPayLibrary
{
    public class AddInspectorsPage : BasePageObject
    {
        WebElementWrapper inspector;
        
        WebElementWrapper allInspectorsAreBusy;
        WebElementWrapper btnAdd;
        WebElementWrapper btnClose;

        public override void Init(DriverWrapper driver)
        {
            btnAdd = driver.GetByXpath("//button[@data-locale-item='add']");

            base.Init(driver);
        }

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