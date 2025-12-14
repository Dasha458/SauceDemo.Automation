using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SauceDemo.Automation.Pages
{
    public class ProductsPage
    {
        private readonly By Title = By.XPath("//span[@class='title']");
        private readonly By BurgerMenuButton = By.Id("react-burger-menu-btn");
        private readonly By LogoutLink = By.Id("logout_sidebar_link");
        private readonly By CartLink = By.ClassName("shopping_cart_link");
        private readonly By AddToCartButton = By.Id("add-to-cart-sauce-labs-backpack");
        
        private readonly IWebDriver _driver;
        public ProductsPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public string GetPageTitle()
        {
           return _driver.FindElement(Title).Text;
        }
        public void Logout()
        {
            _driver.FindElement(BurgerMenuButton).Click();
          
            WebDriverWait webDriverWait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
            webDriverWait.Until(driver => driver.FindElement(LogoutLink).Displayed);
           
            _driver.FindElement(LogoutLink).Click();
        }

        public void GoToCart()
        {
            _driver.FindElement(CartLink).Click();
        }

        public void AddItemToCart()
        {
            _driver.FindElement(AddToCartButton).Click();
        }
    }
}
