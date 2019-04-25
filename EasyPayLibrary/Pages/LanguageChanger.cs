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
            btnLanguage = driver.GetByXpath("//*[@id='language-dropdown']");
            base.Init(driver);
        }

        public void ClickOnDropdown()
        {
            btnLanguage.ClickOnIt();
        }

        public BasePageObject ChangeToUA()
        {
            ClickOnDropdown();
            driver.GetByXpath("//a[@href='?lang=ua']").ClickOnIt();
            return GetPOM<BasePageObject>(driver);
        }

        public void ChangeToEN()
        {
            ClickOnDropdown();
            driver.GetByXpath("//a[@href='?lang=en']").ClickOnIt();
        }
    }
}
