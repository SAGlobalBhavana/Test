using EmpowerApps.SeleniumUtility;
using HybridFramework.ComonUtilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HybridFramework.Reusable_Functions.D365FO.FO_ElementRef;

namespace HybridFramework.Reusable_Functions.D365FO
{
    public class FO_LoginPage : TestBase
    {

        ///<summary>
        /// this function is used to login into FO application
        ///</summary>
        public static  void loginFO(String foURL, String username, String password)
        {
            //driver = client.Browser.Driver;
            driver.Navigate().GoToUrl(foURL);
            driver.Manage().Window.Maximize();
            TimeWaitsHelper.ThreadSleep();
            TimeWaitsHelper.WaitForClickable(driver, By.Name(FO_LoginPageRef.Email), 10);
            IWebElement UserName = driver.FindElement(By.Name(FO_LoginPageRef.Email));
            UserName.SendKeys(username + Keys.Enter);
           TimeWaitsHelper.ThreadSleep();
            TimeWaitsHelper.WaitForVisible(driver, By.XPath(FO_LoginPageRef. Password));
            IWebElement Password = driver.FindElement(By.XPath(FO_LoginPageRef.Password));
            Password.SendKeys(password + Keys.Enter);
            TimeWaitsHelper.ThreadSleep();
           // driver.FindElement(By.XPath(FO_LoginPageRef.ClickNext)).Click();
            TimeWaitsHelper.WaitForVisible(driver, By.Id(FO_LoginPageRef.NavDashboardLabel_id),30);
            TimeWaitsHelper.ThreadSleep();
        }
        
       
    }
}
