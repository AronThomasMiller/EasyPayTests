using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPayLibrary.Pages.Base
{
    public class LanguageChanger
    {
        public static void ChangeToUA(DriverWrapper driver)
        {
            WebElementWrapper btnUA = driver.GetByXpath("//a[@href='?lang=ua']");
            btnUA.Click();
        }

        public static void ChangeToEN(DriverWrapper driver)
        {
            WebElementWrapper btnEN = driver.GetByXpath("//a[@href='?lang=en']");
            btnEN.Click();
        }
    }
}