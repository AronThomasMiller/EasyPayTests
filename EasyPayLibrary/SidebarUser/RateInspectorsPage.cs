using EasyPayLibrary.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPayLibrary.Changes
{
   public class RateInspectorsPage : GeneralPage
    {
        public RateInspectorsForm rate;
        public override void Init(DriverWrapper driver)
        {
            rate = GetPOM<RateInspectorsForm>(driver);
            base.Init(driver);
        }
        public InspectorsPage ReturnRateInspectors()
        {
            return GetPOM<InspectorsPage>(driver);
        }

    }
}
