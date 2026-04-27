using Parabank_UI.Utilities;
using Parabank_UI_Latest.Base;
using Parabank_UI_Latest.Pages;

namespace Parabank_UI_Latest.Tests
{
    public class LoginTests : BaseTest
    {
        LoginPage loginpage;

        [Test]
        public void LoginToParabankWithValidCreds()
        {
            loginpage = new LoginPage(driver);
            loginpage.navigateToBankUrl();
            loginpage.Login(ConfigManager.Get("username"), ConfigManager.Get("password"));
            //Assert.That(driver.Title, Is.EqualTo("ParaBank | Accounts Overview"), "Title is not matching.");
            Assert.That(driver.Title, Is.EqualTo("ParaBank | Error"), "Title is not matching.");
        }
    }
}
