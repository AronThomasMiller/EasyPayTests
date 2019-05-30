using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPayLibrary
{
    public class SelectElementWrapper
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

        public string GetSelectedOptionText()
        {
            return selectElement.SelectedOption.Text;
        }
    }
}
