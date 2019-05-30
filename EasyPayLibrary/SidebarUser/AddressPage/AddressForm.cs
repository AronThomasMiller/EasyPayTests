using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPayLibrary.Changes
{
    public class AddAddressForm : BasePageObject
    {
        WebElementWrapper fieldAddress;
        WebElementWrapper fieldHouse;
        WebElementWrapper fieldStreet;
        WebElementWrapper fieldCity;
        WebElementWrapper fieldRegion;
        WebElementWrapper fieldZipCode;
        WebElementWrapper fieldCountry;
        WebElementWrapper btnAddAddresse;
        WebElementWrapper btnCheck;
        WebElementWrapper fieldFlat;
        WebElementWrapper error;

        public override void Init(DriverWrapper driver)
        {
            base.Init(driver);
            fieldAddress = driver.GetByXpath("//input[@id='autocomplete']");
            fieldHouse = driver.GetByXpath("//*[@id='street_number']");
            fieldStreet = driver.GetByXpath("//*[@id='route']");
            fieldCity = driver.GetByXpath("//*[@id='locality']");
            fieldRegion = driver.GetByXpath("//*[@id='administrative_area_level_1']");
            fieldZipCode = driver.GetByXpath("//*[@id='postal_code']");
            fieldCountry = driver.GetByXpath("//*[@id='country']");
            fieldFlat = driver.GetByXpath("//*[@id='flat_number']");
            btnCheck = driver.GetByXpath("//*[@id='flat_checkbox']");
            btnAddAddresse = driver.GetByXpath("//*[@id='submit']");           
        }

        public void SetAddress(string address)
        {
            fieldAddress.Click();
            fieldAddress.SendText(address);
            fieldAddress.sendEnter();
        }

        public void SetHouse(string house)
        {
            fieldHouse.Click();
            fieldHouse.SendText(house);
        }

        public void SetStreet(string street)
        {
            fieldStreet.Click();
            fieldStreet.SendText(street);
        }

        public void SetCity(string city)
        {
            fieldCity.Click();
            fieldCity.SendText(city);
        }

        public void SetRegion(string region)
        {
            fieldRegion.Click();
            fieldRegion.SendText(region);
        }

        public void SetZipCode(string zipCode)
        {
            fieldZipCode.SendText(zipCode);
        }

        public void SetCountry(string country)
        {
            fieldCountry.SendText(country);
        }

        public void ClickOnCheck()
        {
            btnCheck.Click();
        }

        public void SetFlat(string flat)
        {
            fieldFlat.SendText(flat);
        }

        public void Submit()
        {
            btnAddAddresse.Click();
        }

        public void EnterAllFields(string address, string house, string street, string city, string region, string zipCode, string country, string flat)
        {
            fieldAddress.SendText(address);
            fieldAddress.sendEnter();
            fieldHouse.SendText(house);
            fieldStreet.SendText(street);
            fieldCity.SendText(city);
            fieldRegion.SendText(region);
            fieldZipCode.SendText(zipCode);
            fieldCountry.SendText(country);
            btnCheck.Click();
            fieldFlat.SendText(flat);
            btnAddAddresse.Click();
        }

        public string Error()
        {
            error = driver.GetByXpath("//div[contains(@class,'ui-pnotify-fade-normal ui-pnotify-move ui-pnotify-in ui-pnotify-fade-in')]");
            return error.GetText();
        }
    }
}
