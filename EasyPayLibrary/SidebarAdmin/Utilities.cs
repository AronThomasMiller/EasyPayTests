namespace EasyPayLibrary
{
    //if you create class for page, name of class should tell about it, "Utilities" can be not only page
    public class Utilities : HomePageAdmin
    {
        WebElementWrapper btnChangeManager;
        WebElementWrapper btnConfirm;
        WebElementWrapper tableOfUtilities;
        WebElementWrapper keywordField;
        WebElementWrapper fieldManager;
        WebElementWrapper managerRadashko;

        public override void Init(DriverWrapper driver)
        {
            base.Init(driver);
            tableOfUtilities = driver.GetByXpath("//table/tbody[@id='utility_table']");
            btnChangeManager = driver.GetByXpath("//tbody[@id = 'utility_table']/tr[1]/td[text() = 'ДнепрОблЭнерго']/../td/button[2]");
            fieldManager = driver.GetByXpath("//tbody[@id = 'utility_table']/tr[1]/td[text() = 'ДнепрОблЭнерго']/../td[5]");
        }

        public void ClickOnChangeManager()
        {
            btnChangeManager.Click();
        }
        //use property instead one-line method
        public bool TableOfUtilitiesIsVisible()
        {
            return tableOfUtilities.IsDisplayed();
        }

        public void SetKeywordToTextBox()
        {
            keywordField = driver.GetByXpath("//input[@id='change_manager']");
            keywordField.SendText("UPDATE");
        }

        public void SelectManager(string nameManager)
        {
            managerRadashko = driver.GetByXpath($"//select[@id='update_managers']//option[contains(text(),'{nameManager}')]");
            managerRadashko.Click();
        }

        public void ClickOnConfirm()
        {
            btnConfirm = driver.GetByXpath("//button[@id='update_button']");
            btnConfirm.Click();
        }
        //Public members should start by UpperCase
        public string getTextFromManagerField()
        {
            return fieldManager.GetText();
        }
    }
}