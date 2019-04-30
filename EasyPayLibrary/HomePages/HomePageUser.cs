using EasyPayLibrary.Changes;
using System.Collections.Generic;

namespace EasyPayLibrary
{
    public class HomePageUser : GeneralPage
    {
        public SideBarUser sidebar;
        public BaseSidebar baseSidebar;

        public override void Init(DriverWrapper driver)
        {
            sidebar = GetPOM<SideBarUser>(driver);
            baseSidebar = GetPOM<BaseSidebar>(driver);
            base.Init(driver);
        }
        
        public IEnumerable<WebElementWrapper> GetList ()
        {
            return baseSidebar.GetListOfSideBarComponents();
        }
    }
}