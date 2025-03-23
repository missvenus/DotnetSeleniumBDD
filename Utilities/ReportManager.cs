using AventStack.ExtentReports.Reporter;

namespace SeleniumBDDAuto.Utilities;

using AventStack.ExtentReports;

public static class ReportManager
{
    private static ExtentReports _extent;
    private static ExtentTest _test;
    private static string _reportPath;

    public static void InitializeReport()
    {
        // Define the correct directory for the report
        string projectRoot = Directory.GetCurrentDirectory();
        string reportDirectory = Path.Combine(projectRoot, "Reports");

        // Ensure directory exists
        if (!Directory.Exists(reportDirectory))
        {
            Directory.CreateDirectory(reportDirectory);
        }

        // Set report path
        _reportPath = Path.Combine(reportDirectory, "TestReport.html");

        // Create Extent Report
        var reporter = new ExtentSparkReporter(_reportPath);
        reporter.Config.ReportName = "Cucumber SpecFlow Test Report";
        reporter.Config.DocumentTitle = "Automation Test Report";

        _extent = new ExtentReports();
        _extent.AttachReporter(reporter);

        Console.WriteLine($"📂 Report will be saved at: {_reportPath}");
    }

    public static void StartTest(ScenarioContext scenarioContext)
    {
        _test = _extent.CreateTest(scenarioContext.ScenarioInfo.Title);
    }

    public static void LogStep(string stepDescription, Status status = Status.Pass)
    {
        _test.Log(status, stepDescription);
    }

    public static void FinalizeReport()
    {
        _extent.Flush();
        Console.WriteLine($"✅ Report successfully generated: {_reportPath}");
        
        if (File.Exists(_reportPath))
        {
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo()
            {
                FileName = _reportPath,
                UseShellExecute = true
            });
        }
    }

    public static ExtentTest GetTest()
    {
        return _test;
    }
}

