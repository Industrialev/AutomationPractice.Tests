using AutomationPractice.Tests.PageObjects;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace AutomationPractice.Tests.Steps
{
    [Binding]
    public sealed class HomePageSteps
    {
        private HomePage homePage;
        private AuthenticationPage authenticationPage;

        public HomePageSteps(IWebDriver driver)
        {
            homePage = new HomePage(driver);
        }

        [Given("I am on the home page")]
        public void GivenIAmOnTheHomePage()
        {
            homePage.GoToUrl();
        }

        [When("I click a 'Sign in' button")]
        public void WhenIClickASignInButton()
        {
            authenticationPage = homePage.GoToAuthenticationPage();
        }

        [Then("I should be redirected to 'Sign in' page")]
        public void ThenIShouldBeRedirectedToSignInPage()
        {
            Assert.That(authenticationPage.GetPageTitle, Is.EqualTo("Login - My Store"));
        }
    }
}
