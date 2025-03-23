using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumBDDAuto.Driver;
using SeleniumBDDAuto.Utilities;
using SeleniumExtras.WaitHelpers;
namespace SeleniumBDDAuto.Pages;

public class LoginPage
{
    private readonly IWebDriver _driver;
    private readonly WebDriverWait _wait;
    private readonly By _signInButton = By.Id("nav-link-accountList");
    private readonly By _emailField = By.Name("email");
    private readonly By _continueButton = By.Id("continue");
    private readonly By _passwordField = By.Id("ap_password");
    private readonly By _submitButton = By.Id("signInSubmit");
    
    public LoginPage()
    {
        _driver = DriverManager.GetDriver("Chrome");
        _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
    }

    public void OpenHomePage()
    {
        _driver.Navigate().GoToUrl("https://www.amazon.in/");
        _wait.Until(ExpectedConditions.ElementToBeClickable(_signInButton)).Click();
    }

    public void Login(string email, string password)
    {
        _wait.Until(ExpectedConditions.ElementIsVisible(_emailField)).SendKeys(email);
        _wait.Until(ExpectedConditions.ElementToBeClickable(_continueButton)).Click();
        _wait.Until(ExpectedConditions.ElementIsVisible(_passwordField)).SendKeys(password);
        _wait.Until(ExpectedConditions.ElementToBeClickable(_submitButton)).Click();

    }
    
    
}