using OpenQA.Selenium.Interactions;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HybridFramework.SeleniumUtility
{
    public static class ActionsHelper
    {
        public static void DragAndDrop(IWebDriver driver, IWebElement startingPos, IWebElement endingPos)
        {
            Actions draganddrop = new Actions(driver);
            draganddrop.DragAndDrop(startingPos, endingPos).Build().Perform();
        }
        public static void DragAndDropByPix(IWebDriver driver, IWebElement startingPos, int pix)
        {
            Actions actions = new Actions(driver);
            actions.MoveToElement(startingPos, 0, 0)
                  .ClickAndHold()
                  .MoveByOffset(pix, 0)
                  .Release()
                  .Build()
                  .Perform();
        }

        public static void DragAndDropByPix_Y_Axis(IWebDriver driver, IWebElement startingPos, int pix)
        {
            Actions actions = new Actions(driver);
            actions.MoveToElement(startingPos, 0, 0)
                  .ClickAndHold()
                  .MoveByOffset(0, pix)
                  .Release()
                  .Build()
                  .Perform();
        }
        public static void MoveToElementAndClick(IWebDriver driver, IWebElement webElement)
        {
            Actions ac = new Actions(driver);
            ac.MoveToElement(webElement)
                .Click().Build().Perform();
        }
        public static void MoveToElementAndClick_Send(IWebDriver driver, IWebElement webElement, string text)
        {
            Actions ac = new Actions(driver);
            ac.MoveToElement(webElement)
                .Click().Build().Perform();
            Thread.Sleep(1000);
            ac.MoveToElement(webElement)
               .SendKeys(text).Build().Perform();
        }

        public static void MoveToElement(IWebDriver driver, IWebElement webElement)
        {
            Actions ac = new Actions(driver);
            ac.MoveToElement(webElement)
                .Build().Perform();
        }

        public static void DoubleClick(IWebDriver driver, IWebElement webElement)
        {
            Actions ac = new Actions(driver);
            ac.MoveToElement(webElement)
                .DoubleClick().Build().Perform();
        }

        public static void RightClick(IWebDriver driver, IWebElement webElement)
        {
            Actions ac = new Actions(driver);
            ac.MoveToElement(webElement).ContextClick().Build().Perform();
        }

    }
}
