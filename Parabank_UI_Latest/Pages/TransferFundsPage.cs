using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Parabank_UI_Latest.Base;
using Parabank_UI_Latest.Utilities;
using System;

namespace Parabank_UI_Latest.Pages
{
    public class TransferFundsPage
    {
        private readonly IWebDriver driver;
        private readonly WaitHelper wait;

        private readonly By amountInput = By.XPath("//*[@id='amount']");
        private readonly By fromAccountSelect = By.Id("fromAccountId");
        private readonly By toAccountSelect = By.Id("toAccountId");
        private readonly By transferButton = By.XPath("//*[@id='transferForm']/div[2]/input");
        private readonly By resultHeader = By.XPath("//*[@id='showResult']/h1");
        private readonly By resultAmount = By.XPath("//*[@id='amountResult']");
        private readonly By transferFundLink = By.XPath("//*[@id='leftPanel']/ul/li[3]/a");

        public TransferFundsPage(IWebDriver driver)
        {
            this.driver = driver ?? throw new ArgumentNullException(nameof(driver));
            wait = new WaitHelper(driver);
        }

        public void TransferFunds(string amountValue, string fromAccountValue, string toAccountValue)
        {
            // Enter amount
            var amountEl = wait.WaitForElementVisible(amountInput);
            amountEl.Clear();
            amountEl.SendKeys(amountValue);
            Thread.Sleep(1000);

            // Select from account
            var fromEl = wait.WaitForElementVisible(fromAccountSelect);
            new SelectElement(fromEl).SelectByValue(fromAccountValue);

            // Select to account
            var toEl = wait.WaitForElementVisible(toAccountSelect);
            new SelectElement(toEl).SelectByValue(toAccountValue);

            // Click transfer and wait for result
            wait.WaitForElementClickable(transferButton).Click();
            wait.WaitForElementVisible(resultHeader); // ensure result is visible before continuing
            Thread.Sleep(1000);
            ExtentReportManager.test.Info("User successfully transferred funds.");
        }

        public string GetTransferCompleteMessage()
        {
            return wait.WaitForElementVisible(resultHeader).Text;
        }

        public string GetTransferAmount()
        {
            return wait.WaitForElementVisible(resultAmount).Text;
        }

        public void ClickOnTransferFundLink()
        {
            wait.WaitForElementVisible(transferFundLink).Click();
        }
    }
}
