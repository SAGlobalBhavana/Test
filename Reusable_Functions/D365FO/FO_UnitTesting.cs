using HybridFramework.Browser;
using HybridFramework.ComonUtilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HybridFramework.Reusable_Functions.D365FO
{
    [TestClass]
    public class FO_UnitTesting : TestBase
    {
        FO_LoginPage FO_LoginPage = new FO_LoginPage();

        [ClassInitialize]
        public static  void Initialize(TestContext context)
        {
            FO_LoginPage.loginFO(FO_URL, FO_Username, FO_Password);
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            driver.Quit();
        }

        [TestMethod]
        public void FO_Testing_Tester()
        {
        
            driver.Navigate().GoToUrl("https://www.google.com/");
       
        }

        [TestMethod]
        public void FO_Testing_Tester1()
        {
           
<<<<<<< HEAD
           // driver.Navigate().GoToUrl("https://www.facebook.com/");
=======

            //driver.Navigate().GoToUrl("https://www.facebook.com/");
>>>>>>> a76d7c272e73239ce5398f8b72f69c1dc11ae9ac
            driver.Navigate().GoToUrl("https://www.facebook.com/");
          
        }
    }
}
