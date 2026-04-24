using OpenQA.Selenium;
using Parabank_UI.Utilities;
using Parabank_UI_Latest.Base;
using Parabank_UI_Latest.Utilities;

namespace Parabank_UI_Latest.Pages
{
    public class LoginPage
    {
        private IWebDriver driver;

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        private IWebElement homeBtn => driver.FindElement(By.LinkText("home"));
        private IWebElement aboutBtn => driver.FindElement(By.LinkText("about"));
        private IWebElement contactBtn => driver.FindElement(By.LinkText("contact"));
        IReadOnlyCollection<IWebElement> leftMenuItems => driver.FindElements(By.XPath("//ul[@class='leftmenu']/li"));
        private IWebElement username => driver.FindElement(By.XPath("//input[@name='username']"));
        private IWebElement password => driver.FindElement(By.XPath("//input[@type='password']"));
        private IWebElement loginBtn => driver.FindElement(By.XPath("//input[@value='Log In']"));
        private IWebElement forgotPassword => driver.FindElement(By.LinkText("Forgot login info?"));
        private IWebElement register => driver.FindElement(By.LinkText("Register"));


        #region Methods

        public void Login(string username, string password)
        {
            this.username.EnterText(username);
            this.password.EnterText(password);
            this.loginBtn.Click();
            ExtentReportManager.test.Info("User Successfully login to Parabank.");
        }

        public void ClickOnForgotPassword()
        {
            this.forgotPassword.Click();
        }

        public void ClickOnRegister()
        {
            this.register.Click();
        }

        public void ClickOnHome()
        {
            this.homeBtn.Click();
        }

        public void ClickOnAboutUs()
        {
            aboutBtn.Click();
        }

        public void ClickOnContactUs()
        {
            contactBtn.Click();
        }

        public void ClickOnLeftMenuItem(string menuItem)
        {
            var item = leftMenuItems.Where(eb => eb.Text.Equals(menuItem)).FirstOrDefault();
            item?.Click();
        }

        public void navigateToBankUrl()
        {
            string url = ConfigManager.Get("baseUrl");
            driver.Navigate().GoToUrl(url);
        }

        #endregion
    }
}
