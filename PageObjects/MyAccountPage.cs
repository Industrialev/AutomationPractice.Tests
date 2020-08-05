using AutomationPractice.Tests.Drivers;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;

namespace AutomationPractice.Tests.PageObjects
{
    public class MyAccountPage : PageObjectBase
    {
        public MyAccountPage(IWebDriver driver) : base(driver)
        {
        }

        [FindsBy(How = How.XPath, Using = "//div[@class='header_user_info'][1]")]
        [CacheLookup]
        private IWebElement myAccountLink;

        [FindsBy(How = How.XPath, Using = "//a[@class='account'][1]/span[1]")]
        [CacheLookup]
        private IWebElement myAccountName;

        [FindsBy(How = How.XPath, Using = "//li[@class='lnk_wishlist'][1]/a[1]")]
        [CacheLookup]
        private IWebElement myWishlistsLink;

        [FindsBy(How = How.XPath, Using = "//li[@class='lnk_wishlist'][1]/a[1]")]
        [CacheLookup]
        private IWebElement myWishlistsLink1;

        public MyWishlistsPage ClickOnWishlistsLink()
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//li[@class='lnk_wishlist'][1]/a[1]")));
            // workaround
            try
            {
                myWishlistsLink.Click();
            }
            catch(System.Reflection.TargetInvocationException e) when (e.InnerException is StaleElementReferenceException)
            {
                myWishlistsLink1.Click();
            }

            return new MyWishlistsPage(driver);
        }

        public string GetPageTitle()
        {
            return driver.Title;
        }

        public string GetAccountName()
        {
            return myAccountName.Text;
        }

        public ElementParameters GetAccountNameLocation()
        {
            return new ElementParameters(myAccountName.Size, myAccountName.Location);
        }

        public IWebElement GetWishlistsLink()
        {
            return myWishlistsLink;
        }

        public void GoToUrl()
        {
            wait.Until(d => d.FindElement(By.XPath("//div[@class='header_user_info'][1]")));
            myAccountLink.Click();
        }

    }
}
