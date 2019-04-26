namespace EasyPayLibrary
{
    public class Utilities:HomePageAdmin
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
    }
}