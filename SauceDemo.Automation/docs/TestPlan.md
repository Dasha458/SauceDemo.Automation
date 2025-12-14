Project Name	SauceDemo E-commerce Automation
Document Version	1.0
Author	Dariia
Date	11.12.2025
Status	Draft / Active

# Test Plan for SauceDemo E-commerce Automation

# 1. Introduction
This document describes the test strategy for the automated testing of the SauceDemo (Swag Labs) web application. 
Objective: The primary goal is to develop a robust test automation framework to reduce manual regression testing time,
ensure the stability of critical business flows (Login, Cart, Checkout), and integrate testing into the CI/CD pipeline.

# 2. Scope
2.1 In Scope
Functional UI testing of the following modules:

# 1. Authentication:

	Valid and Invalid Login scenarios.

	Logout functionality.

	Locked-out user verification.

# 2. Inventory (Products):

	Product display verification.

	UI elements validation (Images, Descriptions, Prices).

# 3. Shopping Cart:

	Adding items to the cart.

	Removing items from the cart.

	Cart badge counter validation.

# 4. Checkout Process (E2E):

	Checkout: Your Information (Input validation).

	Checkout: Overview (Total price calculation).

	Checkout: Complete (Order confirmation).

# 2.2 Out of Scope
	Performance Testing: Load and stress testing are not included.

	Security Testing: SQL Injection, XSS, etc. (except basic login validation).

	Visual Regression Testing: Pixel-perfect layout checks.

	Third-party Integrations: Functionality of external links (Twitter, Facebook, LinkedIn) is not tested beyond navigation.

	Mobile Application: Only the web version is tested.

# 3. Test Strategy

# 3.1 Test Levels
Smoke Test Suite: A minimal set of critical tests (Login + Add to Cart) to verify system stability. Triggered on every Pull Request.

Regression Suite: A comprehensive set of tests covering all in-scope functionalities. Triggered before releases.

# 3.2 Tools & TechnologiesToolPurpose
C# (.NET 8) Core programming language.
Selenium WebDriver Browser automation tool.
MSTest Test runner and framework.
FluentAssertions Assertion library for readable code.
WebDriverManager Automatic browser driver management.
GitHub Actions CI/CD pipeline for automated execution.
Allure Report Advanced test reporting with screenshots and logs.

# 3.3 Test Environment
Tests will be executed in the following configurations:

	OS: Windows 10/11 (Local), Ubuntu Latest (CI/GitHub Actions).

	Browsers:

		Google Chrome (Latest stable version).

		Microsoft Edge (Latest stable version).

	Target URL: https://www.saucedemo.com/

# 4.1 Entry Criteria
Testing activities can commence when:

	1. The Test Plan is approved.

	2. The Automation Framework is set up (BaseTest, Page Objects, Utilities).

	3. The Application Under Test (AUT) is accessible via the target URL.

# 4.2 Suspension Criteria
Testing will be suspended if:

	1. The application is down (HTTP 404/500 errors).

	2. A blocking defect prevents Login functionality.

# 4.3 Exit Criteria
Automation is considered complete for a release when:

	1. 100% of Smoke tests pass.

	2. >95% of Regression tests pass.

	3. No critical defects remain open.

# 5. Risks & Mitigation
Risk	Mitigation Strategy
DOM Changes: UI locators may change, breaking tests.	Use stable locators (id, data-test) and adhere to the Page Object Pattern for easy maintenance.
Test Flakiness: Tests may fail intermittently due to network/browser lag.	Implement Explicit Waits (WebDriverWait) and avoid Thread.Sleep. Use Retry Logic for CI runs.
Browser Updates: Driver incompatibility.	Use WebDriverManager to ensure driver versions match the browser.

# 6. Deliverables
The following artifacts will be produced:

	1. Source Code: Full automation framework hosted on GitHub.

	2. Test Reports: HTML Allure reports containing execution results, logs, and screenshots of failures.

	3. CI/CD Workflow: Configured YAML files for GitHub Actions.

	4. Defect Reports: Issues created in GitHub for any bugs found during automation.