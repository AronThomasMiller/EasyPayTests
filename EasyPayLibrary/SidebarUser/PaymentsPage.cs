using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPayLibrary.Changes
{
    public class PaymentsPage : BaseSidebar
    {
        public PaymentsPageForm pay;
        public override void Init(DriverWrapper driver)
        {
            pay = GetPOM<PaymentsPageForm>(driver);
            base.Init(driver);
        }
    }
}
