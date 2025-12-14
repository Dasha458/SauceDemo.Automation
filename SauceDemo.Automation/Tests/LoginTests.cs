using FluentAssertions;
using SauceDemo.Automation.Data;
using SauceDemo.Automation.Pages;
using SauceDemo.Automation.Utilities;
namespace SauceDemo.Automation.Tests
{
    [TestClass]
    public class LoginTests : TestBase
    {
        [TestMethod]
        [DataRow(BrowserType.Chrome)]
        [DataRow(BrowserType.Edge)]
        public void UC1_login_EmptyUsername_ShowsRequiredMessage(BrowserType browser)
        {
            InitializeDriver(browser);
            Logger.Info($"Starting UC1 with {browser}");

            var loginPage = new LoginPage(Driver);

            loginPage.ClickLoginButton();

            string errorMessage = loginPage.GetErrorMessage();
            errorMessage.Should().Be("Epic sadface: Username is required");
        }

        [TestMethod]
        [DataRow(BrowserType.Chrome)]
        [DataRow(BrowserType.Edge)]
        public void UC2_login_EmptyPassword_ShowsRequiredMessage(BrowserType browser)
        {
            InitializeDriver(browser);
            Logger.Info($"Starting UC2 with {browser}");

            var loginPage = new LoginPage(Driver);

            loginPage.EnterUsername("standard_user");
            loginPage.ClickLoginButton();

            string errorMessage = loginPage.GetErrorMessage();
            errorMessage.Should().Be("Epic sadface: Password is required");
        }

        [DataTestMethod]
        [DynamicData(nameof(TestDataProvider.ValidLoginCredentials), typeof(TestDataProvider), DynamicDataSourceType.Property)]
        public void UC3_Login_WithValidCredentials_IsSuccessful(BrowserType browser, string username, string password)
        {
            InitializeDriver(browser);
            Logger.Info($"Starting UC3 with {browser}");

            var loginPage = new LoginPage(Driver);

            loginPage.EnterCredentials(username, password);
            loginPage.ClickLoginButton();

            var productsPage = new ProductsPage(Driver);
            string actualTitle = productsPage.GetPageTitle();

            actualTitle.Should().Be("Products", "successful login should redirect to products page");
        }
    }
}