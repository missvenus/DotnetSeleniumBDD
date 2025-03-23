using NUnit.Framework;
using SeleniumBDDAuto.Pages;
using SeleniumFramework.Pages;

namespace SeleniumBDDAuto.StepDefinitions
{
    [Binding]
    public class SearchSteps
    {
        private readonly SearchPage _searchPage = new SearchPage();
        private readonly HomePage _homePage = new HomePage();

        [Given(@"User is on the Amazon homepage")]
        public void GivenUserIsOnAmazonHomePage()
        {
            _homePage.Open();
        }

        [When(@"User searches for ""(.*)""")]
        public void WhenUserSearchesFor(string product)
        {
            _searchPage.SearchProduct(product);
        }

        [Then(@"Search results for ""(.*)"" should be displayed")]
        public void ThenSearchResultsShouldBeDisplayed(string product)
        {
            Assert.That(_searchPage.VerifySearchResults(product), Is.True, "Search results are incorrect.");
        }
    }
}
