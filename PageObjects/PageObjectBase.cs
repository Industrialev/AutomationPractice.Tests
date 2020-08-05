using AutomationPractice.Tests.Drivers;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Threading;
using TechTalk.SpecFlow;

namespace AutomationPractice.Tests.PageObjects
{
    public class PageObjectBase
    {
        protected int timeout = 10000;
        protected IWebDriver driver;
        protected WebDriverWait wait;

        protected PageObjectBase(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(timeout));
            PageFactory.InitElements(driver, this);
        }
    }
}
