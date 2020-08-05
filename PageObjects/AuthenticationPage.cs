using AutomationPractice.Tests.Drivers;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Threading;
using TechTalk.SpecFlow;

namespace AutomationPractice.Tests.PageObjects
{
    public class AuthenticationPage : PageObjectBase
    {
        public AuthenticationPage(IWebDriver driver) : base(driver)
        {
        }

        [FindsBy(How = How.Name, Using = "email_create")]
        [CacheLookup]
        private IWebElement emailCreateBox;

        [FindsBy(How = How.Name, Using = "email")]
        [CacheLookup]
        private IWebElement emailBox;

        [FindsBy(How = How.Name, Using = "passwd")]
        [CacheLookup]
        private IWebElement passwdBox;

        [FindsBy(How = How.Name, Using = "SubmitCreate")]
        [CacheLookup]
        private IWebElement submitCreateButton;

        [FindsBy(How = How.Name, Using = "SubmitLogin")]
        [CacheLookup]
        private IWebElement submitLoginButton;

        public string GetPageTitle()
        {
            return driver.Title;
        }

        public void EnterEmailAddressToRegister(string emailAddress)
        {
            emailCreateBox.SendKeys(emailAddress);
        }

        public void CreateAnAccount()
        {
            submitCreateButton.Click();
            Thread.Sleep(3000);
        }

        public void LoginToAccount(string emailAddress, string password)
        {
            emailBox.SendKeys(emailAddress);
            passwdBox.SendKeys(password);
            submitLoginButton.Click();

            wait.Until(d => d.FindElement(By.ClassName("info-account")));
        }
    }
}
