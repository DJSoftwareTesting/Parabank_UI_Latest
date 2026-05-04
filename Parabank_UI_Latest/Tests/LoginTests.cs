using Parabank_UI.Utilities;
using Parabank_UI_Latest.Base;

namespace Parabank_UI_Latest.Tests
{
    public class LoginTests : BaseTest
    {
        [Test]
        public void LoginToParabankWithValidCreds()
        {
            ParabankUI.Login.navigateToBankUrl();
            ParabankUI.Login.LoginWithValidUser(ConfigManager.Username, ConfigManager.Password);
            Assert.That(driver.Title, Is.EqualTo("ParaBank | Accounts Overview"), "Title is not matching.");
        }

        [Test]
        public void LoginToParabankWithInvalidPwd()
        {
            ParabankUI.Login.navigateToBankUrl();
            ParabankUI.Login.Login(ConfigManager.Username, "GBPassword");
            Assert.That(ParabankUI.Login.getLoginErrorMessageText(), Is.EqualTo("The username and password could not be verified."), "Error message is not matching.");
            Assert.That(driver.Title, Is.EqualTo("ParaBank | Error"), "Title is not matching.");
        }

        [Test]
        public void LoginToParabankWithInvalidUid()
        {
            ParabankUI.Login.navigateToBankUrl();
            ParabankUI.Login.Login("GBUsername", ConfigManager.Password);
            Assert.That(ParabankUI.Login.getLoginErrorMessageText(), Is.EqualTo("The username and password could not be verified."), "Error message is not matching.");
            Assert.That(driver.Title, Is.EqualTo("ParaBank | Error"), "Title is not matching.");
        }

        [Test]
        public void LoginToParabankWithoutCreds()
        {
            ParabankUI.Login.navigateToBankUrl();
            ParabankUI.Login.Login("", "");
            Assert.That(ParabankUI.Login.getLoginErrorMessageText(), Is.EqualTo("Please enter a username and password."), "Error message is not matching.");
            Assert.That(driver.Title, Is.EqualTo("ParaBank | Error"), "Title is not matching.");
        }

        [Test]
        public void VerifyPasswordMasking()
        {
            ParabankUI.Login.navigateToBankUrl();
            ParabankUI.Login.password.SendKeys("testuser");
            Assert.That(ParabankUI.Login.password.GetAttributeFromElement("type"), Is.EqualTo("password"), "Paswword is not masked.");
        }

        [Test]
        public void LogoutFromParabankBank()
        {
            ParabankUI.Login.navigateToBankUrl();
            ParabankUI.Login.Login(ConfigManager.Username, ConfigManager.Password);
            Assert.That(driver.Title, Is.EqualTo("ParaBank | Accounts Overview"), "Title is not matching.");
            ParabankUI.Dashboard.Logout();
            Assert.That(driver.Title, Is.EqualTo("ParaBank | Welcome | Online Banking"), "Title is not matching.");
        }

        [Test]
        public void LogoutAndPressBackButton()
        {
            ParabankUI.Login.navigateToBankUrl();
            ParabankUI.Login.Login(ConfigManager.Username, ConfigManager.Password);
            Assert.That(driver.Title, Is.EqualTo("ParaBank | Accounts Overview"), "Title is not matching.");
            ParabankUI.Dashboard.Logout();
            Assert.That(driver.Title, Is.EqualTo("ParaBank | Welcome | Online Banking"), "Title is not matching.");
            driver.Navigate().Back();
            Assert.That(driver.Title, Is.EqualTo("ParaBank | Welcome | Online Banking"), "Title is not matching.");
        }

    }
}
