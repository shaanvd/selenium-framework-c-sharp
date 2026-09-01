# SauceDemo Enterprise Test Automation Framework

An enterprise-grade, highly modular UI test automation framework for the SauceDemo e-commerce platform. Built utilizing C#, Selenium WebDriver, and NUnit, this repository demonstrates scalable Quality Engineering & Assurance (QEA) practices. It is engineered to support advanced functional testing principles and comprehensive test design techniques like Boundary Value Analysis to ensure highly reliable software delivery.

## Architecture & Tech Stack

| Component | Technology |
| :--- | :--- |
| **Language** | C# (.NET 8) |
| **Browser Engine** | Selenium WebDriver |
| **Test Runner** | NUnit |
| **Design Pattern** | Fluent Page Object Model (POM) |
| **Reporting** | ExtentReports & Allure |

## Project Structure

* **`Config/`**: Manages environment variables and deserializes `appsettings.json` for secure, data-driven testing execution.
* **`Core/`**: Houses the `DriverFactory` and `DriverContext`, ensuring isolated, thread-safe WebDriver sessions for parallel test execution.
* **`Pages/`**: Contains UI web element locators and state-transition methods utilizing the Fluent Page Object Model.
* **`Reporting/`**: Automates HTML report generation and captures browser state screenshots upon test failure.
* **`Tests/`**: Contains business logic and assertions, categorized into organized test packs (e.g., Smoke, Regression) for agile software testing lifecycle integration.
* **`Utilities/`**: Provides global helper methods, including dynamic explicit waits for robust element synchronization.

## Prerequisites

1. [.NET 8 SDK](https://dotnet.microsoft.com/download)
2. [Java JDK](https://adoptium.net/) (Required for compiling Allure Reports)
3. Node.js or Scoop (To install the Allure Commandline tool)
4. Google Chrome browser

## Run
```bash
dotnet restore
dotnet test
```
Overrides: `SAUCE_BROWSER`, `SAUCE_HEADLESS`, `SAUCE_REPORT_TYPE`, `SAUCE_USERNAME`, `SAUCE_PASSWORD`.
Reports are written below `artifacts/`. Generate Allure HTML with `allure serve artifacts/allure-results`.
