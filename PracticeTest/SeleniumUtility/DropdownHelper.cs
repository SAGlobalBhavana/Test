using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpowerApps.SeleniumUtility
{
    public static class DropdownHelper
    {
        public static void selectByVisibleText(IWebElement dropdownElement, String option)
        {
            try
            {
                SelectElement select = new SelectElement(dropdownElement);
                select.SelectByText(option);
             SelectElement select = new SelectElement(dropdownElement);
                select.SelectByValue(option);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
