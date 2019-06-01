using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPayLibrary.Changes
{
    public class ConnectedUtilitiesPage : GeneralPage
    {
        //FormToManageAddress
        ConnectedUtilitiesForm selectAddresse;

        public override void Init(DriverWrapper driver)
        {
            base.Init(driver);
            selectAddresse = GetPOM<ConnectedUtilitiesForm>(driver);    
        }
    }
}
