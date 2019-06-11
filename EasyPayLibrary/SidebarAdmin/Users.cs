using System.Threading;

namespace EasyPayLibrary
{
    //users? what object of this class means? Users like a list which contains name and password? Or smth else?
    public class Users : HomePageAdmin
    {
        //create POM class for table of users which contains rows of users
        //and there use Select by email, name or smth else, thus you can make SomeUsersPage.GetTableOfUsers().SelectUserByEmail(email).ChangeRole(Role)
        WebElementWrapper tableOfUsers;
        WebElementWrapper btnChangeRole;
        WebElementWrapper role;
        WebElementWrapper user;
        WebElementWrapper btnSaveChange;

        public override void Init(DriverWrapper driver)
        {
            base.Init(driver);
            btnChangeRole = driver.GetByXpath("//tbody/tr/td[contains(text(),'user3@gmail.com')]/../td[6]/button");
            role = driver.GetByXpath("//tbody/tr/td[contains(text(),'user3@gmail.com')]/../td[3]");
            tableOfUsers = driver.GetByXpath("//table[@id='user-list']");
            user = driver.GetByXpath("//td[text()='user1@gmail.com']");
        }
        //it can take less space using property
        public bool TableOfUsersIsVisible()
        {
            return tableOfUsers.IsDisplayed();
        }

        public bool UserIsVisible()
        {
            return user.IsDisplayed();
        }

        //This method and next ones you should put in UserRow class
        public void SelectRole(string myRole)
        {
            myRole = myRole.ToUpper();

            var drpdRole = driver.GetByXpath($"//select[@id='role']").SelectElement();
            drpdRole.SelectByText(myRole);

            btnSaveChange = driver.GetByXpath("//button[@id='updateRole']");
            btnSaveChange.Click();
        }

        public void ChangeRole(string email, string role)
        {            
            btnChangeRole = driver.GetByXpath($"//tbody/tr/td[contains(text(),'{email}')]/../td[6]/button");
            btnChangeRole.Click();
            SelectRole(role);
            driver.Refresh();
        }
        
        public string GetRole(string email)
        {
            role = driver.GetByXpath($"//tbody/tr/td[contains(text(),'{email}')]/../td[3]");
            return role.GetText();
        }
    }
}