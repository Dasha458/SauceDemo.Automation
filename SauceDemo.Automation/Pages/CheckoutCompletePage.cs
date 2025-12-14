using OpenQA.Selenium;

namespace SauceDemo.Automation.Pages
{
    public class CheckoutCompletePage
    {
        private readonly IWebDriver _driver;

        private readonly By CompleteHeader = By.ClassName("complete-header");

        public CheckoutCompletePage(IWebDriver driver)
        { 
            _driver = driver;
        }

        public string GetHeaderText()
        {
            return _driver.FindElement(CompleteHeader).Text;
        }
    }
}
