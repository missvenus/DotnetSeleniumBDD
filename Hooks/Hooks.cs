using OpenQA.Selenium;

namespace SeleniumBDDAuto.Hooks;

[Binding]
public class Hooks
{
    private static readonly IWebDriver Driver = SeleniumBDDAuto.Driver.DriverManager.GetDriverInstance();
    
    [AfterTestRun]
    public static void AfterTestRun()
    {
        Driver.Quit();
    }
}