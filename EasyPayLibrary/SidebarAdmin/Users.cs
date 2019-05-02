﻿using System.Threading;

namespace EasyPayLibrary
{
    public class Users : HomePageAdmin
    {
        WebElementWrapper tableOfUsers;
        WebElementWrapper btnChangeRole;
        WebElementWrapper role;
        WebElementWrapper drpListOfRoles;
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
            drpListOfRoles.Click();
            rrole = driver.GetByXpath($"//select[@id='role']/option[text()='{role}']");
            rrole.Click();
            btnSaveChange = driver.GetByXpath("//button[@id='updateRole']");
            btnSaveChange.Click();
        }

        public void ChangeRoleToManager()
        {            
            btnChangeRole = driver.GetByXpath("//tbody/tr/td[contains(text(),'user3@gmail.com')]/../td[6]/button");
            btnChangeRole.Click();
            SelectRole("MANAGER");
        }

        public void ChangeRoleToUser()
        {
            btnChangeRole = driver.GetByXpath("//tbody/tr/td[contains(text(),'user3@gmail.com')]/../td[6]/button");
            btnChangeRole.Click();
            SelectRole("user");
        }
        public string GetRole()
        {
            role = driver.GetByXpath("//tbody/tr/td[contains(text(),'user3@gmail.com')]/../td[3]");
            return role.GetText();
        }
    }
}