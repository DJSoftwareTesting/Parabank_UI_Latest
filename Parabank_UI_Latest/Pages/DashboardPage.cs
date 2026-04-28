using OpenQA.Selenium;
using Parabank_UI.Utilities;
using Parabank_UI_Latest.Base;
using Parabank_UI_Latest.Utilities;

namespace Parabank_UI_Latest.Pages
{
    public class DashboardPage
    {
        private IWebDriver driver;

        public DashboardPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        private IWebElement logoutBtn => driver.FindElement(By.LinkText("Log Out"));

        public void Logout()
        {
            logoutBtn.Click();
        }

    }
}
