using Parabank_UI.Utilities;
using Parabank_UI_Latest.Base;
using Parabank_UI_Latest.Pages;
namespace Parabank_UI_Latest.Tests
{
    public class TransferFundsTests : BaseTest
    {
        LoginPage loginPage;
        TransferFundsPage transferFundsPage;
        [Test]
        public void FundTransfer()
        {
            loginPage = new LoginPage(driver);
            transferFundsPage = new TransferFundsPage(driver);
            loginPage.navigateToBankUrl();
            loginPage.Login(ConfigManager.Get("username"), ConfigManager.Get("password"));
            Assert.That(driver.Title, Is.EqualTo("ParaBank | Accounts Overview"), "Title is not matching.");
            transferFundsPage.ClickOnTransferFundLink();
            transferFundsPage.TransferFunds("100", "22890", "22890");
            Console.WriteLine(transferFundsPage.GetTransferCompleteMessage());
            Assert.That(transferFundsPage.GetTransferCompleteMessage(), Is.EqualTo("Transfer Complete!"), "Transfer complete message is not matching.");
            Assert.That(transferFundsPage.GetTransferAmount(), Is.EqualTo("$100.00"), "Transfer complete message is not matching.");
        }
    }
}
