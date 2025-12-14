using FluentAssertions;
using SauceDemo.Automation.Pages;
using SauceDemo.Automation.Utilities;

namespace SauceDemo.Automation.Tests
{
    [TestClass]
    public class CheckoutTests : TestBase
    {
        [TestMethod]
        [DataRow(BrowserType.Chrome)]
        [DataRow(BrowserType.Edge)]
        public void TC07_E2E_Checkout_Process_IsSuccessful(BrowserType browser)
        {
            InitializeDriver(browser);
            Logger.Info($"Starting TC07 E2E Checkout with {browser}");

            var loginPage = new LoginPage(Driver);
            loginPage.EnterCredentials("standard_user", "secret_sauce");
            loginPage.ClickLoginButton();
            
            var productsPage = new ProductsPage(Driver);
            productsPage.AddItemToCart();
            productsPage.GoToCart();

            var cartPage = new CartPage(Driver);

            int itemsCount = cartPage.GetItemsCount();

            itemsCount.Should().BeGreaterThan(0, "the cart should contain at least one item before checkout");

            cartPage.ClickCheckout();

            var checkoutPage = new CheckoutPage(Driver);
            checkoutPage.EnterShippingDetails("Test", "User", "12345");
            checkoutPage.ClickContinueButton();

            var overviewPage = new CheckoutOverviewPage(Driver);
            overviewPage.ClickFinishButton();

            var completePage = new CheckoutCompletePage(Driver);
            completePage.GetHeaderText().Should().Be("Thank you for your order!");
        }
    }
}
