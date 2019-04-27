namespace EasyPayLibrary
{
    public class HomePage : GeneralPage
    {
        public static string GetRole(DriverWrapper driver)
        {
            return driver.GetByXpath("//div[@class='menu_section']//h3").GetText();
        }
    }
}