using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPayLibrary.Manager
{
    public class InspectorsPage : GeneralPage
    {
        public ManagerForm manager;
        public override void Init(DriverWrapper driver)
        {
            manager = GetPOM<ManagerForm>(driver);
            base.Init(driver);
        }
    }
}
