using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using SeleniumBDDAuto.Driver;

namespace SeleniumFramework.Pages
{
    public class SearchPage
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;

        public SearchPage()
        {
            _driver = DriverManager.GetDriver("Chrome");
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        }

        // Locators
        private By searchBox = By.Id("twotabsearchtextbox");
        private By searchButton = By.Id("nav-search-submit-button");
        private By searchResults = By.XPath("//span[contains(@class, 'a-color-state')]");

        public void SearchProduct(string product)
        {
            _wait.Until(ExpectedConditions.ElementIsVisible(searchBox)).SendKeys(product);
            _driver.FindElement(searchButton).Click();
        }

        public bool VerifySearchResults(string product)
        {
            string resultText = _wait.Until(ExpectedConditions.ElementIsVisible(searchResults)).Text;
            return resultText.Contains(product, StringComparison.OrdinalIgnoreCase);
        }
    }
}
