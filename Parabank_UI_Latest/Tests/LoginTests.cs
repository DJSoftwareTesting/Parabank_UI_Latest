using Parabank_UI.Utilities;
using Parabank_UI_Latest.Base;
using Parabank_UI_Latest.Pages;

namespace Parabank_UI_Latest.Tests
{
    public class LoginTests : BaseTest
    {
        LoginPage loginPage;
        DashboardPage dashboardPage;

        [Test]
        public void LoginToParabankWithValidCreds()
        {
            loginPage = new LoginPage(driver);
            loginPage.navigateToBankUrl();
            loginPage.Login(ConfigManager.Get("username"), ConfigManager.Get("password"));
            Assert.That(driver.Title, Is.EqualTo("ParaBank | Accounts Overview"), "Title is not matching.");
        }

        [Test]
        public void LoginToParabankWithInvalidPwd()
        {
            loginPage = new LoginPage(driver);
            loginPage.navigateToBankUrl();
            loginPage.Login(ConfigManager.Get("username"), "GBPassword");
            Assert.That(loginPage.getLoginErrorMessageText(), Is.EqualTo("The username and password could not be verified."), "Error message is not matching.");
            Assert.That(driver.Title, Is.EqualTo("ParaBank | Error"), "Title is not matching.");
        }

        [Test]
        public void LoginToParabankWithInvalidUid()
        {
            loginPage = new LoginPage(driver);
            loginPage.navigateToBankUrl();
            loginPage.Login("GBUsername", ConfigManager.Get("password"));
            Assert.That(loginPage.getLoginErrorMessageText(), Is.EqualTo("The username and password could not be verified."), "Error message is not matching.");
            Assert.That(driver.Title, Is.EqualTo("ParaBank | Error"), "Title is not matching.");
        }

        [Test]
        public void LoginToParabankWithoutCreds()
        {
            loginPage = new LoginPage(driver);
            loginPage.navigateToBankUrl();
            loginPage.Login("", "");
            Assert.That(loginPage.getLoginErrorMessageText(), Is.EqualTo("Please enter a username and password."), "Error message is not matching.");
            Assert.That(driver.Title, Is.EqualTo("ParaBank | Error"), "Title is not matching.");
        }

        [Test]
        public void VerifyPasswordMasking()
        {
            loginPage = new LoginPage(driver);
            loginPage.navigateToBankUrl();
            loginPage.password.SendKeys("testuser");
            Assert.That(loginPage.password.GetAttributeFromElement("type"), Is.EqualTo("password"), "Paswword is not masked.");
        }

        [Test]
        public void LogoutFromGuru99Bank()
        {
            loginPage = new LoginPage(driver);
            dashboardPage = new DashboardPage(driver);
            loginPage.navigateToBankUrl();
            loginPage.Login(ConfigManager.Get("username"), ConfigManager.Get("password"));
            Assert.That(driver.Title, Is.EqualTo("ParaBank | Accounts Overview"), "Title is not matching.");
            dashboardPage.Logout();
            Assert.That(driver.Title, Is.EqualTo("ParaBank | Welcome | Online Banking"), "Title is not matching.");
        }

        [Test]
        public void LogoutAndPressBackButton()
        {
            loginPage = new LoginPage(driver);
            dashboardPage = new DashboardPage(driver);
            loginPage.navigateToBankUrl();
            loginPage.Login(ConfigManager.Get("username"), ConfigManager.Get("password"));
            Assert.That(driver.Title, Is.EqualTo("ParaBank | Accounts Overview"), "Title is not matching.");
            dashboardPage.Logout();
            Assert.That(driver.Title, Is.EqualTo("ParaBank | Welcome | Online Banking"), "Title is not matching.");
            driver.Navigate().Back();
            Assert.That(driver.Title, Is.EqualTo("ParaBank | Welcome | Online Banking"), "Title is not matching.");
        }

    }
}
