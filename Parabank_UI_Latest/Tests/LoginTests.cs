using Parabank_UI.Utilities;
using Parabank_UI_Latest.Base;
using Parabank_UI_Latest.Pages;
using NUnit.Framework;

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
            Console.WriteLine(driver.Title);
            //Assert.AreEqual(driver.Title, "ParaBank | Error", "Title is not matching.");
            //Assert.AreEqual(driver.Title, "ParaBank | Accounts Overvie", "Title is not matching." );

        }
    }
}
