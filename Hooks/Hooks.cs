using AventStack.ExtentReports;
using OpenQA.Selenium;
using SeleniumBDDAuto.Utilities;

namespace SeleniumBDDAuto.Hooks;

[Binding]
public class Hooks
{
    private static readonly IWebDriver Driver = SeleniumBDDAuto.Driver.DriverManager.GetDriverInstance();
    private readonly ScenarioContext _scenarioContext;
    
    public Hooks(ScenarioContext scenarioContext)
    {
        _scenarioContext = scenarioContext;
    }

    [BeforeTestRun]
    public static void BeforeTestRun()
    {
        ReportManager.InitializeReport();
    }

    [BeforeScenario]
    public void BeforeScenario()
    {
        ReportManager.StartTest(_scenarioContext);
    }

    [AfterStep]
    public void AfterStep()
    {
        var status = _scenarioContext.TestError == null ? Status.Pass : Status.Fail;
        ReportManager.LogStep(_scenarioContext.StepContext.StepInfo.Text, status);
    }

    [AfterScenario]
    public void AfterScenario()
    {
        if (_scenarioContext.TestError != null)
        {
            ReportManager.GetTest().Fail("Test Failed: " + _scenarioContext.TestError.Message);
        }
    }

    [AfterTestRun]
    public static void AfterTestRun()
    {
        Console.WriteLine("Finalizing report...");
        ReportManager.FinalizeReport();
        Driver.Quit();
    }
}