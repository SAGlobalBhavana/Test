using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace EmpowerApps.SeleniumUtility
{
    public static class TimeWaitsHelper
    {
        /// <summary>
        /// This function is used to explicitly wait for Clickable of given WebElement in specified time
        /// Ex: TimeWaitsHelper.WaitForClickable(driver, By.XPath("Value"), 50);
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="locator"></param>
        /// <param name="seconds"></param>
        public static void WaitForClickable(IWebDriver driver, By locator, int seconds = 10)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(seconds));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(locator));
        }

        /// <summary>
        /// This function is used to explicitly wait for visibility of given WebElement in specified time
        /// Ex: TimeWaitsHelper.WaitForVisible(driver, By.XPath("Value"), 50);
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="locator"></param>
        /// <param name="seconds"></param>
        public static void WaitForVisible(IWebDriver driver, By locator, int seconds = 10)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(seconds));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(locator));
        }

        public static void WaitForInvisible(IWebDriver driver, By locator, int seconds = 10)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(seconds));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(locator));
        }

        /// <summary>
        /// This function is used to pauses the execution for a specified amount of time.
        /// </summary>
        /// <param name="seconds"></param>
        public static void ThreadSleep(int seconds = 2)
        {
           Thread.Sleep(TimeSpan.FromSeconds(seconds));
        }

        /// <summary>
        /// This function wait for up to specified amount of time the attribute of the element located by ('elementLocator') with the specified attribute name ("attributeName") has the expected value ("expectedValue")
        /// Ex: TimeWaitsHelper.WaitForAttributeValueToBe(driver, By.Id("UserName"), "value", "expected Value", 10);
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="elementLocator"></param>
        /// <param name="attributeName"></param>
        /// <param name="expectedValue"></param>
        /// <param name="timeSeconds"></param>
        public static void WaitForAttributeValueToBe(IWebDriver driver,  By elementLocator, string attributeName, string expectedValue, int timeSeconds = 10)
        {
            try
            {
                Thread.Sleep(1000);
                int wait = timeSeconds / 2;
                for (int i = 0; i < wait; i++)
                {
                    string actual = driver.FindElement(elementLocator).GetAttribute(attributeName);
                    if (actual != expectedValue)
                    {
                        Thread.Sleep(2000);
                    }
                    else
                    {
                        break;
                    }

                }
            }
            catch (Exception e) { Console.WriteLine(); }
        }
    }
}
