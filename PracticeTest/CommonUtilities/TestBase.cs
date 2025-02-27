using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;
using HybridFramework.Browser;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static HybridFramework.Browser.Browser;
using AventStack.ExtentReports.Reporter.Configuration;

using System.Net;
using System.Threading;
using System.IO;
using AventStack.ExtentReports.Model;
using System.Runtime.Remoting.Contexts;
using EmpowerApps.SeleniumUtility;
using System.Linq.Expressions;
using System.Diagnostics;
using HybridFramework.Reusable_Functions.D365FO;
//[assembly: Parallelize(Workers = 2, Scope = ExecutionScope.MethodLevel)]

namespace HybridFramework.ComonUtilities
{
    [TestClass]
    public class TestBase
    {
        public static BrowserType browserType = (BrowserType)Enum.Parse(typeof(BrowserType), ConfigurationManager.AppSettings["BrowserType"]);
        public static bool headless = bool.Parse(ConfigurationManager.AppSettings["HeadlessMode"]);
        public static bool Private = bool.Parse(ConfigurationManager.AppSettings["PrivateMode"]);
       // public static bool MaximizeBrowser = bool.Parse(ConfigurationManager.AppSettings["Maximize"]);
        public  static IWebDriver driver;
       // public static WebClient client;
        protected static  ExtentReports Extent;
        protected static ExtentTest Test;
        public static string AssemblyName;
        public static string testResultsPath;
        public static string screenshotsPath;
        public TestContext TestContext { get; set; }

        // F&O 
        public static String FO_URL;
        public static string FO_Username;
        public static string FO_Password;


        [AssemblyInitialize]
        public static void AssemblyInitialize(TestContext context)
        {
            // AssemblyName = Assembly.GetExecutingAssembly().GetName().Name;
            //var dir = context.TestDir + "\\";
            //const string fileName = "report.html";
            KillChromeDriverProcesses();
            //AssemblyName = Assembly.GetExecutingAssembly().GetName().Name;
            string timeStamp = DateTime.Now.ToString("dd-MM-yyyy HH-mm-ss");
            string reportFolder = "Test Report -" + timeStamp;
            var dir = AppDomain.CurrentDomain.BaseDirectory.Replace("\\bin\\Debug", "");
            Directory.CreateDirectory(dir + "\\Test Results\\");
            Directory.CreateDirectory(dir + "\\Test Results\\" + reportFolder);
            Directory.CreateDirectory(dir + "\\Test Results\\" + reportFolder + "\\Screenshots");
            testResultsPath = dir + "\\Test Results\\" + reportFolder + "\\";
            screenshotsPath = dir + "\\Test Results\\" + reportFolder + "\\Screenshots\\";
            string reportFileName = $"Report_{timeStamp}.html";
           // File.Copy(dirPath, Path.Combine(dirPath, "Report_Copy.html"), true);
            var htmlReporter = new ExtentHtmlReporter(testResultsPath);
            htmlReporter.Config.DocumentTitle = $"Test Results: {DateTime.Now:MM/dd/yyyy h:mm tt}";
            //htmlReporter.Config.ReportName = context.FullyQualifiedTestClassName;
            htmlReporter.Config.ReportName = "sa.global";
            htmlReporter.Config.Theme = Theme.Dark;
            Extent = new ExtentReports();
            Extent.AttachReporter(htmlReporter);
            ClassInitialize();

        }

        public static void ClassInitialize()
        {

            // FO Credentials
            FO_URL = ConfigurationManager.AppSettings["FOUrl"].ToString();
            FO_Username = ConfigurationManager.AppSettings["FOUsername"].ToString();
            FO_Password = ConfigurationManager.AppSettings["FOPassword"].ToString();

            // browser
            driver = BrowserDriverFactory.CreatewebDriver(browserType, headless, Private);
            driver.Manage().Window.Maximize();
        }

           [AssemblyCleanup]
        public static void AssemblyCleanup()
        {
            Extent.Flush();
            driver.Quit();
        }
       [TestInitialize]
        public void TestInitialize()
        {
       

            Test = Extent.CreateTest(TestContext.TestName).Info("Start Test");
        }


