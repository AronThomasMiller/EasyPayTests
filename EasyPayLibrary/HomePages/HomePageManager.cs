using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPayLibrary.Manager
{
    public class HomePageManager: GeneralPage
    {
        private SideBarManager sideBar;
        public override void Init(DriverWrapper driver)
        {
            sideBar = GetPOM<SideBarManager>(driver);
            base.Init(driver);
        }
        public ManagerForm OpenPagewithInspector()
        {
            sideBar.GoToInspectors();
            return GetPOM<ManagerForm>(driver);

        }
    }
}
