using AventStack.ExtentReports.MarkupUtils;
using AventStack.ExtentReports;
using EmpowerApps.SeleniumUtility;
using HybridFramework.ComonUtilities;
using HybridFramework.SeleniumUtility;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static HybridFramework.Reusable_Functions.D365FO.FO_ElementRef;

namespace HybridFramework.Reusable_Functions.D365FO
{
    public  class FO_Reusable : TestBase
    {
        /// <summary>
        /// This function is used to wait until popup of 'Please wait. We're processing your request.' is disappeared/cleared
        /// 
        /// </summary>
        /// <param name="timeInseconds", value = "seconds" ></param>

        public static void WaitForPleaseWaitBlockingMsgToBeCleared(int timeInseconds)
        {
            Thread.Sleep(2000);
            TimeWaitsHelper.WaitForInvisible(driver,By.XPath(FO_CommonRef.PleaseWaitBlockingMessage), timeInseconds);
            Thread.Sleep(1000);
        }

        /// <summary>
        /// This function is used to wait until Processing operation popup is disappeared/cleared
        /// </summary>
        /// <param name="timeInseconds", value = " seconds"></param>

        public static void waitForProcessOperationToBeCleared(int timeInseconds)
        {
            Thread.Sleep(3000);
            TimeWaitsHelper.WaitForInvisible(driver,By.XPath(FO_CommonRef.ProcessingOperation), timeInseconds);
            Thread.Sleep(1000);
        }

        public void closeCurrentScreenPage()
        {
            TimeWaitsHelper.WaitForClickable(driver, By.XPath(FO_CommonRef.CloseButtonsOnAllScreens), 10);
            IList<IWebElement> closeButtons = driver.FindElements(By.XPath(FO_CommonRef.CloseButtonsOnAllScreens));
            int count = closeButtons.Count;
            Console.WriteLine("count = " + count);
            closeButtons[count - 1].Click();
            Thread.Sleep(2000);
        }

        public void closeAllScreenPages()
        {
            TimeWaitsHelper.WaitForClickable(driver, By.XPath(FO_CommonRef.CloseButtonsOnAllScreens), 10);
            IList<IWebElement> closeButtons = driver.FindElements(By.XPath(FO_CommonRef.CloseButtonsOnAllScreens));
            int count = closeButtons.Count - 1;
            Console.WriteLine("count = " + count);
            for (int i = count; i >= 0; i--)
            {
                closeButtons[i].Click();
                Thread.Sleep(2000);
            }
        }

        public void ClickRefreshButtonOnCurrentPage()
        {
            TimeWaitsHelper.WaitForClickable(driver, By.XPath(FO_CommonRef.RefreshButton), 20);
            try
            {
                driver.FindElement(By.XPath(FO_CommonRef.RefreshButton)).Click();
                Thread.Sleep(5000);
            }
            catch (Exception ex)
            {

                //driver.WaitUntilClickable(By.XPath(CommonRef.RefreshButton)).Click();

                //TimeWaitsHelper.explicitlyWaitElementToBeClickable(driver, 40, "xpath", CommonRef.RefreshButton);
                //driver.WaitUntilClickable(By.XPath(CommonRef.RefreshButton)).Click();

                Thread.Sleep(1000);
            }


        }

        public void sortColumnByText(string ColumnXpath, string TextBox, string TextValue, string ApplyButton)
        {
            TimeWaitsHelper.WaitForClickable(driver,By.XPath(ColumnXpath),10);
            driver.FindElement(By.XPath(ColumnXpath)).Click();
            TimeWaitsHelper.WaitForVisible(driver, By.XPath(TextBox), 50);
            IList<IWebElement> textBox = driver.FindElements(By.XPath(TextBox));
            int count = textBox.Count;
            textBox[count - 1].SendKeys(TextValue);
            //  driver.WaitUntilAvailable(By.XPath(TextBox)).SendKeys(TextValue);
            try
            {
                driver.FindElement(By.XPath(ApplyButton)).Click();

            }
            catch (Exception ex)
            {
                IList<IWebElement> applyButton = driver.FindElements(By.XPath(FO_CommonRef.ApplyFilterButton_2));
                applyButton[applyButton.Count - 1].Click();
            }


        }

