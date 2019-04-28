using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPayLibrary.Pages.UnauthorizedUserPages
{
    public class RedirectModalWindow:BasePageObject
    {
        public static void ClickOnRedirectButton(DriverWrapper driver, int timeoutInSec)
        {
            WebElementWrapper btnRedirect = driver.GetByXpath("//a[@id='redirect-btn']", timeoutInSec);
            btnRedirect.ClickOnIt();
        }
    }
}
