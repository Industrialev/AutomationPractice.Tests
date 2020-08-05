using AutomationPractice.Tests.Helpers;
using AutomationPractice.Tests.PageObjects;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace AutomationPractice.Tests.Steps
{
    [Binding]
    public sealed class ProductPageSteps
    {
        private ProductPage productPage;
        private Helpers.SharedContext productContext;
        private string confirmationText;

        public ProductPageSteps(IWebDriver driver, Helpers.SharedContext productContext)
        {
            productPage = new ProductPage(driver);
            this.productContext = productContext;
        }

        [When("I add an item to my wishlist")]
        public void WhenIClickOnTheFirstItemInTopSellersList()
        {
            productContext.ProductInWishlistName = productPage.GetProductName();
            confirmationText = productPage.AddItemToWishlist();
        }

        [Then("I can see 'Add an item to my wishlist' button under 'Add to cart' button")]
        public void ThenICanSeeAddAnItemToMyWishlistButtonUnderAddToCartButton()
        {
            var addItemToWishlistButton = productPage.GetAddToWishlistButton();
            Assert.That(addItemToWishlistButton.Displayed, Is.EqualTo(true));

            var addToCartButton = productPage.GetAddToCartButton();
            var heightDifference = IsFirstElementHigherThanOther(addToCartButton, addItemToWishlistButton);
            Assert.That(heightDifference, Is.EqualTo(true));
        }

        [Then("I receive a confirmation that item was added to my wishlist")]
        public void ThenIReceiveAConfirmationThatItemWasAddedToMyWishlist()
        {
            Assert.That(confirmationText, Is.EqualTo("Added to your wishlist."));
            productPage.CloseConfirmationWindow();
        }

        private static bool IsFirstElementHigherThanOther(IWebElement firstElement, IWebElement otherElement)
        {
            return (firstElement.Location.Y - otherElement.Location.Y < 0);
        }
    }
}
