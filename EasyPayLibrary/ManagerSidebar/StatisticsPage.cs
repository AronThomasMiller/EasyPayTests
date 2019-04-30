namespace EasyPayLibrary
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