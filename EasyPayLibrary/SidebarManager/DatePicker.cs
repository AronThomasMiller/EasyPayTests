using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 

namespace EasyPayLibrary.SidebarManager
{
    public class DatePicker
    {
        public static void DatePickerFunc(WebElementWrapper element)
        {
            for (int i = 0; i <= 7; i++)
            {
                element.sendBackSpace();
            }
        }
    }
}