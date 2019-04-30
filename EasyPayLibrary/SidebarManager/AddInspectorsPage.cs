namespace EasyPayLibrary
{
    public class AddInspectorsPage : BasePageObject
    {
        WebElementWrapper makar;
        WebElementWrapper oleg;
        WebElementWrapper ivan;
        WebElementWrapper allInspectorsAreBusy;
        WebElementWrapper btnAdd;
        WebElementWrapper btnClose;

        public override void Init(DriverWrapper driver)
        {
            btnAdd = driver.GetByXpath("//button[@data-locale-item='add']");

            base.Init(driver);
        }

        public void ClickOnMakarportnov()
        {
            makar = driver.GetByXpath("//option[@value='110']");
            makar.Click();
        }

        public void ClickOnOlegAdamov()
        {
            oleg = driver.GetByXpath("//option[@value='109']");
            oleg.Click();
        }

        public void ClickOnIvanIvanov()
        {
            ivan = driver.GetByXpath("//option[@value='113']");
            ivan.Click();
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
        public InspectorsListPage AddMakarPortnov()
        {
            ClickOnMakarportnov();
            ClickOnAddButton();
            return GetPOM<InspectorsListPage>(driver);
        }

        public InspectorsListPage AddOlegAdamov()
        {
            ClickOnOlegAdamov();
            ClickOnAddButton();
            return GetPOM<InspectorsListPage>(driver);
        }

        public InspectorsListPage AddIvanIvanov()
        {
            ClickOnIvanIvanov();
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