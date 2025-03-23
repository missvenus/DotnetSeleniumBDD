using AventStack.ExtentReports.Reporter;

namespace SeleniumBDDAuto.Utilities;

using AventStack.ExtentReports;

public static class ReportManager
{
    private static ExtentReports _extent;
    private static ExtentTest _test;

    public static void InitializeReport()
    {
        ExtentSparkReporter reporter = new ExtentSparkReporter(CommonUtils.GetCurrentDirectory()+ "/Reports/report.html");
        _extent = new ExtentReports();
        _extent.AttachReporter(reporter);
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
        Console.WriteLine("Report finalization started...");
        _extent.Flush();
    }

    public static ExtentTest GetTest()
    {
        return _test;
    }
}