        /// <summary>
        /// This function is used to sort the column from newest to oldest.
        /// </summary>
        /// <param name="ColumnXpath"></param>        
        public void sortColumnByNewestToOldest(string ColumnXpath)
        {
            TimeWaitsHelper.WaitForVisible(driver,By.XPath(ColumnXpath),10);
            driver.FindElement(By.XPath(ColumnXpath)).Click();
            TimeWaitsHelper.WaitForClickable(driver, By.XPath(FO_CommonRef.SortNewestToOldest), 10);
            driver.FindElement(By.XPath(FO_CommonRef.SortNewestToOldest)).Click();
        }


        /// <summary>
        /// This function is used to sort the column from  oldest to newest .
        /// </summary>
        /// <param name="ColumnXpath"></param>
        public void sortColumnByOldestToNewest(string ColumnXpath)
        {
            TimeWaitsHelper.WaitForVisible(driver, By.XPath(ColumnXpath), 10);
            driver.FindElement(By.XPath(ColumnXpath)).Click();
            TimeWaitsHelper.WaitForClickable(driver, By.XPath(FO_CommonRef.SortOldestToNewest), 10);
            driver.FindElement(By.XPath(FO_CommonRef.SortOldestToNewest)).Click();
        }

        /// <summary>
        /// This function is used to sort the column from  oldest to newest .
        /// </summary>
        /// <param name="ColumnXpath"></param>
        public void sortColumnBy_ZToA(string ColumnXpath)
        {
            TimeWaitsHelper.WaitForVisible(driver, By.XPath(ColumnXpath), 10);
            driver.FindElement(By.XPath(ColumnXpath)).Click();
            TimeWaitsHelper.WaitForClickable(driver, By.XPath(FO_CommonRef.SortZToA), 10);
            driver.FindElement(By.XPath(FO_CommonRef.SortZToA)).Click();

        }

        /// <summary>
        /// This function is used to sort the column from  A  to Z .
        /// </summary>
        /// <param name="ColumnXpath"></param>
        public void sortColumnBy_AToZ(string ColumnXpath)
        {
            TimeWaitsHelper.WaitForVisible(driver, By.XPath(ColumnXpath), 10);
            driver.FindElement(By.XPath(ColumnXpath)).Click();
            TimeWaitsHelper.WaitForClickable(driver, By.XPath(FO_CommonRef.SortAToZ), 10);
            driver.FindElement(By.XPath(FO_CommonRef.SortAToZ)).Click();
        }

        /// <summary>
        /// This function is designed for inset a column in  grid as per field and table
        /// </summary>
        /// <param name="fieldName"></param>
        /// <param name="tableValue"></param>
        public void InsertColumnsInGrid(string fieldName, string tableValue = null)
        {
            // Click on More options  and click on Insert column option
            TimeWaitsHelper.WaitForVisible(driver,By.XPath(FO_CommonRef.GridOptions_More),10);
            driver.FindElement(By.XPath(FO_CommonRef.GridOptions_More)).Click();
            TimeWaitsHelper.WaitForVisible(driver, By.XPath(FO_CommonRef.InsertColumn_More), 10);
            driver.FindElement(By.XPath(FO_CommonRef.InsertColumn_More)).Click();

            // sort field column with required values
            TimeWaitsHelper.WaitForVisible(driver, By.XPath(FO_CommonRef.ColumnField_InsertColumnsPopup), 10);
            sortColumnByText(FO_CommonRef.ColumnField_InsertColumnsPopup, FO_CommonRef.FilterFieldTextBox, fieldName, FO_CommonRef.ApplyFilterButton);

            // If need to sort the table column then sort with value 
            if (tableValue != null)
            {
                sortColumnByText(FO_CommonRef.ColumnTable_InsertColumnsPopup, FO_CommonRef.FilterFieldTextBox, tableValue, FO_CommonRef.ApplyFilterButton);
            }

            // select check box and click on update button
            TimeWaitsHelper.WaitForVisible(driver, By.XPath(FO_CommonRef.CheckBox_InsertColumnsPopup), 10);
            driver.FindElement(By.XPath(FO_CommonRef.CheckBox_InsertColumnsPopup)).Click();
            driver.FindElement(By.XPath(FO_CommonRef.OKButton_OK)).Click();
            Thread.Sleep(2000);
        }

