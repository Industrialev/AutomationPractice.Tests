using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Threading;

namespace AutomationPractice.Tests.PageObjects
{
    public class HomePage : PageObjectBase
    {
        public HomePage(IWebDriver driver) : base(driver)
        {
        }

        private Uri homeUrl = new Uri("http://automationpractice.com/");
        private int sleepTime = 3000;

        [FindsBy(How = How.XPath, Using = "//div[@class='header_user_info'][1]")]
        [CacheLookup]
        private IWebElement signInLink;

        public void GoToUrl()
        {
            driver.Navigate().GoToUrl(homeUrl);
        }

        public string GetPageTitle()
        {
            return driver.Title;
        }

        public AuthenticationPage GoToAuthenticationPage()
        {
            wait.Until(d => d.FindElement(By.XPath("//div[@class='header_user_info'][1]")));
            signInLink.Click();

            Thread.Sleep(sleepTime);

            return new AuthenticationPage(driver);
        }
    }
}
