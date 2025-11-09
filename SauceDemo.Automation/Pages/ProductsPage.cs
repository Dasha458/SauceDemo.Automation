using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SauceDemo.Automation.Pages
{
    public class ProductsPage
    {
        private readonly By Title = By.XPath("//span[@class='title']");

        private readonly IWebDriver _driver;
        public ProductsPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public string GetPageTitle()
        {
           return _driver.FindElement(Title).Text;
        }
    }
}
