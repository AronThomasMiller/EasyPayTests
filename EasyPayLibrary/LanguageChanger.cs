using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPayLibrary.Pages
{
    public class LanguageChanger : BasePageObject
    {
        private WebElementWrapper btnLanguage;

        public override void Init(DriverWrapper driver)
        {            
            base.Init(driver);
        }

        public void ClickOnDropdown()
        {
            btnLanguage = driver.GetByXpath("//*[@id='language-dropdown']");
            btnLanguage.Click();
        }

        public void ChangeToUA()
        {
            ClickOnDropdown();
            driver.GetByXpath("//a[@href='?lang=ua']").Click();           
        }

        public BasePageObject ChangeToEN()
        {
            ClickOnDropdown();
            driver.GetByXpath("//a[@href='?lang=en']").Click();
            return GetPOM<BasePageObject>(driver);
        }
    }
}
