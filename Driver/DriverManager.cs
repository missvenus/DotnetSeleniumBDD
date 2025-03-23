using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Safari;

namespace SeleniumBDDAuto.Driver;

public static class DriverManager
{
    private static IWebDriver? _driver;

    public static IWebDriver GetDriver(string browserName)
    {
        if (_driver == null)
        {
            switch (browserName.ToLower())
            {
                case "chrome":
                    _driver = new ChromeDriver();
                    break;
                case "firefox":
                    _driver = new FirefoxDriver();
                    break;
                case "safari":
                    _driver = new SafariDriver();
                    break;
                default:
                    throw new ArgumentException("Invalid browser name. Supported browsers: Chrome, Firefox, Safari");
            }
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            _driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(5);
            _driver.Manage().Window.Maximize();
        }

        return _driver;
    }

    public static void CloseDriver()
    {
        _driver?.Close();
    }

    public static void QuitDriver()
    {
        _driver?.Quit();
    }

    public static IWebDriver GetDriverInstance()
    {
        return _driver;
    }
    
}