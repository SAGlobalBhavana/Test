using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HybridFramework.SeleniumUtility
{
    public static class JSExecutorHelper
    {

        public static void ClickOnWebElement(IWebDriver driver, IWebElement element)
        {
            IJavaScriptExecutor executor1 = (IJavaScriptExecutor)driver;
            executor1.ExecuteScript("arguments[0].click();", element);
        }

        public static void scrollByVisibleWebElement(IWebDriver driver, IWebElement element)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].scrollIntoView();", element);
          //.  js.ExecuteScript("arguments[0].scrollIntoView(true);", element);
        }
        public static void scrollToRightByPixels(IWebDriver driver, int scrollAmount, IWebElement element)
        {
            ((IJavaScriptExecutor)driver).ExecuteScript($"arguments[0].scrollLeft += {scrollAmount};", element);
        }

        public static void scrollToLeftByPixels(IWebDriver driver, IWebElement element, int scrollAmount)
        {
            ((IJavaScriptExecutor)driver).ExecuteScript($"arguments[0].scrollLeft -= {scrollAmount};", element);
        }

        public static void ScrollToTop(IWebDriver driver)
        {
            ((IJavaScriptExecutor)driver).ExecuteScript("window.scrollTo(0, 0);");
        }

        public static void ScrollToBottom(IWebDriver driver)
        {
            ((IJavaScriptExecutor)driver).ExecuteScript( "window.scrollTo(0, document.body.scrollHeight);");
        }

        public static void OpenNewTab(IWebDriver driver)
        {
            IJavaScriptExecutor executor1 = (IJavaScriptExecutor)driver;
            executor1.ExecuteScript("window.open();");
        }

    }
}
