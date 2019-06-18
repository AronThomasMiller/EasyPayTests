namespace EasyPayLibrary
{
    public class UtilitiesPage  : HomePageAdmin
    {
        WebElementWrapper tableOfUtilities;    

        public override void Init(DriverWrapper driver)
        {
            base.Init(driver);
            tableOfUtilities = driver.GetByXpath("//table/tbody[@id='utility_table']");
        }

        public bool TableOfUtilitiesIsVisible()
        {
            return tableOfUtilities.IsDisplayed();
        }

        public TableOfUtilities ReturnUtilitiesTable()
        {
            return GetPOM<TableOfUtilities>(driver);
        }
    }
}