using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using Parabank_UI.Utilities;

namespace Parabank_UI_Latest.Base
{
    public class DriverFactory
    {
        public static IWebDriver CreateDriver(string browser)
        {
            return browser.ToLower() switch
            {
                "chrome" => CreateChromeDriver(),
                "firefox" => new FirefoxDriver(),
                "edge" => new EdgeDriver(),
                _ => throw new ArgumentException($"Browser '{browser}' not supported")
            };
        }

        private static IWebDriver CreateChromeDriver()
        {
            var options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            options.AddArgument("--disable-notifications");
            if (ConfigManager.IsHeadless) options.AddArgument("--headless=new");
            return new ChromeDriver(options);
        }
    }
}