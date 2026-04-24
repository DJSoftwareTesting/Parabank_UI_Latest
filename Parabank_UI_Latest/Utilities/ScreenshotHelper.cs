using OpenQA.Selenium;

namespace Parabank_UI_Latest.Utilities 
{
    public class ScreenshotHelper
    {
        public static string captureScreenshot(IWebDriver driver, string testName)
        {
            string folder = Path.Combine(ExtentReportManager.reportFolder, "Screenshots");
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }
            string path = Path.Combine(folder, testName + "_" + DateTime.Now.ToString("HHmmss") + ".jpg");
            var screenshot = ((ITakesScreenshot)driver).GetScreenshot();
            screenshot.SaveAsFile(path);
            return path;
        }
    }
}
