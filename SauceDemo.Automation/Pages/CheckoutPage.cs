using OpenQA.Selenium;

namespace SauceDemo.Automation.Pages
{
    public class CheckoutPage
    {
        private readonly IWebDriver _driver;

        private readonly By FirstNameInput = By.Id("first-name");
        private readonly By LastNameInput = By.Id("last-name");
        private readonly By ZipInput = By.Id("postal-code");
        private readonly By ContinueButton = By.Id("continue");
        
        public CheckoutPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public void EnterShippingDetails(string firstName, string lastName, string zip)
        {
            _driver.FindElement(FirstNameInput).SendKeys(firstName);
            _driver.FindElement(LastNameInput).SendKeys(lastName);
            _driver.FindElement(ZipInput).SendKeys(zip);
        }

        public void ClickContinueButton()
        {
            _driver.FindElement(ContinueButton).Click();
        }
    }
}
