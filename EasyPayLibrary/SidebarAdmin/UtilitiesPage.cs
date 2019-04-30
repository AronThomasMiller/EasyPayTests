using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPayLibrary.Admin
{
   public class UtilitiesPage: GeneralPage
    {
        public UtilitiesForm admin;
        public override void Init(DriverWrapper driver)
        {
            admin = GetPOM<UtilitiesForm>(driver);
            base.Init(driver);
        }
    }
}
