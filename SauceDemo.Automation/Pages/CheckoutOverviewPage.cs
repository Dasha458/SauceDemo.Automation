using OpenQA.Selenium;

namespace SauceDemo.Automation.Pages
{
    public class CheckoutOverviewPage
    {
        private readonly IWebDriver _driver;
        private readonly By FinishButton = By.Id("finish");

        public CheckoutOverviewPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public void ClickFinishButton()
        {
            _driver.FindElement(FinishButton).Click();
        }
    }
}
