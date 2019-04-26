using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPayLibrary
{
    public class BasePageObject
    {
        protected DriverWrapper driver;

        public virtual void Init(DriverWrapper driver)
        {
            this.driver = driver;
        }

        public static T GetPOM<T>(DriverWrapper driver) where T: BasePageObject, new()
        {
            var pom = new T();
            pom.Init(driver);
            return pom;
        }

        //public static bool Notify(DriverWrapper driver)
        //{
        //    return driver.GetByXpath("/html/body/div[2]").GetCssValue("background-color").Contains("rgba(38, 185, 154, 0.88)");
        //}
    }
}
