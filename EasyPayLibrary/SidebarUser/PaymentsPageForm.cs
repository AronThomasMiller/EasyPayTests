using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPayLibrary.Changes
{
   public class PaymentsPageForm: BasePageObject
    {
        WebElementWrapper btnPayments;
        WebElementWrapper selectAddresse;
        WebElementWrapper btnDetails;
        WebElementWrapper setNewValue;
        WebElementWrapper fieldNewValue;
        WebElementWrapper btnApply;
        WebElementWrapper balance;
        WebElementWrapper btnPay;
        WebElementWrapper fieldSum;
        WebElementWrapper sendCheck;
        WebElementWrapper btnProceed;
        WebElementWrapper fieldEmail;
        WebElementWrapper fieldCardNumber;
        WebElementWrapper fieldDate;
        WebElementWrapper fieldCVC;
        WebElementWrapper fieldZip;
        WebElementWrapper btnSubmit;

        public override void Init(DriverWrapper driver)
        {
            btnPayments = driver.GetByXpath("//a[@href='/user/paymentsPage']");
            

            
            base.Init(driver);

        }
        public void ClickOnPayments()
        {
            btnPayments.Click();
        }
        public string SelectAddress(string address)
        {
            selectAddresse = driver.GetByXpath("//select[@id='selectAddress']");
            SelectElement listOfAddressesPay;            
            listOfAddressesPay = selectAddresse.selectElement();
            listOfAddressesPay.SelectByText(address);
            return listOfAddressesPay.SelectedOption.Text;
        }
        
        public void ClickOnDetails()
        {
            btnDetails = driver.GetByXpath("//tbody/tr[1]/td/button");
            btnDetails.Click();
        }

        public void ClickSetNewValue()
        {
            setNewValue = driver.GetByXpath("//table[@id = 'modal-table']/tbody/tr/td/button");
            setNewValue.Click();
        }

        public void SetNewValue(string value)
        {
            fieldNewValue = driver.GetByXpath("//input[@id='newCurrentValue']");
            fieldNewValue.SendText(value);
        }
        public void Apply()
        {
            btnApply = driver.GetByXpath("//button[@class='btn btn-primary js-apply']");
            btnApply.Click();
        }
        public void ClickOnPay()
        {
            btnPay = driver.GetByXpath("//*[@id='pay']");
            btnPay.Click();
        }
        public void EnterSum(string sum)
        {
            fieldSum = driver.GetByXpath("//*[@id='payment-sum-input']");
            fieldSum.SendText(sum);
        }
        public void DownloadCheck()
        {
            sendCheck = driver.GetByXpath("//label[@id='download-check-label']");
            sendCheck.Click();
        }
        public void Proceed()
        {
            btnProceed = driver.GetByXpath("//button[@id='payment-proceed']");
            btnProceed.Click();
        }
        public void EnterDebtInfo(string address, string sum)
        {
            selectAddresse = driver.GetByXpath("//*[@id='selectAddress']");
            SelectElement listOfAddressesPay;
            listOfAddressesPay = selectAddresse.selectElement();
            listOfAddressesPay.SelectByText(address);
            btnDetails = driver.GetByXpath("//tbody/tr[1]/td/button");
            btnDetails.Click();
            btnPay = driver.GetByXpath("//*[@id='pay']");
            btnPay.Click();
            fieldSum = driver.GetByXpath("//*[@id='payment-sum-input']");
            fieldSum.SendText(sum);
            sendCheck = driver.GetByXpath("//label[@id='download-check-label']");
            sendCheck.Click();
            btnProceed = driver.GetByXpath("//button[@id='payment-proceed']");
            btnProceed.Click();




        }
        public void EnterEmail(string email)
        {
            fieldEmail = driver.GetByXpath("//input[@placeholder='Email']");
            fieldEmail.SendText(email);
        }
        public void EnterCardNumber(string cardNumb)
        {
            fieldCardNumber = driver.GetByXpath("//input[@placeholder='Card number']");
            fieldCardNumber.SendText(cardNumb);

        }
        public void EnterDate(string date)
        {
            fieldDate = driver.GetByXpath("//input[@placeholder='MM / YY']");
            fieldDate.SendText(date);
        }
        public void EnterCVC(string cvc)
        {
            fieldCVC = driver.GetByXpath("//input[@placeholder='CVC']");
            fieldCVC.SendText(cvc);
        }
        public void EnterZip(string zip)
        {
            fieldZip = driver.GetByXpath("//input[@placeholder='ZIP Code']");
            fieldZip.SendText(zip);
        }
        public void Submit()
        {
            btnSubmit = driver.GetByXpath("//button[@type='submit']");
            btnSubmit.Click();
        }
        public void MakePayment(string email, string cardNumb, string date, string cvc, string zip)
        {
            fieldEmail = driver.GetByXpath("//input[@placeholder='Email']");
            fieldEmail.SendText(email);
            fieldCardNumber = driver.GetByXpath("//input[@placeholder='Card number']");
            fieldCardNumber.SendText(cardNumb);
            fieldDate = driver.GetByXpath("//input[@placeholder='MM / YY']");
            fieldDate.SendText(date);
            fieldCVC = driver.GetByXpath("//input[@placeholder='CVC']");
            fieldCVC.SendText(cvc);
            fieldZip = driver.GetByXpath("//input[@placeholder='ZIP Code']");
            fieldZip.SendText(zip);
            btnSubmit = driver.GetByXpath("//button[@type='submit']");
            btnSubmit.Click();



        }

        public double GetBalance()
        {
            balance = driver.GetByXpath("//tbody/tr[1]/td[2]");
            return  Convert.ToDouble(balance.GetText().Replace('.',','));
            
        }
        public void ChangeMatrix(string address, string value)
        {
            selectAddresse = driver.GetByXpath("//*[@id='selectAddress']");
            SelectElement listOfAddressesPay;
            listOfAddressesPay = selectAddresse.selectElement();
            listOfAddressesPay.SelectByText(address);

            btnDetails = driver.GetByXpath("//tbody/tr[1]/td/button");
            btnDetails.Click();
            setNewValue = driver.GetByXpath("//table[@id = 'modal-table']/tbody/tr/td/button");
            setNewValue.Click();
            fieldNewValue = driver.GetByXpath("//input[@id='newCurrentValue']");
            fieldNewValue.SendText(value);
            btnApply = driver.GetByXpath("//button[@class='btn btn-primary js-apply']");
            btnApply.Click();

        }
    }
}
