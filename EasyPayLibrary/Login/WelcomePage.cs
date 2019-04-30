﻿using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPayLibrary
{
    public class WelcomePage : BasePageObject
    {
        WebElementWrapper btnSignIn;
        WebElementWrapper btnSignUp;

        public override void Init(DriverWrapper driver)
        {
            btnSignIn = driver.GetByXpath("//*[@id='Sign_in']");
            btnSignUp = driver.GetByXpath("//*[@id='Sign_up']");
            base.Init(driver);
        }

        public void ClickOnSignInButton()
        {
            btnSignIn.ClickOnIt();
        }

        public void ClickOnSignUpButton()
        {
            btnSignUp.ClickOnIt();
        }

        public LoginPage SignIn()
        {
            ClickOnSignInButton();
            return GetPOM<LoginPage>(driver);
        }

        public LoginPage SignUp()
        {
            ClickOnSignUpButton();
            return GetPOM<LoginPage>(driver);
        }
    }
}