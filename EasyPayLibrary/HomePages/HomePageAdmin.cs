using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPayLibrary.Admin
{
    public class HomePageAdmin: GeneralPage
    {
        private SideBarAdmin sideBar;
        public override void Init(DriverWrapper driver)
        {
            sideBar = GetPOM<SideBarAdmin>(driver);
            base.Init(driver);
        }
        public UtilitiesForm OpenUtilities()
        {
            sideBar.GoToUtilities();
            return GetPOM<UtilitiesForm>(driver);

        }
        
    }
}
