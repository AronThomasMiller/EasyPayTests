using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPayLibrary.Manager
{
    public class ManagerForm: BasePageObject
    {
        WebElementWrapper panel;
        public override void Init(DriverWrapper driver)
        {
            base.Init(driver);

        }
        public string VerifyListOfInspectorsNotEmpty()
        {
            panel = driver.GetByXpath("//div[@class='x_content']");
            return panel.ToString();
        }
    }
}
