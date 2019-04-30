using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPayLibrary.Changes
{
   public class AddressesPage:GeneralPage
    {
        public AddAddressForm address;
        public override void Init(DriverWrapper driver)
        {
            address = GetPOM<AddAddressForm>(driver);
            base.Init(driver);
        }

    }
}
