using AutomationPractice.Tests.Helpers;
using AutomationPractice.Tests.PageObjects;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace AutomationPractice.Tests.Steps
{
    [Binding]
    public sealed class MyWishlistsPageSteps
    {
        private MyWishlistsPage myWishlistsPage;
        private Helpers.SharedContext productContext;
        private IWebDriver driver;

        public MyWishlistsPageSteps(IWebDriver driver, Helpers.SharedContext productContext)
        {
            this.productContext = productContext;
            this.driver = driver;
            myWishlistsPage = new MyWishlistsPage(driver);
        }

        [When("I click on the first item in 'TOP SELLERS' list")]
        public void WhenIClickOnTheFirstItemInTopSellersList()
        {
            myWishlistsPage.ClickItemFromTopSellersList(1);
        }

        [Then("I can see 'TOP SELLERS' list on the left side panel")]
        public void ThenICanSeeTopSellersListOnTheLeftSidePanel()
        {
            var topSellersLink = myWishlistsPage.GetTopSellersLink();

            Assert.That(topSellersLink.Displayed, Is.EqualTo(true));
            Assert.That(topSellersLink.Text, Is.EqualTo("TOP SELLERS"));
            Assert.That((topSellersLink.Location.X + topSellersLink.Size.Width) <= driver.Manage().Window.Size.Width / 2);
        }

        [Then("I can see this item in my wishlist")]
        public void ThenICanSeeThisItemInMyWishlist()
        {
            Assert.That(myWishlistsPage.FindItemInWishlist(this.productContext.ProductInWishlistName), Is.EqualTo(true));
        }
    }
}
