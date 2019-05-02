using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPayLibrary.Changes
{
    public class ConnectedUtilitiesPage : GeneralPage
    {
        public ConnectedUtilitiesForm selectAddresse;

        public override void Init(DriverWrapper driver)
        {
            selectAddresse = GetPOM<ConnectedUtilitiesForm>(driver);
            base.Init(driver);
        }
    }
}
