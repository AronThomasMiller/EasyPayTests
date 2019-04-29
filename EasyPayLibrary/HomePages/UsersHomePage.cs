using EasyPayLibrary.Pages;

namespace EasyPayLibrary
{
    public class UsersHomePage : GeneralPage
    {
        WebElementWrapper role;
        WebElementWrapper mainPageTitle;
        WebElementWrapper xTitle;

        SidebarUsers sidebar;
        LanguageChanger language;

        public override void Init(DriverWrapper driver)
        {
            language = GetPOM<LanguageChanger>(driver);
            sidebar = GetPOM<SidebarUsers>(driver);
            base.Init(driver);
        }

        public bool GetRole()
        {
            role = driver.GetByXpath("//h3[text()='User']");
            return role.IsDisplayed();
        }
        public string GetRoleText()
        {
            return sidebar.GetRoleText().ToLower();
        }

        public string GetAddressesText()
        {
            return sidebar.GetAddressesText();
        }

        public string GetConnectedUtilitiesText()
        {
            return sidebar.GetConnectedUtilitiesText();
        }

        public string GetPaymentsText()
        {
            return sidebar.GetPaymentsText();
        }

        public string GetPaymentsHistoryText()
        {
            return sidebar.GetPaymentsHistoryText();
        }

        public string GetRateInspectorsText()
        {
            return sidebar.GetRateInspectorsText();
        }

        public LanguageChanger ChangeToUKR()
        {
            language.ChangeToUA();
            return GetPOM<LanguageChanger>(driver);
        }

        public string GetMainPageTitleText()
        {
            mainPageTitle = driver.GetByXpath("//*[@data-locale-item='mainPage']/span");
            return mainPageTitle.GetText();
        }
        public string GetXTitleText()
        {
            xTitle = driver.GetByXpath("//*[@class='x_title']/h2");
            return xTitle.GetText();
        }

        //public bool TranslateToUA(string value)
        //{
        //    Translation translation = new Translation();
        //    return translation.CheckUA(value);
        //}
    }
}