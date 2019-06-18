using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPayLibrary
{
    public class ChangeRole:BasePageObject
    {
        WebElementWrapper role;
        WebElementWrapper btnClose;
        WebElementWrapper btnSave;

        public override void Init(DriverWrapper driver)
        {
            base.Init(driver);
            role = driver.GetByXpath("//select[@id='role']");
            btnClose = driver.GetByXpath("//button[@id='closeChangeRole']");
            btnSave = driver.GetByXpath("//button[@id='updateRole']");
        }
        public ChangeRole()
        {

        }
        public UsersPage SelectRole(string myRole)
        {
            myRole = myRole.ToUpper();
            var role = driver.GetByXpath("//select[@id='role']").SelectElement();
            role.SelectByText(myRole);
            driver.Refresh();
            return ClickOnSave();           
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
