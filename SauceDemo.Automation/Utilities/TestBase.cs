using OpenQA.Selenium;
using System.Threading;
using NLog;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace SauceDemo.Automation.Utilities
{
    [TestClass]
    public abstract class TestBase
    {
        protected static readonly NLog.Logger Logger = LogManager.GetCurrentClassLogger();
        private static readonly ThreadLocal<IWebDriver> _driver = new ThreadLocal<IWebDriver>();

        protected IWebDriver Driver
        {
            get => _driver.Value;
            set => _driver.Value = value;
        }

        public TestContext TestContext { get; set; }

        private const string BaseUrl = "https://www.saucedemo.com/";

        [TestInitialize]
        public void Setup()
        {
            Logger.Info("Test initialization started.");

            BrowserType browser = GetBrowserFromTestContext();
            Logger.Info($"Selected browser: {browser}");

            try
            {
                var driverFactory = new WebDriverFactory();
                Driver = driverFactory.InitializeDriver(browser);

                Driver.Manage().Window.Maximize();
                Driver.Navigate().GoToUrl(BaseUrl);
                Logger.Info($"Browser launched and navigated to {BaseUrl}");
            }
            catch (Exception ex)
            {
                Logger.Fatal(ex, $"FATAL: Failed to initialize WebDriver for {browser}.");
                Assert.Fail($"Initialization error for {browser}: {ex.Message}");
            }
        }

        [TestCleanup]
        public void Teardown()
        {
            var status = TestContext.CurrentTestOutcome;
            Logger.Info($"Test finished with status: {status}");

            if (_driver.IsValueCreated)
            {
                try
                {
                    Driver.Quit();
                    _driver.Value = null;
                    Logger.Info("WebDriver instance closed.");
                }
                catch (Exception ex)
                {
                    Logger.Error(ex, "Error while closing the WebDriver.");
                }
            }
        }

        private BrowserType GetBrowserFromTestContext()
        {
            string testName = TestContext.TestName;

            if (testName.Contains("Edge"))
            {
                return BrowserType.Edge;
            }

            return BrowserType.Chrome;
        }
    }
}