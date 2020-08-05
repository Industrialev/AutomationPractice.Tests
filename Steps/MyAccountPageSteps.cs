using AutomationPractice.Tests.Drivers;
using AutomationPractice.Tests.Helpers;
using AutomationPractice.Tests.PageObjects;
using Gherkin.Ast;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace AutomationPractice.Tests.Steps
{
    [Binding]
    public sealed class MyAccountPageSteps
    {
        private MyAccountPage myAccountPage;
        private SharedContext sharedContext;
        private IWebDriver driver;

        public MyAccountPageSteps(IWebDriver driver, SharedContext sharedContext)
        {
            this.driver = driver;
            myAccountPage = new MyAccountPage(driver);
            this.sharedContext = sharedContext;
        }

        [When("I click on 'MY WISHLISTS' link")]
        public void ThenICanClickOnMyWishlistsLink()
        {
            myAccountPage.ClickOnWishlistsLink();
        }

        [Then("I navigate to my wishlist")]
        public void ThenINavigateToMyWishlist()
        {
            myAccountPage.GoToUrl();
            myAccountPage.ClickOnWishlistsLink();
        }

        [Then("I am on 'MY ACCOUNT' page")]
        public void ThenIAmOnMyAccountPage()
        {
            Assert.That(myAccountPage.GetPageTitle(), Is.EqualTo("My account - My Store"));
        }

        [Then("I can see 'MY WISHLISTS' link on the page")]
        public void ThenICanSeeMyWishlistsLinkOnThePage()
        {
            var myWishlistsLink = myAccountPage.GetWishlistsLink();
            Assert.That(myWishlistsLink.Text, Is.EqualTo("MY WISHLISTS"));
            Assert.That(myWishlistsLink.Displayed && myWishlistsLink.Enabled, Is.EqualTo(true));
        }

        [Then("I can see my name in the top right corner")]
        public void ThenICanSeeMyNameInTheTopRightCorner()
        {
            var accountName = myAccountPage.GetAccountName();
            Assert.That(
                accountName,
                Is.EqualTo($"{sharedContext.CurrentCustomer.FirstName} {sharedContext.CurrentCustomer.LastName}"));

            var accountNameParameters = myAccountPage.GetAccountNameLocation();
            Assert.That(
                IsElementInRightPartOfWebsite(accountNameParameters) &&
                IsElementInTopPartOfWebsite(accountNameParameters),
                Is.EqualTo(true));
        }

        [Then("I am redirected to 'My Account' page")]
        public void ThenIAmRedirectedToMyAccountPage()
        {
            Assert.That(myAccountPage.GetPageTitle, Is.EqualTo("My account - My Store"));
        }

        private bool IsElementInRightPartOfWebsite(ElementParameters elementParameters)
        {
            int windowWidth = driver.Manage().Window.Size.Width;
            return elementParameters.Location.X + elementParameters.Size.Width >= windowWidth / 2;
        }

        private bool IsElementInTopPartOfWebsite(ElementParameters elementParameters)
        {
            int windowHeight = driver.Manage().Window.Size.Height;
            return elementParameters.Location.Y + elementParameters.Size.Height <= windowHeight / 2;
        }
    }
}
