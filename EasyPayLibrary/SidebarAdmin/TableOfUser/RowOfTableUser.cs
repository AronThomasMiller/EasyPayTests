using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPayLibrary
{
    public class RowOfTableUser : BasePageObject
    {
        WebElementWrapper surname;
        WebElementWrapper name;
        WebElementWrapper role;
        WebElementWrapper email;
        WebElementWrapper phoneNumber;
        WebElementWrapper btnChangeRole;
        WebElementWrapper btnSaveChange;
        WebElementWrapper btnBan;

        public RowOfTableUser(WebElementWrapper element, DriverWrapper driver)
        {
            base.Init(driver);
            surname = element.GetByXpath(".//td[1]");
            name = element.GetByXpath(".//td[2]");
            role = element.GetByXpath(".//td[3]");
            email = element.GetByXpath(".//td[4]");
            phoneNumber = element.GetByXpath(".//td[5]");
            btnChangeRole = element.GetByXpath(".//td[6]//button");
            btnSaveChange = element.GetByXpath(".//td[7]//a");
            btnBan = element.GetByXpath(".//td[7]//a");
        }
        public RowOfTableUser()
        {

        }

        public string GetRole()
        {
            return role.GetText();
        }

        public string GetSurname()
        {
            return surname.GetText();
        }

        public string GetName()
        {
            return name.GetText();
        }

        public string GetEmail()
        {
            return email.GetText();
        }

        public string GetPhoneNumber()
        {
            return phoneNumber.GetText();
        }

        public ChangeRole GetChangeRolePopUp()
        {
            btnChangeRole.Click();
            return GetPOM<ChangeRole>(driver);
        }
        public BanUser ClickBan()
        {
            btnBan.Click();
            return GetPOM<BanUser>(driver);
        }
    }
}