       [TestCleanup]
        public void TestCleanup()
        {

            try
            {
                var currentDateTime = TestContext.TestName + "_" + DateTime.Now.ToString("MM_dd_yyyy_mm_hh_ss");
                string filename = string.Format(currentDateTime + ".jpeg", TestContext.TestResultsDirectory);
                Screenshot screenshot = ((ITakesScreenshot)driver).GetScreenshot();
                screenshot.SaveAsFile(filename, ScreenshotImageFormat.Jpeg);
                Thread.Sleep(1000);
                TestContext.AddResultFile(filename);
                //driver.Quit();
            }
            catch(Exception ex) 
            {
             /*   Test.Fail("Test Failed: " + ex.Message);
                throw;*/
            }

            switch (TestContext.CurrentTestOutcome)
            {

                case UnitTestOutcome.Error:
                    Test.Fail("Test Failed - System Error");
                    AddScreenshot("Test Failed - System Error", TestContext);
                    break;
                case UnitTestOutcome.Passed:
                    Test.Pass("Test Passed");
                    AddScreenshot("Passed", TestContext);
                    break;
                case UnitTestOutcome.Failed:
                    Test.Fail("Test Failed");
                    AddScreenshot("Fail", TestContext);
                    break;
                case UnitTestOutcome.Inconclusive:
                    Test.Fail("Test Failed - Inconclusive");
                    AddScreenshot("Test Failed - Inconclusive", TestContext);
                    break;
                case UnitTestOutcome.Timeout:
                    Test.Fail("Test Failed - Timeout");
                    AddScreenshot("Test Failed - Timeout", TestContext);
                    break;
                case UnitTestOutcome.Aborted:
                    Test.Fail("Test Failed - Aborted / Not Runnable");
                    AddScreenshot("Test Failed - Aborted / Not Runnable", TestContext);
                    break;
                case UnitTestOutcome.InProgress:
                    Test.Fail("Test Failed - Aborted / Not Runnable");
                    AddScreenshot("Test Failed - Aborted / Not Runnable", TestContext);
                    break;
                case UnitTestOutcome.Unknown:
                    Test.Fail("Test Failed - Aborted / Not Runnable");
                    AddScreenshot("Test Failed - Aborted / Not Runnable", TestContext);
                    break;
                default:
                    Test.Fail("Test Failed - Unknown");
                    AddScreenshot("Test Failed - Unknown", TestContext);
                    break;
            }
          //  driver.Quit();
        }

        public void AddScreenshot(string title,TestContext TestContext )
        {
            string timeStamp = DateTime.Now.ToString("dd-MM-yyyy HH-mm-ss");
            String name = TestContext.TestName + " _ " + timeStamp;
            var filePath = Path.Combine(screenshotsPath, $"{name}.png");
            Screenshot screenshot = ((ITakesScreenshot)driver).GetScreenshot();
            screenshot.SaveAsFile(filePath, ScreenshotImageFormat.Png);
            Test.Info(title + "", MediaEntityBuilder.CreateScreenCaptureFromPath(filePath).Build());

            // Screenshot Adding to console
            TestContext.AddResultFile(filePath);

        }


        public static void AddScreenshot(string title, TestContext TestContext,string Filepath)
        {
            string timeStamp = DateTime.Now.ToString("dd-MM-yyyy HH-mm-ss");
            String name = TestContext.TestName + " _ " + timeStamp;
            var filePath = Path.Combine(screenshotsPath, $"{name}.png");
            Screenshot screenshot = ((ITakesScreenshot)driver).GetScreenshot();
            screenshot.SaveAsFile(filePath, ScreenshotImageFormat.Png);
            Test.Info(title + "", MediaEntityBuilder.CreateScreenCaptureFromPath(filePath).Build());

            // Screenshot Adding to console
            TestContext.AddResultFile(filePath);

        }


        public static void KillChromeDriverProcesses()
        {
            Process[] chromeDriverProcesses = Process.GetProcessesByName("chromedriver.exe");

            foreach (var process in chromeDriverProcesses)
            {
                process.Kill(); // Terminate the process
            }
        }

    }
}
