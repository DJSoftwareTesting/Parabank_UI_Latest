using OpenQA.Selenium;

namespace Parabank_UI_Latest.Base
{
    public static class BasePage
    {
        public static void EnterText(this IWebElement element, string text)
        {
            element.Clear();
            element.SendKeys(text);
        }

        public static string GetText(this IWebElement element)
        {
            return element.Text;
        }

        public static void ClickOnCheckbox(this IWebElement element, bool value)
        {
            if (!element.Selected)
            {
                element.Click();
            }
        }

        public static void ClickOnRadioButton(this IWebElement element, bool value)
        {
            ClickOnCheckbox(element, value);
        }

        public static string GetAttributeFromElement(this IWebElement element, string attributeName)
        {
            return element.GetAttribute(attributeName);
        }

        public static void AcceptAlertDialog(IWebDriver driver)
        {
            IAlert alert = driver.SwitchTo().Alert();
            alert.Accept();
        }

        public static void DismissAlertDialog(IWebDriver driver)
        {
            IAlert alert = driver.SwitchTo().Alert();
            alert.Dismiss();
        }

        public static string GetTextFromAlert(IWebDriver driver)
        {
            IAlert alert = driver.SwitchTo().Alert();
            return alert.Text;
        }
    }
}
