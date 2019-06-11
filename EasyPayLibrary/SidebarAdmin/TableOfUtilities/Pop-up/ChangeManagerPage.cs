using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPayLibrary
{
    public class ChangeManagerPage:BasePageObject
    {
        WebElementWrapper fieldUpdate;
        WebElementWrapper manager;
        WebElementWrapper btnClose;
        WebElementWrapper btnConfim;

        public override void Init(DriverWrapper driver)
        {
            base.Init(driver);
            fieldUpdate = driver.GetByXpath("//input[@id='change_manager']");
            manager = driver.GetByXpath("//select[@id='update_managers']");
            btnClose = driver.GetByXpath("//div[@id='update_utility_modal']//a[contains(@class,'btn btn-secondary')]");
            btnConfim = driver.GetByXpath("//button[@id='update_button']");
        }

        public void InputKeyWord()
        {
            fieldUpdate.Click();
            fieldUpdate.SendText("UPDATE");
        }

        public void chooseManager(string name)
        {
            manager.Click();
            var chooseManger = driver.GetByXpath($"//select[@id='update_managers']//option[contains(text(),'{name}')]");
            chooseManger.Click();
        }

        public UtilitiesPage SelectManager(string myManager)
        {
            InputKeyWord();
            chooseManager(myManager);
            return ClickConfirm();
        }

        public UtilitiesPage ClickConfirm()
        {
            btnConfim.Click();
            return GetPOM<UtilitiesPage>(driver);
        }
    }
}
