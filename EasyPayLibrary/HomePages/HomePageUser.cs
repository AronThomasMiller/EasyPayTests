using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPayLibrary.Changes
{
    public class HomePageUser : GeneralPage
    {
        private SideBarUser sideBar;
        public override void Init(DriverWrapper driver)
        {
            sideBar = GetPOM<SideBarUser>(driver);
            base.Init(driver);
        }

        public AddAddressForm OpenAddresses()
        {
            sideBar.GoToAddresses();
            return GetPOM<AddAddressForm>(driver);
        }
        public ConnectedUtilitiesForm OpenUtilities()
        {
            sideBar.GoToConnectedUtilities();
            return GetPOM<ConnectedUtilitiesForm>(driver);
        }
        public PaymentsHistoryForm OpenPaymentsHistory()
        {
            sideBar.GoToPaymentsHistory();
            return GetPOM<PaymentsHistoryForm>(driver);
        }
        public PaymentsPageForm OpenPayments()
        {
            sideBar.GoToPayments();
            return GetPOM<PaymentsPageForm>(driver);
        }
        public RateInspectorsPage OpenRateInspectors()
        {
            sideBar.GoToRateInspectors();
            return GetPOM<RateInspectorsPage>(driver);
        }



    }
}
