# Project: SauceDemo Login Flow Automation

This project automates the login functionality of SauceDemo using Selenium WebDriver, focusing on structured testing, parallel execution, and adherence to the Page Object Model (POM).

## Task Implementation Details

The following User Cases (UC) are implemented and fully covered by tests:

### UC-1: Test Login form with empty credentials
1. Type arbitrary credentials into "Username" and "Password" fields.
2. Clear the inputs using `loginPage.ClearCredentials()`.
3. Hit the "Login" button.
4. Validate error message: "Epic sadface: Username is required".

### UC-2: Test Login form with credentials by passing Username
1. Type arbitrary credentials into both fields.
2. Clear the "Password" input only using `loginPage.ClearPassword()`.
3. Hit the "Login" button.
4. Validate error message: "Epic sadface: Password is required".

### UC-3: Test Login form with credentials by passing Username & Password
1. Input accepted credentials (sourced via DynamicData).
2. Click on Login.
3. Validate the successful navigation by checking the dashboard title: "Products".

## Technical Stack and Best Practices

| Category | Requirement | Implementation |
| :--- | :--- | :--- |
| **Automation Tool** | Selenium WebDriver / MS Test | Primary framework choice. |
| **Browsers** | Chrome, Edge | Parallel execution enabled via `[DataRow]` and `[DynamicData]`. |
| **Locators** | XPath | All locators are relative XPath (e.g., `//input[@id='user-name']`). |
| **Assertions** | Fluent Assertion | Used for readable checks (e.g., `Should().Be()`). |
| **Structure** | POM / Abstract Factory [Optional] | Implemented in `Pages/` and `Utilities/WebDriverFactory.cs`. |
| **Logging** | NLog [Optional] | Integrated in `TestBase.cs` and utilized in all test methods. |
| **Data Provider** | DynamicData | Used for UC-3 parameterization. |