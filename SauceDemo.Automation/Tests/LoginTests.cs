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
            Logger.Info($"Starting UC1_login_EmptyUsername_ShowsRequiredMessage");

            if (Driver == null)
                throw new InvalidOperationException("Driver is not initialized.");

            var loginPage = new LoginPage(Driver);

            loginPage.EnterCredentials("testUser", "testPassword");
            Logger.Debug("Entered credentials.");
            loginPage.ClearCredentials();
            Logger.Debug("Cleared credentials.");
            loginPage.ClickLoginButton();
            Logger.Debug("Clicked login button.");

            string errorMessage = loginPage.GetErrorMessage();
            errorMessage.Should().Be("Epic sadface: Username and password do not match any user in this service");

            Logger.Info("Verified required username error message.");
        }

        [TestMethod]
        [DataRow(BrowserType.Chrome)]
        [DataRow(BrowserType.Edge)]
        public void UC2_login_EmptyPassword_ShowsRequiredMessage(BrowserType browser)
        {
            Logger.Info($"Starting UC2_login_EmptyPassword_ShowsRequiredMessage");

            if (Driver == null)
                throw new InvalidOperationException("Driver is not initialized.");

            var loginPage = new LoginPage(Driver);

            loginPage.EnterCredentials("testUser", "testPassword");
            Logger.Debug("Entered credentials.");
            loginPage.ClearPassword();
            Logger.Debug("Cleared password.");
            loginPage.ClickLoginButton();
            Logger.Debug("Clicked login button.");

            string errorMessage = loginPage.GetErrorMessage();
            errorMessage.Should().Be("Epic sadface: Username and password do not match any user in this service");

            Logger.Info("Verified required password error message.");
        }

        [DataTestMethod]
        [DynamicData(nameof(TestDataProvider.ValidLoginCredentials), typeof(TestDataProvider), DynamicDataSourceType.Property)]
        public void UC3_Login_WithValidCredentials_IsSuccessful(BrowserType broswer, string username, string password)
        {
            Logger.Info($"Starting UC2_Login_WithValidCredentials_IsSuccessful");

            if (Driver == null)
                throw new InvalidOperationException("Driver is not initialized.");

            var loginPage = new LoginPage(Driver);

            loginPage.EnterCredentials(username, password);
            Logger.Debug("Entered valid credentials.");

            loginPage.ClickLoginButton();
            Logger.Debug("Clicked login button.");

            var productsPage = new ProductsPage(Driver);
            string actualTitle = productsPage.GetPageTitle();

            actualTitle.Should().Be("Products", "the user should be redirected to the Products page after successful login");

            Logger.Info("Login successful, dashboard verified.");
        }
    }
}