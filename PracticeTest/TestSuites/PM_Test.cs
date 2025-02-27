using OpenQA.Selenium;

namespace PracticeTest.TestSuites
{
    [TestClass]
    public class UnitTest1
    {
        public static IWebDriver driver;
        [TestMethod]
        public void TestMethod1()
        {
            // add the google 
            // need to add thelogin part logic 
              IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.google.com");
            driver.Manage().Window.Maximize();
          driver.Navigate().GoToUrl("https://www.Amazon.com");            
        }
		 public static IWebDriver driver;
        [TestMethod]
        public void TestMethod1()
        {
            // add the google 
            // need to add thelogin part logic 
              IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.google.com");
            driver.Manage().Window.Maximize();
          driver.Navigate().GoToUrl("https://www.Amazon.com");            
        }
    }
}
