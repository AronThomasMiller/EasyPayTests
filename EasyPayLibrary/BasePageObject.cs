using EasyPayLibrary.Pages;
using EasyPayLibrary.Pages.Base;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPayLibrary
{
    public abstract class BasePageObject
    {
        protected DriverWrapper driver;

        public virtual void Init(DriverWrapper driver)
        {
            this.driver = driver;            
        }

        public static T GetPOM<T>(DriverWrapper driver) where T : BasePageObject, new()
        {
            var pom = new T();
            pom.Init(driver);
            return pom;
        }

        public static T TranslatePageToUA<T>(DriverWrapper driver) where T : BasePageObject, new()
        {
            LanguageChanger.ChangeToUA(driver);
            return GetPOM<T>(driver);
        }

        public static T TranslatePageToEN<T>(DriverWrapper driver) where T : BasePageObject, new()
        {
            LanguageChanger.ChangeToEN(driver);
            return GetPOM<T>(driver);
        }
    }
}