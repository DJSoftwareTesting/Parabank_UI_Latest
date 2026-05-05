using Parabank_UI.Utilities;
using Parabank_UI_Latest.Base;
using Parabank_UI_Latest.Pages;
namespace Parabank_UI_Latest.Tests
{
    public class TransferFundsTests : BaseTest
    {
        
        [Test]
        public void FundTransfer()
        {
            ParabankUI.Login.navigateToBankUrl();
            ParabankUI.Login.Login(ConfigManager.Username, ConfigManager.Password);           
            ParabankUI.TransferFunds.ClickOnTransferFundLink();
            ParabankUI.TransferFunds.TransferFunds("100", "26886", "26886");
            Console.WriteLine(ParabankUI.TransferFunds.GetTransferCompleteMessage());
            Assert.That(ParabankUI.TransferFunds.GetTransferCompleteMessage(), Is.EqualTo("Transfer Complete!"), "Transfer complete message is not matching.");
            Assert.That(ParabankUI.TransferFunds.GetTransferAmount(), Is.EqualTo("$100.00"), "Transfer complete message is not matching.");
        }
    }
}
