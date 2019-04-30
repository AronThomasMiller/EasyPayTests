using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPayLibrary
{
    public class InspectorsListPage : BasePageObject
    {
        WebElementWrapper makar;
        WebElementWrapper oleg;
        WebElementWrapper ivan;
        WebElementWrapper btnAddInspector;
        WebElementWrapper btnRemoveMakar;
        WebElementWrapper btnRemoveOleg;
        WebElementWrapper btnRemoveIvan;

        public override void Init(DriverWrapper driver)
        {
            base.Init(driver);
        }

        public WebElementWrapper GetMakarPortnov()
        {
            return driver.GetByXpath("//a[@href='/manager/schedule/inspector/110/']");
        }

        public WebElementWrapper GetOlegAdamov()
        {
            return driver.GetByXpath("//a[@href='/manager/schedule/inspector/109/']");
        }

        public WebElementWrapper GetIvanIvanov()
        {
            return driver.GetByXpath("//a[@href='/manager/schedule/inspector/113/']");
        }

        public void ClickOnMakarPortnov()
        {
            makar = GetMakarPortnov();
            makar.Click();

        }
        public void ClickOnOlegAdamov()
        {
            oleg = GetOlegAdamov();
            oleg.Click();
        }

        public void ClickOnIvanIvanov()
        {
            ivan = GetIvanIvanov();
            ivan.Click();
        }

        public void ClickToDeleteMakarPortnov()
        {
            btnRemoveMakar = driver.GetByXpath("//tr[1]//td[2]//button[1]");
            btnRemoveMakar.Click();
        }

        public void ClickToDeleteOlegAdamov()
        {
            btnRemoveOleg = driver.GetByXpath("//tr[2]//td[2]//button[1]");
            btnRemoveOleg.Click();
        }

        public void ClickToDeleteIvanIvanov()
        {
            btnRemoveIvan = driver.GetByXpath("//tr[3]//td[2]//button[1]");
            btnRemoveIvan.Click();
        }

        public void ClickOnAddInspectorsButton()
        {
            btnAddInspector = driver.GetByXpath("//button[@onclick='getFreeInspectors()']");
            btnAddInspector.Click();
        }
        public SchedulePage ChooseMakarPortnov()
        {
            ClickOnMakarPortnov();
            return GetPOM<SchedulePage>(driver);
        }

        public SchedulePage ChooseOlegAdamov()
        {
            ClickOnOlegAdamov();
            return GetPOM<SchedulePage>(driver);
        }

        public SchedulePage ChooseIvanIvanov()
        {
            ClickOnIvanIvanov();
            return GetPOM<SchedulePage>(driver);
        }

        public RemoveInspectorPage RemoveMakarPortnov()
        {
            ClickToDeleteMakarPortnov();
            return GetPOM<RemoveInspectorPage>(driver);
        }

        public RemoveInspectorPage RemoveOlegAdamov()
        {
            ClickToDeleteOlegAdamov();
            return GetPOM<RemoveInspectorPage>(driver);
        }

        public RemoveInspectorPage RemoveIvanIvanov()
        {
            ClickToDeleteIvanIvanov();
            return GetPOM<RemoveInspectorPage>(driver);
        }

        public AddInspectorsPage ClickToAddInspector()
        {
            ClickOnAddInspectorsButton();
            return GetPOM<AddInspectorsPage>(driver);
        }
    }
}
