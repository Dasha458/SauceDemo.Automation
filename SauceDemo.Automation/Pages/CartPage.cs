using OpenQA.Selenium;

namespace SauceDemo.Automation.Pages
{
    public class CartPage
    {
        private readonly IWebDriver _driver;
        private readonly By CheckoutButton = By.Id("checkout");
        private readonly By CartItems = By.ClassName("cart_item");

        public CartPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public void ClickCheckout()
        {
            _driver.FindElement(CheckoutButton).Click();
        }

        public int GetItemsCount()
        {
            return _driver.FindElements(CartItems).Count;
        }
    }
}
