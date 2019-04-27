using EasyPayLibrary.Pages;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPayLibrary
{
    public class BasePageObject:IBasePageObject
    {
        protected DriverWrapper driver;

        public BasePageObject()
        {
        }

        public GeneralPage GetPage() { return GetPOM<GeneralPage>(driver);}

        public virtual void Init(DriverWrapper driver)
        {
            this.driver = driver;
            //InitDriver(driver);
        }

        //private void InitDriver(DriverWrapper driver) => this.driver = driver;

        public static T GetPOM<T>(DriverWrapper driver) where T: BasePageObject, new()
        {
            var pom = new T();
            pom.Init(driver);
            return pom;
        }
    }
}
