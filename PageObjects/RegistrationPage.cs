using AutomationPractice.Tests.Drivers;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Threading;

namespace AutomationPractice.Tests.PageObjects
{
    public class RegistrationPage : PageObjectBase
    {
        public RegistrationPage(IWebDriver driver) : base(driver)
        {
        }

        [FindsBy(How = How.Id, Using = "id_gender1")]
        [CacheLookup]
        private IWebElement maleRadioButton;

        [FindsBy(How = How.Id, Using = "id_gender2")]
        [CacheLookup]
        private IWebElement femaleRadioButton;

        [FindsBy(How = How.Name, Using = "customer_firstname")]
        [CacheLookup]
        private IWebElement customerFirstName;

        [FindsBy(How = How.Name, Using = "customer_lastname")]
        [CacheLookup]
        private IWebElement customerLastName;

        [FindsBy(How = How.Name, Using = "passwd")]
        [CacheLookup]
        private IWebElement customerPasswd;

        [FindsBy(How = How.Name, Using = "days")]
        [CacheLookup]
        private IWebElement dayOfBirth;

        [FindsBy(How = How.Name, Using = "months")]
        [CacheLookup]
        private IWebElement monthOfBirth;

        [FindsBy(How = How.Name, Using = "years")]
        [CacheLookup]
        private IWebElement yearOfBirth;

        [FindsBy(How = How.Name, Using = "checkbox")]
        [CacheLookup]
        private IWebElement newsletterCheckbox;

        [FindsBy(How = How.Name, Using = "optin")]
        [CacheLookup]
        private IWebElement optinCheckbox;

        [FindsBy(How = How.Name, Using = "firstname")]
        [CacheLookup]
        private IWebElement firstNameAddress;

        [FindsBy(How = How.Name, Using = "lastname")]
        [CacheLookup]
        private IWebElement lastNameAddress;

        [FindsBy(How = How.Name, Using = "address1")]
        [CacheLookup]
        private IWebElement firstLineAddress;

        [FindsBy(How = How.Name, Using = "city")]
        [CacheLookup]
        private IWebElement cityAddress;

        [FindsBy(How = How.Name, Using = "id_state")]
        [CacheLookup]
        private IWebElement stateAddress;

        [FindsBy(How = How.Name, Using = "postcode")]
        [CacheLookup]
        private IWebElement postcodeAddress;

        [FindsBy(How = How.Name, Using = "id_country")]
        [CacheLookup]
        private IWebElement countryAddress;

        [FindsBy(How = How.Name, Using = "phone_mobile")]
        [CacheLookup]
        private IWebElement phoneMobileAddress;

        [FindsBy(How = How.Name, Using = "alias")]
        [CacheLookup]
        private IWebElement aliasAddress;

        [FindsBy(How = How.Name, Using = "submitAccount")]
        [CacheLookup]
        private IWebElement submitAccountButton;

        public string GetPageTitle()
        {
            return driver.Title;
        }

        public void FillForm(Customer customer)
        {
            if (customer is null)
            {
                throw new ArgumentNullException(nameof(customer));
            }

            wait.Until(d => d.FindElement(By.Name("submitAccount")));

            if (customer.Title == "Mr.")
            {
                maleRadioButton.Click();
            }
            else if (customer.Title == "Mrs.")
            {
                femaleRadioButton.Click();
            }
            else
            {
                throw new ArgumentException();
            }

            customerFirstName.SendKeys(customer.FirstName);
            customerLastName.SendKeys(customer.LastName);
            customerPasswd.SendKeys(customer.Password);

            var dayOfBirthDropDown = new SelectElement(dayOfBirth);
            dayOfBirthDropDown.SelectByValue(customer.DateOfBirth.Day.ToString());
            var monthOfBirthDropDown = new SelectElement(monthOfBirth);
            monthOfBirthDropDown.SelectByValue(customer.DateOfBirth.Day.ToString());
            var yearOfBirthDropDown = new SelectElement(yearOfBirth);
            yearOfBirthDropDown.SelectByValue(customer.DateOfBirth.Year.ToString());

            firstLineAddress.SendKeys(customer.Address);
            cityAddress.SendKeys(customer.City);
            var stateDropDown = new SelectElement(stateAddress);
            stateDropDown.SelectByText(customer.State);
            postcodeAddress.SendKeys(customer.PostalCode);
            var countryDropDown = new SelectElement(countryAddress);
            countryDropDown.SelectByText(customer.Country);
            phoneMobileAddress.SendKeys(customer.MobilePhone);

            aliasAddress.Clear();
            aliasAddress.SendKeys(customer.AddressAlias);
        }

        public void ClickRegisterButton()
        {
            submitAccountButton.Click();
            Thread.Sleep(3000);
        }
    }
}
