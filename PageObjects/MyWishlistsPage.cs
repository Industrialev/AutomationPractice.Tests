using AutomationPractice.Tests.Drivers;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Threading;
using TechTalk.SpecFlow;

namespace AutomationPractice.Tests.PageObjects
{
    public class MyWishlistsPage : PageObjectBase
    {
        public MyWishlistsPage(IWebDriver driver) : base(driver)
        {
        }

        [FindsBy(How = How.XPath, Using = "//h4[@class='title_block'][1]/a[1]")]
        [CacheLookup]
        private IWebElement topSellersLink;

        [FindsBy(How = How.XPath, Using = "//ul[@class='block_content products-block'][1]/li")]
        [CacheLookup]
        private IList<IWebElement> topSellersList;

        [FindsBy(How = How.XPath, Using = "//table/tbody/tr[1]/td[1]/a")]
        [CacheLookup]
        private IWebElement firstWishlist;

        public void ClickItemFromTopSellersList(int index)
        {
            topSellersList[index].Click();
        }

        public void ClickOnFirstWishlist()
        {
            firstWishlist.Click();
        }

        public bool FindItemInWishlist(string productName)
        {
            var product = driver.FindElement(By.ClassName("product-name"));
            return product.Text == productName;
        }

        public IWebElement GetTopSellersLink()
        {
            return topSellersLink;
        }
    }
}
