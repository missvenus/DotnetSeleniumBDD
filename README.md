# Selenium C# Automation Framework with SpecFlow

## 📌 Overview
This project is a Selenium C# automation framework using SpecFlow for BDD-style test automation. It includes:
- Selenium WebDriver for browser automation
- SpecFlow for BDD-style test scenarios
- NUnit as the test runner
- ExtentReports for detailed test reporting
- GitHub Actions for CI/CD automation

## 🚀 Getting Started

### 1️⃣ Prerequisites
- Install **Visual Studio Code** or **JetBrains Rider**
- Install **.NET SDK (6.0 or later)**
- Install **Chrome** (for browser automation)
- Install the required **NuGet Packages**

### 2️⃣ Setup the Project
Clone the repository:
```sh
 git clone https://github.com/your-repo.git
 cd your-repo
```

Restore dependencies:
```sh
dotnet restore
```

### 3️⃣ Running the Tests Locally
To execute all tests:
```sh
dotnet test
```
Run tests with logs:
```sh
dotnet test --verbosity normal
```

### 4️⃣ Generating Reports
After running the tests, find the report in:
```
TestReports/TestReport.html
```

### 5️⃣ Running Tests in GitHub Actions
- The framework is integrated with **GitHub Actions** for CI/CD.
- After every push to `main`, tests run automatically.
- Download the **TestReport.html** from GitHub Actions artifacts.

## 📂 Project Structure
```
SeleniumFramework/
├── Features/        # SpecFlow feature files
├── Pages/           # Page Object Model classes
├── Steps/           # Step definitions for SpecFlow
├── Hooks/           # SpecFlow Hooks (Before/After scenario)
├── Reports/         # ExtentReports configuration
├── Driver/          # WebDriver setup & management
├── .github/         # GitHub Actions workflows
└── specflow.json    # SpecFlow configuration
```

## 🔧 Key Configuration
- `Driver.cs` → Manages WebDriver instances
- `Hooks.cs` → Initializes and tears down test execution
- `ReportManager.cs` → Generates ExtentReports

## 📬 Need Help?
Feel free to open an **Issue** or contribute via **Pull Requests**! 🎯


