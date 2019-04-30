using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPayLibrary.Changes
{
    public class PaymentsHistoryPage : BaseSidebar
    {
        public PaymentsHistoryForm selectAddresse;
        public override void Init(DriverWrapper driver)
        {
            selectAddresse = GetPOM<PaymentsHistoryForm>(driver);
            base.Init(driver);
        }


    }
}
