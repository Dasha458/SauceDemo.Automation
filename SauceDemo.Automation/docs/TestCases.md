# Test cases for SauceDemo automation
This document outlines the test cases planned for automating the SauceDemo application. The test cases cover various functionalities of the application to ensure its reliability and performance.

## Test Case 1: Verify successful user login
- **Objective**: Verify that a user can log in with valid credentials.
- **Preconditions**: User is on the login page.
- **Test Steps**:
  1. Enter standard_user in the Username field.
  2. Enter secret_sauce in the Password field.
  3. Click on the "Login" button.
- **Expected Result**:Expected Result: User is redirected to the Inventory page (/inventory.html). The page title "Products" is visible.
- **Postconditions**: User is logged in.
- **Priority**: High
- **Status**: Draft

## Test Case 2: Verify error message for invalid login
- **Objective**: Verify that a user cannot log in with invalid credentials.
- **Preconditions**: User is on the login page.
- **Test Steps**:
  1. Enter standard_user in the Username field.
  2. Enter secret_sauce in the Password field.
  3. Click on the "Login" button.
- **Expected Result**:An error message is displayed: "Epic sadface: Username and password do not match any user in this service".
- **Postconditions**: User remains on the login page.
- **Priority**: High
- **Status**: Draft

## Test Case 3: Verify message for a locked-out user
- **Objective**: Verify that a locked-out user cannot log in and receives the appropriate error message.
- **Preconditions**: User is on the login page.
- **Test Steps**:
  1. Enter locked_out_user in the Username field.
  2. Enter secret_sauce in the Password field.
  3. Click on the "Login" button.
- **Expected Result**: An error message is displayed: "Epic sadface: Sorry, this user has been locked out.".
- **Postconditions**: User remains on the login page.
- **Priority**: High
- **Status**: Draft
- 
## Test Case 4: Add item to cart
- **Objective**: Verify that a user can add a specific item to the shopping cart.
- **Preconditions**: User is logged in as standard_user and on the inventory page.
- **Test Steps**:
  1. Locate the item "Sauce Labs Backpack".
  2. Click on the "Add to Cart" button.
- **Expected Result**: The button text changes to "Remove". The shopping cart badge shows "1".
- **Postconditions**: Item is present in the shopping cart.
- **Priority**: Medium
- **Status**: Draft

## Test Case 5: Remove item from cart
- **Objective**: Verify that a user can remove an item from the shopping cart.
- **Preconditions**: User is logged in and has "Sauce Labs Backpack" in the cart.
- **Test Steps**:
  1. Click the "Shopping Cart" icon (top right).
  2. Click the "Remove" button next to "Sauce Labs Backpack".
- **Expected Result**: The item is removed from the list. The cart badge is hidden or empty.
- **Postconditions**: Item is no longer present in the shopping cart.
- **Priority**: Medium
- **Status**: Draft

## Test Case 6: Verify successful logout
- **Objective**: Verify that a logged-in user can log out correctly.
- **Preconditions**: User is logged in.
- **Test Steps**:
  1. Click the "Burger Menu" button (top left).
  2. Wait for the menu to expand.
  3. Click the "Logout" link.
- **Expected Result**: User is redirected to the Login page. The "Login" button is visible.
- **Postconditions**: User is logged out.
- **Priority**: Medium
- **Status**: Draft

## Test Case 7: Complete checkout process
- **Objective**: Verify that a user can successfully purchase a product.
- **Preconditions**: User is logged in, has at least one item in the cart.
- **Test Steps**:
  1. Click the "Shopping Cart" icon.
  2. Click the "Checkout" button.
  3. Enter "John" in the First Name field.
  4. Enter "Doe" in the Last Name field.
  5. Enter "12345" in the Postal Code field.
  6. Click the "Continue" button.
  7. Click the "Finish" button on the Overview page.
- **Expected Result**: The "Checkout: Complete!" page is displayed with the message "Thank you for your order!".
- **Postconditions**: Order is completed.
- **Priority**: High
- **Status**: Draft