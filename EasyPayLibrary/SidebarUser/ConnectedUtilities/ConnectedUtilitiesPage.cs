using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPayLibrary.Changes
{
    public class ConnectedUtilitiesPage : HomePageUser
    {
        //FormToManageAddress
        ConnectedUtilitiesForm selectAddresse;

        public override void Init(DriverWrapper driver)
        {
            base.Init(driver);
            selectAddresse = GetPOM<ConnectedUtilitiesForm>(driver);    
        }

        public HomePageUser CallInspector(string address)
        {
            selectAddresse.CallInspector(address);
            return selectAddresse.SubmitCall();
        }

        public string SelectAddress(string address)
        {
            return selectAddresse.SelectAddress(address);
        }

        public ConnectedUtilitiesForm Disconect()
        {
           return selectAddresse.Disconect();
        }
    }
}
