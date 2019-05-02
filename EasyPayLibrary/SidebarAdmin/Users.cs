using System.Threading;

namespace EasyPayLibrary
{
    public class Users : HomePageAdmin
    {
        WebElementWrapper tableOfUsers;
        WebElementWrapper btnChangeRole;
        WebElementWrapper role;
        WebElementWrapper drpdListOfRoles;
        WebElementWrapper drpdRole;
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
            myRole = myRole.ToUpper();
            drpdListOfRoles = driver.GetByXpath("//select[@id='role']");
            drpdListOfRoles.Click();

            var drpdRole = driver.GetByXpath($"//select[@id='role']").selectElement();
            drpdRole.SelectByText(myRole);

            btnSaveChange = driver.GetByXpath("//button[@id='updateRole']");
            btnSaveChange.Click();
        }

        public void ChangeRoleToManager(string email)
        {            
            btnChangeRole = driver.GetByXpath($"//tbody/tr/td[contains(text(),'{email}')]/../td[6]/button");
            btnChangeRole.Click();
            SelectRole("MANAGER");
        }

        public void ChangeRoleToUser(string email)
        {
            btnChangeRole = driver.GetByXpath($"//tbody/tr/td[contains(text(),'{email}')]/../td[6]/button");
            btnChangeRole.Click();
            SelectRole("user");
        }
        public string GetRole(string email)
        {
            role = driver.GetByXpath($"//tbody/tr/td[contains(text(),'{email}')]/../td[3]");
            return role.GetText();
        }
    }
}