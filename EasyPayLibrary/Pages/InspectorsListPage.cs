namespace EasyPayLibrary
{
    public class InspectorsListPage : BasePageObject
    {
        WebElementWrapper olegAdamov;

        public override void Init(DriverWrapper driver)
        {
            olegAdamov = driver.GetByXpath("//a[contains(text(),'Oleg Adamov')]");
            base.Init(driver);
        }

        public SchedulePage ClickOnInspectorOlegAdamov()
        {
            olegAdamov.ClickOnIt();
            return GetPOM<SchedulePage>(driver);
        }
    }
}