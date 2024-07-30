# Alert and Window Handling Selenium Project

This project demonstrates how to use Selenium WebDriver with NUnit for automated web testing, focusing on handling alerts and managing multiple windows/tabs.

## Prerequisites

- .NET Framework
- NUnit
- Selenium WebDriver
- ChromeDriver
- Selenium.Support
- SeleniumExtras.WaitHelpers

## Project Structure

The project consists of a single test class `GoogleSearchTest` containing multiple test methods:

1. `TestHandleAlert`: Demonstrates handling of timed alerts.
2. `TestSwitchBetweenWindowsAndTabs`: Shows how to switch between multiple windows.
3. `TestChart`: Illustrates opening new tabs and navigating between them.

## Test Scenarios

### Alert Handling
- Navigates to a demo page with alerts.
- Clicks a button to trigger a timed alert.
- Waits for the alert to appear and then accepts it.

### Window/Tab Management
- Opens a new window and switches to it.
- Verifies content in the new window.
- Closes the new window and switches back to the original.

### Multi-Tab Navigation
- Opens a new tab.
- Navigates to different URLs in the new tab.
- Demonstrates back navigation.

## Utility Methods

- `WaitForNewWindow`: Waits for a new window to open.
- `WaitForAlert`: Waits for an alert to appear with a timeout.

## Running the Tests

To run the tests:

1. Ensure that ChromeDriver is installed and its path is correctly set in the `SetUp` method.
2. Build the project.
3. Run the tests using NUnit test runner.


