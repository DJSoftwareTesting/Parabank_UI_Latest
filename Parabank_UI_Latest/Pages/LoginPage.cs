using OpenQA.Selenium;
using Parabank_UI.Utilities;
using Parabank_UI_Latest.Base;
using Parabank_UI_Latest.Utilities;

namespace Parabank_UI_Latest.Pages
{
    public class LoginPage
    {
        private IWebDriver driver;
        private WaitHelper wait;

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WaitHelper(driver);
        }

        private IWebElement homeBtn => driver.FindElement(By.LinkText("home"));
        private IWebElement aboutBtn => driver.FindElement(By.LinkText("about"));
        private IWebElement contactBtn => driver.FindElement(By.LinkText("contact"));
        IReadOnlyCollection<IWebElement> leftMenuItems => driver.FindElements(By.XPath("//ul[@class='leftmenu']/li"));
        private IWebElement username => driver.FindElement(By.XPath("//input[@name='username']"));
        public IWebElement password => driver.FindElement(By.XPath("//input[@type='password']"));
        private IWebElement loginBtn => driver.FindElement(By.XPath("//input[@value='Log In']"));
        private IWebElement forgotPassword => driver.FindElement(By.LinkText("Forgot login info?"));
        private IWebElement registerLink => driver.FindElement(By.LinkText("Register"));
        private IWebElement newCustomerName => driver.FindElement(By.Id("customer.firstName"));
        private IWebElement newCustomerLastName => driver.FindElement(By.Id("customer.lastName"));
        private IWebElement newCustomerAddress => driver.FindElement(By.Id("customer.address.street"));
        private IWebElement newCustomerCity => driver.FindElement(By.Id("customer.address.city"));
        private IWebElement newCustomerState => driver.FindElement(By.Id("customer.address.state"));
        private IWebElement newCustomerZipCode => driver.FindElement(By.Id("customer.address.zipCode"));
        private IWebElement newCustomerPhoneNumber => driver.FindElement(By.Id("customer.phoneNumber"));
        private IWebElement newCustomerSSN => driver.FindElement(By.Id("customer.ssn"));
        private IWebElement newCustomerUsername => driver.FindElement(By.Id("customer.username"));
        private IWebElement newCustomerPassword => driver.FindElement(By.Id("customer.password"));
        private IWebElement newCustomerConfirmPassword => driver.FindElement(By.Id("repeatedPassword"));
        private IWebElement registerBtn => driver.FindElement(By.XPath("//input[@value='Register']"));

        private By loginError = By.ClassName("error");

        #region Methods

        public void Login(string username, string password)
        {
            this.username.EnterText(username);
            this.password.EnterText(password);
            this.loginBtn.Click();
            ExtentReportManager.test.Info("User Successfully login to Parabank.");
        }

        public void LoginWithValidUser(string username, string password)
        {
            this.username.EnterText(username);
            this.password.EnterText(password);
            this.loginBtn.Click();
            if(driver.Title.Equals("ParaBank | Error"))
            {
                RegisterWithNewUser();
            }
            Thread.Sleep(2000);
            ExtentReportManager.test.Info("User Successfully login to Parabank.");
        }

        public void RegisterWithNewUser()
        {
            ClickOnRegister();
            wait.WaitForPageLoad();
            var newUser = UserManager.CreateNewUser();
            newCustomerName.SendKeys(newUser.FirstName);
            newCustomerLastName.SendKeys(newUser.LastName);
            newCustomerAddress.SendKeys(newUser.Address);
            newCustomerCity.SendKeys(newUser.City);
            newCustomerState.SendKeys(newUser.State);
            newCustomerZipCode.SendKeys(newUser.ZipCode);
            newCustomerPhoneNumber.SendKeys(newUser.Phone);
            newCustomerSSN.SendKeys(newUser.SSN);
            newCustomerUsername.SendKeys(newUser.Username);
            newCustomerPassword.SendKeys(newUser.Password);
            newCustomerConfirmPassword.SendKeys(newUser.Password);
            ConfigManager.UpdateCredentials(newUser.Username, newUser.Password);
            registerBtn.Click();
            Assert.That(driver.Title, Is.EqualTo("ParaBank | Customer Created"), "New user not created successfully.");
        }

        public void ClickOnForgotPassword()
        {
            this.forgotPassword.Click();
        }

        public void ClickOnRegister()
        {
            this.registerLink.Click();
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
            string url = ConfigManager.BaseUrl;
            driver.Navigate().GoToUrl(url);
        }

        public string getLoginErrorMessageText()
        {
            return wait.WaitForElementVisible(loginError).Text;
        }

        #endregion

    }
}
