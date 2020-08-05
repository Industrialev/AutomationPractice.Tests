using System;

namespace AutomationPractice.Tests.Drivers
{
    public class Customer
    {
        public Customer()
        {
            Password = "123456";
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Title { get; set; }

        public string EmailAddress { get; set; }

        public string Password { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string PostalCode { get; set; }

        public string Country { get; set; }

        public string MobilePhone { get; set; }

        public string AddressAlias { get; set; }
    }
}