        /// <summary>
        /// This function is used to Expand Any Tab
        /// </summary>
        public void ExpandTab(string ExpandFoTab)
        {
            TimeWaitsHelper.WaitForClickable(driver, By.XPath( ExpandFoTab),20);
            IWebElement genralTab = driver.FindElement(By.XPath(ExpandFoTab));
            JSExecutorHelper.scrollByVisibleWebElement(driver, genralTab);
            if (driver.FindElement(By.XPath(ExpandFoTab)).GetAttribute("aria-expanded").Equals("false"))
            {
                driver.FindElement(By.XPath(ExpandFoTab)).Click();
            }
        }


        public void ClickSaveButton()
        {
            try
            {
                TimeWaitsHelper.WaitForClickable(driver,By.Name( FO_LoginPageRef.Save_Name),40);
                driver.FindElement(By.Name(FO_LoginPageRef.Save_Name)).Click();
                WaitForPleaseWaitBlockingMsgToBeCleared(240);
            }
            catch (Exception ex)
            {
                try
                {
                    TimeWaitsHelper.WaitForClickable(driver, By.Name(FO_LoginPageRef.Save_Name));
                    driver.FindElement(By.Name(FO_LoginPageRef.Save_Name)).Click();
                    WaitForPleaseWaitBlockingMsgToBeCleared(240);
                }
                catch (Exception ex2) { }
            }

        }

        public void ClickLinesTab()
        {
            TimeWaitsHelper.WaitForClickable(driver, By.XPath(FO_CommonRef.LineView_header));
            IList<IWebElement> buttons = driver.FindElements(By.XPath(FO_CommonRef.LineView_header));
            int count = buttons.Count;
            Console.WriteLine("count = " + count);
            buttons[count - 1].Click();
            Thread.Sleep(2000);
        }

        public void ClickHeaderTab()
        {
            TimeWaitsHelper.WaitForClickable(driver, By.XPath(FO_CommonRef.HeaderView_header));
            IList<IWebElement> buttons = driver.FindElements(By.XPath(FO_CommonRef.HeaderView_header));
            int count = buttons.Count;
            Console.WriteLine("count = " + count);
            buttons[count - 1].Click();
            Thread.Sleep(2000);
        }

        public void ClickNewButton()
        {
            TimeWaitsHelper.WaitForClickable(driver, By.XPath(FO_CommonRef.NewButton));
            IList<IWebElement> closeButtons = driver.FindElements(By.XPath(FO_CommonRef.NewButton));
            int count = closeButtons.Count;
            Console.WriteLine("New Button count = " + count);
            closeButtons[count - 1].Click();
            Thread.Sleep(2000);
        }

        public void ClickEditButton()
        {
            TimeWaitsHelper.WaitForClickable(driver, By.XPath(FO_CommonRef.EditButton));
            IList<IWebElement> EditButtons = driver.FindElements(By.XPath(FO_CommonRef.EditButton));
            int ElemtRditCount = EditButtons.Count;
            Console.WriteLine("New Button count = " + ElemtRditCount);
            EditButtons[ElemtRditCount - 1].Click();
            Thread.Sleep(2000);
        }

