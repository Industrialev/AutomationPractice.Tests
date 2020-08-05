using AutomationPractice.Tests.Drivers;
using AutomationPractice.Tests.PageObjects;
using NUnit.Framework.Internal;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace AutomationPractice.Tests.Helpers
{
    public class SharedContext
    {
        public string ProductInWishlistName { get; set; }

        public Customer CurrentCustomer { get; set; }
    }
}
