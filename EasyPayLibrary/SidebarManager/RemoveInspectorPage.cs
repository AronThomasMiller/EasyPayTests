namespace EasyPayLibrary
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