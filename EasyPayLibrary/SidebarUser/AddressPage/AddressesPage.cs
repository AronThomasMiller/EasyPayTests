using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPayLibrary.Changes
{
    public class AddressesPage : GeneralPage
    {
        AddAddressForm address;

        public override void Init(DriverWrapper driver)
        {
            base.Init(driver);
            address = GetPOM<AddAddressForm>(driver);     
        }
    }
}
