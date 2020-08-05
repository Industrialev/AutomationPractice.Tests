using AutomationPractice.Tests.Drivers;
using AutomationPractice.Tests.Helpers;
using AutomationPractice.Tests.PageObjects;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace AutomationPractice.Tests.Steps
{
    [Binding]
    public sealed class RegistrationPageSteps
    {
        private RegistrationPage registrationPage;

        private Customer customer;
        private SharedContext sharedContext;

        public RegistrationPageSteps(IWebDriver driver, SharedContext sharedContext)
        {
            registrationPage = new RegistrationPage(driver);
            this.sharedContext = sharedContext;
        }

        [When("I enter personal details in registration form")]
        public void WhenIEnterMyEmailAddressToCreateANewAccount(Table personalDetails)
        {
            customer = personalDetails.CreateInstance<Customer>();
            registrationPage.FillForm(customer);
            sharedContext.CurrentCustomer = customer;
        }

        [When("I click a 'Register' button")]
        public void WhenIClickOnARegisterButton()
        {
            registrationPage.ClickRegisterButton();
        }
    }
}
