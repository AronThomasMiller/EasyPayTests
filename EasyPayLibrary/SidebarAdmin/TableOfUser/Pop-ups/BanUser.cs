using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPayLibrary
{
    public class BanUser: BasePageObject
    {
        WebElementWrapper btnClose;
        WebElementWrapper btnSave;

        public override void Init(DriverWrapper driver)
        {
            base.Init(driver);
            btnClose = driver.GetByXpath("//button[@id='closeChangeStatus']");
            btnSave = driver.GetByXpath("//button[@id='updateUserStatus']");
        }

        public UsersPage ClickOnClose()
        {
            btnClose.Click();
            return GetPOM<UsersPage>(driver);
        }

        public UsersPage ClickOnSave()
        {
            btnSave.Click();
            return GetPOM<UsersPage>(driver);
        }
    }
}
