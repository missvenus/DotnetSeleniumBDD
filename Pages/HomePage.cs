using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumBDDAuto.Driver;
using SeleniumBDDAuto.Utilities;
using SeleniumExtras.WaitHelpers;
namespace SeleniumBDDAuto.Pages;

public class HomePage
{
    private readonly IWebDriver _driver;
    private readonly WebDriverWait _wait;
    private readonly By _signInButton = By.Id("nav-link-accountList");
    public HomePage()
    {
        _driver = DriverManager.GetDriver("Chrome");
        _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
    }
    public void Open()
    {
        _driver.Navigate().GoToUrl("https://www.amazon.in/");
        _wait.Until(ExpectedConditions.ElementToBeClickable(_signInButton)).Click();
    }
}