        /// <summary>
        ///  This function used to Launch FO URL in last window. If Last window is not FO application then Open new window and Launch the FO URL
        /// </summary>
     /*   public void OpenNewTab_Launch_FO(bool login = true)
        {
            // check if multiple windows are present
            if (driver.WindowHandles.Count > 1)
            {
                driver.SwitchTo().Window(driver.WindowHandles.Last());
                xrmapp.ThinkTime(2000);
                string currentUrl = driver.Url;
                Console.WriteLine("New Window URL : " + currentUrl);
                if (currentUrl.Contains(FO_URL))
                {
                    driver.Navigate().Refresh();
                    TimeWaitsHelper.explicitlyWaitElementToBeClickable(driver, 180, "Id", LoginPageRef.NavDashboardLabel_id);

                    if (!driver.WaitUntilAvailable(By.Id(LoginPageRef.NavDashboardLabel_id)).Displayed)
                    {
                        driver.Navigate().GoToUrl(FO_URL);
                    }
                }
                else
                {
                    driver.Navigate().GoToUrl(FO_URL);
                }
            }

            else
            {
                if (login == false)
                {
                    Test.Log(Status.Info, MarkupHelper.CreateLabel("Open New Tab", ExtentColor.Orange));
                    xrmapp.ThinkTime(2000);
                    JSExecutorHelper.OpenNewTab(driver);
                    xrmapp.ThinkTime(2000);
                    //  LoginPage.loginFO(FO_URL, FO_Username, FO_Password);
                    xrmapp.ThinkTime(2000);
                    driver.SwitchTo().Window(driver.WindowHandles.Last());
                    driver.Navigate().GoToUrl(FO_URL);
                    TimeWaitsHelper.explicitlyWaitElementToBeClickable(driver, 15, "Name", LoginPageRef.Email);
                    IWebElement email_field = driver.WaitUntilAvailable(By.Name(LoginPageRef.Email));
                    if (email_field != null)
                    {
                        // TimeWaitsHelper.explicitlyWaitElementToBeClickable(driver, 60, "Name", LoginPageRef.Email);
                        IWebElement UserName = driver.WaitUntilClickable(By.Name(FOElementRef.LoginPageRef.Email));
                        UserName.SendKeys(FO_Username + Keys.Enter);
                        xrmapp.ThinkTime(2000);
                        TimeWaitsHelper.explicitlyWaitVisibilityOfWebElement(driver, 10, "xpath", FOElementRef.LoginPageRef.Password);
                        IWebElement Password = driver.WaitUntilClickable(By.XPath(FOElementRef.LoginPageRef.Password));
                        Password.SendKeys(FO_Password + Keys.Enter);
                        xrmapp.ThinkTime(2000);
                        driver.WaitUntilClickable(By.XPath(FOElementRef.LoginPageRef.ClickNext)).Click();
                        TimeWaitsHelper.explicitlyWaitVisibilityOfWebElement(driver, 100, "Id", FOElementRef.LoginPageRef.NavDashboardLabel_id);
                        xrmapp.ThinkTime(2000);
                    }
                }
                else
                {
                    // Open New tab and Launch FO 
                    Test.Log(Status.Info, MarkupHelper.CreateLabel("Open New Tab", ExtentColor.Orange));
                    xrmapp.ThinkTime(2000);
                    JSExecutorHelper.OpenNewTab(driver);
                    xrmapp.ThinkTime(2000);
                    driver.SwitchTo().Window(driver.WindowHandles.Last());
                    driver.Navigate().GoToUrl(FO_URL);
                    TimeWaitsHelper.explicitlyWaitElementToBeClickable(driver, 180, "Id", LoginPageRef.NavDashboardLabel_id);
                }

            }

        }*/

        public void RightClickAndClickOnViewDetail(string elementPath)
        {
            TimeWaitsHelper.WaitForClickable(driver, By.XPath(elementPath), 10);
            Actions ac = new Actions(driver);
            ac.MoveToElement(driver.FindElement(By.XPath(elementPath))).ContextClick().Build().Perform();
            Thread.Sleep(2000);
            driver.FindElement(By.XPath(FO_CommonRef.buttonLabelViewDetails)).Click();
            Thread.Sleep(2000);
        }

    }
}
