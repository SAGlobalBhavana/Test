using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HybridFramework.Browser
{
    public static class BrowserOption
    {

        public static ChromeOptions ToChrome(bool Headless, bool PrivateMode)
        {
            var chromeOption = new ChromeOptions();
            if (Headless == true)
            {
                chromeOption.AddArgument("--window-size=1920,1080");
                chromeOption.AddArguments("--headless");

            }
            if (PrivateMode == true)
            {
                chromeOption.AddArguments("--incognito");
            }
           /* if (MaximizeBrowser == true)
            {
                chromeOption.AddArguments("--start-maximized"); ;
            }*/
            return chromeOption;
        }


        public static EdgeOptions ToEdge(bool Headless, bool PrivateMode)
        {
            var edgeOption = new EdgeOptions();
            if (Headless == true)
            {
                edgeOption.AddArguments("--window-size=1920,1080");
                edgeOption.AddArguments("--headless");
            }
            if (PrivateMode == true)
            {
                edgeOption.AddArguments("InPrivate");
            }
          /*  if (MaximizeBrowser == true)
            {
                edgeOption.AddArguments("--start-maximized"); ;
            }*/
            return edgeOption;
        }

        public static FirefoxOptions ToFirefox(bool Headless, bool PrivateMode)
        {
            var firefoxOptions = new FirefoxOptions();
            if (Headless == true)
            {
                firefoxOptions.AddArguments("--window-size=1920,1080");
                firefoxOptions.AddArgument("--headless");
            }
            if (PrivateMode == true)
            {
                firefoxOptions.AddArgument("-private");
            }
           /* if (MaximizeBrowser == true)
            {
                firefoxOptions.AddArguments("--start-maximized"); ;
            }*/
            return firefoxOptions;
        }
    }
}
