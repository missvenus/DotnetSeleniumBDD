using System;
using System.ComponentModel.DataAnnotations;
using SeleniumBDDAuto.Pages;
using SeleniumBDDAuto.Utilities;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Analytics.UserId;

namespace SeleniumBDDAuto.StepDefinitions
{
    [Binding]
    public class HomePageSteps
    {

        private readonly HomePage _homePage = new HomePage();
        private readonly LoginPage _loginPage = new LoginPage();
        private readonly Dictionary<string, string> _loginCredentials = CommonUtils.GetSignCredentials();

        [Given(@"User is on the home page")]
        public void GivenUserIsOnTheHomePage()
        {
            _homePage.Open();
        }

        [When(@"users enters signin and password")]
        public void WhenUsersEntersSigninAndPassword()
        {

            _loginPage.Login(_loginCredentials["email"], _loginCredentials["password"]);
        }

        [Then(@"the home page loads")]
        public void ThenTheHomePageLoads()
        {
            Thread.Sleep(3000);
        }
    }
}