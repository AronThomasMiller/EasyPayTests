using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPayLibrary
{
    class SelectElementWrapper
    {
        SelectElement selectElement;
        
        public SelectElementWrapper(WebElementWrapper element)
        {
            selectElement = new SelectElement(element.GetElement());
        }

        public void SelectByText(string text)
        {
            selectElement.SelectByText(text);
        }
    }
}
