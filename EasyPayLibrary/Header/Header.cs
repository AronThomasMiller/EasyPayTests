using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPayLibrary
{
    public class Header : BasePageObject
    {
        WebElementWrapper btnProfile;
        WebElementWrapper btnLogOut;
        WebElementWrapper dropdownProfile;        
        WebElementWrapper btnUA;
        WebElementWrapper dropdownLanguage;

        public override void Init(DriverWrapper driver)
        {
            dropdownProfile = driver.GetByXpath("//li[@id='user-menu-header']/a");
            dropdownLanguage = driver.GetByXpath("//a[@class='dropdown-toggle user-profile']");
            base.Init(driver);
        }

        public void ClickOnProfileDropdown()
        {
            dropdownProfile.Click();
        }

        public void ClickOnLanguageDropdown()
        {
            dropdownLanguage.Click();
        }

        public void GoToProfile()
        {
            ClickOnProfileDropdown();
            btnProfile = driver.GetByXpath("//a[@href='/profile']");
            btnProfile.Click();
        }

        public void LogOut()
        {
            ClickOnProfileDropdown();
            btnLogOut = driver.GetByXpath("//a[@href='/logout']");
            btnLogOut.Click();
        }

        public void ChangeToUa()
        {
            ClickOnLanguageDropdown();
            btnUA = driver.GetByXpath("//a[@href='?lang=ua']");
            btnUA.Click();
        }
    }
}