using System.Threading;

namespace EasyPayLibrary
{
    public class Users : HomePageAdmin
    {
        WebElementWrapper tableOfUsers;
        WebElementWrapper btnChangeRole;
        WebElementWrapper role;
        WebElementWrapper drpListOfRoles;
        WebElementWrapper managerRole;
        WebElementWrapper rrole;
        WebElementWrapper btnSaveChange;

        public override void Init(DriverWrapper driver)
        {
            base.Init(driver);
            btnChangeRole = driver.GetByXpath("//tbody/tr/td[contains(text(),'user3@gmail.com')]/../td[6]/button");
            role = driver.GetByXpath("//tbody/tr/td[contains(text(),'user3@gmail.com')]/../td[3]");
            tableOfUsers = driver.GetByXpath("//table[@id='user-list']");
        }

        public bool TableOfUsersIsVisible()
        {
            return tableOfUsers.IsDisplayed();
        }

        public void SelectRole(string myRole)
        {
            string role = myRole.ToUpper();
            drpListOfRoles = driver.GetByXpath("//select[@id='role']");
            drpListOfRoles.ClickOnIt();
            rrole = driver.GetByXpath($"//select[@id='role']/option[text()='{role}']");
            rrole.ClickOnIt();
            btnSaveChange = driver.GetByXpath("//button[@id='updateRole']");
            btnSaveChange.ClickOnIt();
        }

        public void ChangeRoleToManager()
        {            
            btnChangeRole = driver.GetByXpath("//tbody/tr/td[contains(text(),'user3@gmail.com')]/../td[6]/button");
            btnChangeRole.ClickOnIt();
            SelectRole("manager");
        }

        public void ChangeRoleToUser()
        {
            btnChangeRole = driver.GetByXpath("//tbody/tr/td[contains(text(),'user3@gmail.com')]/../td[6]/button");
            btnChangeRole.ClickOnIt();
            SelectRole("user");
        }
        public string GetRole()
        {
            role = driver.GetByXpath("//tbody/tr/td[contains(text(),'user3@gmail.com')]/../td[3]");
            return role.GetText();
        }
    }
}