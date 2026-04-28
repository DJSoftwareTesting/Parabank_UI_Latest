using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using Parabank_UI.Utilities;
using Parabank_UI_Latest.Utilities;

namespace Parabank_UI_Latest.Base
{
    public class BaseTest
    {
        protected static IWebDriver driver;

        [OneTimeSetUp]
        public void ExtentReportSetup()
        {
            ExtentReportManager.Init();
        }

        [SetUp]
        public void Setup()
        {
            string browser = ConfigManager.Get("browser");
            driver = DriverFactory.CreateDriver(browser);
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(30);
            ExtentReportManager.test = ExtentReportManager.extent.CreateTest(TestContext.CurrentContext.Test.Name);
            ExtentReportManager.test.Info("Test Case started...");
        }

        [TearDown]
        public void Teardown()
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            if (status == TestStatus.Failed)
            {
                string path = ScreenshotHelper.captureScreenshot(driver, TestContext.CurrentContext.Test.Name);
                if (path != null)
                {
                    ExtentReportManager.test.Fail("Test Failed").AddScreenCaptureFromPath(path);
                }
            }
            else
            {
                ExtentReportManager.test.Pass("Test passed");
            }
            driver.Quit();
            driver.Dispose();
        }

        [OneTimeTearDown]
        public void ExtentFlush()
        {
            ExtentReportManager.Flush();
        }
    }
}