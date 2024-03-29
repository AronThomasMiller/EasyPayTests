﻿using EasyPayLibrary.ManagerSidebar;

namespace EasyPayLibrary.Pages.Manager
{
    public class InspectorsListPage : BasePageObject
    {
        //type of element
        WebElementWrapper panel;
        //create pom for table
        WebElementWrapper optionInspector;
        WebElementWrapper btnAddInspector;
        WebElementWrapper btnRemoveInspector;

        public override void Init(DriverWrapper driver)
        {
            base.Init(driver);
        }

        public string StatusOfOperation()
        {
            var status = driver.GetByXpath("//h4[@class='ui-pnotify-title']").GetText();
            return status;
        }

        public WebElementWrapper GetInspector(string name)
        {
            return driver.GetByXpath($"//a[contains(text(),'{name}')]");
        }

        public void ClickOnInspector(string name)
        {
            optionInspector = GetInspector(name);
            optionInspector.Click();
        }

        public void ClickToRemoveInspector(string name)
        {
            btnRemoveInspector = driver.GetByXpath($"//a[contains(text(),'{name}')]/../..//td[2]/button");
            btnRemoveInspector.Click();
        }

        public void ClickOnAddInspectorsButton()
        {
            btnAddInspector = driver.GetByXpath("//button[@onclick='getFreeInspectors()']");
            btnAddInspector.Click();
        }
        public SchedulePage NavigateToInspectorsSchedule(string name)
        {
            ClickOnInspector(name);
            return GetPOM<SchedulePage>(driver);
        }

        public RemoveInspectorPage RemoveInspector(string name)
        {
            driver.Refresh();
            ClickToRemoveInspector(name);
            return GetPOM<RemoveInspectorPage>(driver);
        }


        public AddInspectorsPage ClickToAddInspector()
        {
            driver.Refresh();
            ClickOnAddInspectorsButton();
            return GetPOM<AddInspectorsPage>(driver);
        }

        public string VerifyListOfInspectorsIsNotEmpty()
        {
            panel = driver.GetByXpath("//div[@id='tab-inspectors']//td[1]");
            return panel.ToString();
        }

        
    }
}