using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace Parabank_UI_Latest.Utilities
{
    public class WaitHelper
    {
        private readonly IWebDriver driver;
        private readonly WebDriverWait wait;

        public WaitHelper(IWebDriver driver, int timeoutInSeconds = 10)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
        }

        public IWebElement WaitForElementVisible(By locator)
        {
            return wait.Until(ExpectedConditions.ElementIsVisible(locator));
        }

        public IWebElement WaitForElementClickable(By locator)
        {
            return wait.Until(ExpectedConditions.ElementToBeClickable(locator));
        }

        public bool WaitForElementExist(By locator)
        {
            return wait.Until(driver => driver.FindElements(locator).Count > 0);
        }

        public void WaitForPageLoad()
        {
            wait.Until(driver => ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete"));
        }
    }
}