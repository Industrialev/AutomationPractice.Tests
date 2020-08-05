using AutomationPractice.Tests.Drivers;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Threading;
using TechTalk.SpecFlow;
using OpenQA.Selenium.Support.Extensions;
using SeleniumExtras.WaitHelpers;

namespace AutomationPractice.Tests.PageObjects
{
    public class ProductPage : PageObjectBase
    {
        public ProductPage(IWebDriver driver) : base(driver)
        {
        }

        [FindsBy(How = How.XPath, Using = "//button[@class='exclusive'][1]")]
        [CacheLookup]
        private IWebElement addToCartButton;

        [FindsBy(How = How.XPath, Using = "//a[@id='wishlist_button'][1]")]
        [CacheLookup]
        private IWebElement addToWishListButton;

        [FindsBy(How = How.XPath, Using = "//div/p[1]")]
        [CacheLookup]
        private IWebElement productName;

        [FindsBy(How = How.ClassName, Using = "fancybox-error")]
        [CacheLookup]
        private IWebElement confirmationWindow;

        [FindsBy(How = How.CssSelector, Using = ".fancybox-skin .fancybox-close")]
        [CacheLookup]
        private IWebElement confirmationWindowCloseButton;

        public string AddItemToWishlist()
        {
            addToWishListButton.Click();
            Thread.Sleep(3000);

            wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.ClassName("fancybox-error")));

            return confirmationWindow.Text;
        }

        public IWebElement GetAddToCartButton()
        {
            return addToCartButton;
        }

        public IWebElement GetAddToWishlistButton()
        {
            return addToWishListButton;
        }

        public string GetProductName()
        {
            return productName.Text;
        }

        public void CloseConfirmationWindow()
        {
            confirmationWindowCloseButton.Click();
        }
    }
}
