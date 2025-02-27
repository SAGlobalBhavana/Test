using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HybridFramework.Browser.Browser;

namespace HybridFramework.Browser
{
    public class BrowserDriverFactory
    {
        public static IWebDriver CreatewebDriver(BrowserType browser, bool Headless,bool PrivateMode)
        {
            IWebDriver driver;
            switch(browser)
            {
                case BrowserType.Chrome:
                    
                    driver = new ChromeDriver(BrowserOption.ToChrome(Headless, PrivateMode));
                    break;
                case BrowserType.Edge:
                   
                    driver = new EdgeDriver(BrowserOption.ToEdge(Headless, PrivateMode));
                    break;
                case BrowserType.Firefox:
                  
                    driver = new FirefoxDriver(BrowserOption.ToFirefox(Headless, PrivateMode));
                    break;
                default:
                    throw new WebDriverException("Invalid browser choice");
            }
            return driver;

        }
        
    }
}
