using AutomationPractice.Tests.PageObjects;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace AutomationPractice.Tests.Steps
{
    [Binding]
    public sealed class AuthenticationPageSteps
    {
        private HomePage homePage;
        private AuthenticationPage authenticationPage;

        private string loginEmailAddress;
        private string loginPassword;

        public AuthenticationPageSteps(IWebDriver driver)
        {
            authenticationPage = new AuthenticationPage(driver);
            homePage = new HomePage(driver);
        }

        [Given("I am user (.*)")]
        public void IAmUser(string userName)
        {
            if (userName == "John Kowalski")
            {
                loginEmailAddress = "johnkolwaski@onet.pl";
                loginPassword = "123456";
            }
        }

        [Given("I am on the 'Sign in' page")]
        public void GivenIAmOnTheSignInPage()
        {
            homePage.GoToUrl();
            authenticationPage = homePage.GoToAuthenticationPage();
        }

        [When("I enter my e-mail address to create a new account")]
        public void WhenIEnterMyEmailAddressToCreateANewAccount()
        {
            string randomEmailAddress = Faker.Internet.Email();
            authenticationPage.EnterEmailAddressToRegister(randomEmailAddress);
        }

        [When("I click a 'Create An Account' button")]
        public void WhenIClickACreateAnAccountButton()
        {
            authenticationPage.CreateAnAccount();
        }

        [When("I log in to my account")]
        public void WhenILogInToMyAccount()
        {
            authenticationPage.LoginToAccount(loginEmailAddress, loginPassword);
        }
    }
}
