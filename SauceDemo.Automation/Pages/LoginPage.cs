using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SauceDemo.Automation.Pages
{
    public class LoginPage
    {
        private readonly By UsernameInput = By.XPath("//input[@id='user-name']");
        private readonly By PasswordInput = By.XPath("//input[@id='password']");
        private readonly By LoginButton = By.XPath("//input[@id='login-button']");
        private readonly By ErrorMessage = By.XPath("//h3[@data-test='error']");
        private readonly IWebDriver _driver;

        public LoginPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public void EnterCredentials(string username, string password)
        {
            _driver.FindElement(UsernameInput).SendKeys(username);
            _driver.FindElement(PasswordInput).SendKeys(password);
        }

        public void ClearCredentials()
        {
            _driver.FindElement(UsernameInput).Clear();
            _driver.FindElement(PasswordInput).Clear();
        }

        public void ClearPassword()
        {
            _driver.FindElement(PasswordInput).Clear();
        }

        public void ClickLoginButton()
        {
            _driver.FindElement(LoginButton).Click();
        }

        public string GetErrorMessage()
        {
            return _driver.FindElement(ErrorMessage).Text;
        }
    }
}