using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Threading;
using NLog;
using SauceDemo.Automation.Constants;

namespace SauceDemo.Automation.Utilities
{
    [TestClass]
    public abstract class TestBase
    {
        protected static readonly NLog.Logger Logger = LogManager.GetCurrentClassLogger();
        private readonly ThreadLocal<IWebDriver> _driver = new ThreadLocal<IWebDriver>();

        protected IWebDriver? Driver
        {
            get
            {
                if (!_driver.IsValueCreated || _driver.Valur == null)
                {
                    throw new InvalidOperationException("WebDriver instance is not initialized. Call InitializeDriver() before using the Driver.");
                }
                return _driver.Value;
            }
            set => _driver.Value = value;
        }

        public TestContext TestContext { get; set; } = null!;

        protected void InitializeDriver(BrowserType browser)
        {
            var testName = TestContext?.TestName ?? "Unknown Test";
            Logger.Info($"[{testName}] Initializing driver for browser: {browser}");

            try
            {
                var driverFactory = new WebDriverFactory();
                var newDriver = driverFactory.InitializeDriver(browser);

                Driver = newDriver;

                if (Driver != null)
                {
                    Driver.Manage().Window.Maximize();

                    Driver.Navigate().GoToUrl(UrlConstants.BaseUrl);

                    Logger.Info($"Browser launched and navigated to {UrlConstants.BaseUrl}");
                }
            }
            catch (Exception ex)
            {
                Logger.Fatal(ex, $"FATAL; Failed to initialize WebDriver for {browser}.");
                CleanupDriver();
                throw;
            }
        }

        [TestCleanup]
        public void Teardown()
        {
            var status = TestContext?.CurrentTestOutcome.ToString() ?? "Unknown";
            Logger.Info($"Test finished with status: {status}");

            CleanupDriver();
        }

        private void CleanupDriver()
        { 
            if (_driver.IsValueCreated && _driver.Value != null)
            {
                try
                {
                    Logger.Info("Attempting to close WebDriver...");
                    _driver.Value.Quit();
                    _driver.Value.Dispose();
                }
                catch (Exception ex)
                {
                    Logger.Error(ex, "Error while closing the WebDriver.");
                }
                finally
                {
                    _driver.Value = null!;
                    Logger.Info("WebDriver instance closed.");
                }
            }
        }
    }
}