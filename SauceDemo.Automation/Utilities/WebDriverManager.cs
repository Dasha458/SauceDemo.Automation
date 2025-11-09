using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using System;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace SauceDemo.Automation.Utilities
{
    public enum BrowserType
    {
        Chrome,
        Edge
    }

    internal class WebDriverFactory
    {
        public IWebDriver InitializeDriver(BrowserType browserType)
        {
            IWebDriver driver;

            var driverManager = new DriverManager();

            switch (browserType)
            {
                case BrowserType.Chrome:
                    driverManager.SetUpDriver(new ChromeConfig());
                    var chromeOptions = new ChromeOptions();
                    driver = new ChromeDriver(chromeOptions);
                    break;

                case BrowserType.Edge:
                    driverManager.SetUpDriver(new EdgeConfig());
                    var edgeOptions = new EdgeOptions();
                    driver = new EdgeDriver(edgeOptions);
                    break;

                default:
                    throw new NotSupportedException($"Browser type '{browserType}' is not supported.");
            }
            return driver;
        }
    }
}