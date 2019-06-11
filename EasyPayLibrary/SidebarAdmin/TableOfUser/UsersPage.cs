using System.Threading;

namespace EasyPayLibrary
{
    public class UsersPage : HomePageAdmin
    {
        WebElementWrapper tbOfUsers;

        public override void Init(DriverWrapper driver)
        {
            base.Init(driver);
            tbOfUsers = driver.GetByXpath("//table[@id='user-list']//tbody");           
        }

        public bool TableOfUsersIsVisible()
        {
            return tbOfUsers.IsDisplayed();
        }

        public TableOfUsers ReturnUsersTable()
        {
            return GetPOM<TableOfUsers>(driver);
        }       
    }
}