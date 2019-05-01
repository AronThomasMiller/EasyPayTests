using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPayLibrary.ManagerSidebar
{
    public class StatisticsPage : BasePageObject
    {
        public bool IsCurrentAppointmentVisible()
        {
            var currentAppointments = driver.GetByXpath("//span[contains(text(),'Current appointments')]");
            return currentAppointments.IsDisplayed();
        }

        public bool IsPreviousAppointmentsVisible()
        {
            var previousAppointments = driver.GetByXpath("//span[contains(text(),'Previous appointments')]");
            return previousAppointments.IsDisplayed();
        }
    }
}
