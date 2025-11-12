using SauceDemo.Automation.Utilities;

namespace SauceDemo.Automation.Data
{
    public class TestDataProvider
    {
        protected static readonly string validUsername = "standard_user";
        protected static readonly string validUsername2 = "problem_user";
        protected static readonly string validUsername3 = "performance_glitch_user";

        protected static readonly string validPassword = "secret_sauce";

        public static IEnumerable<object[]> ValidLoginCredentials
        {
            get
            {
                yield return new object[] { BrowserType.Chrome, validUsername, validPassword };
                yield return new object[] { BrowserType.Chrome, validUsername2, validPassword };
                yield return new object[] { BrowserType.Chrome, validUsername3, validPassword };

                yield return new object[] { BrowserType.Edge, validUsername, validPassword };
                yield return new object[] { BrowserType.Edge, validUsername2, validPassword };
                yield return new object[] { BrowserType.Edge, validUsername3, validPassword };
            }
        }
    }
}
