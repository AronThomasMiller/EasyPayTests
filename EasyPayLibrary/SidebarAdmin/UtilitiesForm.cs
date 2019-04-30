using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPayLibrary.Admin
{
    public class UtilitiesForm: BasePageObject
    {
        WebElementWrapper panel;
        public override void Init(DriverWrapper driver)
        {
            base.Init(driver);

        }
        public string VerifyUtilitiesListIsNotEmpty()
        {
            panel = driver.GetByXpath("//div[@class='x_content']");
            return panel.ToString();
        }


    }
}
