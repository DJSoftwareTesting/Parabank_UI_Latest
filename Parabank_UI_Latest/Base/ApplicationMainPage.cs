using OpenQA.Selenium;
using Parabank_UI_Latest.Pages;

namespace Parabank_UI_Latest.Base
{
    public class ApplicationMainPage
    {

        private readonly IWebDriver driver;

        private LoginPage loginPage;
        private DashboardPage dashboardPage;


        public ApplicationMainPage(IWebDriver driver)
        {
            this.driver = driver;
        }


        public LoginPage Login
        {
            get
            {
                if (loginPage == null) { loginPage = new LoginPage(driver); }
                return loginPage;
            }
        }

        public DashboardPage Dashboard
        {
            get
            {
                if (dashboardPage == null) { dashboardPage = new DashboardPage(driver); }
                return dashboardPage;
            }
        }
    }
}
