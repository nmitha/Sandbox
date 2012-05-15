using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TemplateBasedViewControl.TestHarness
{
    public class Customer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int NumberOfOrders { get; set; }
        public decimal LastOrderAmount { get; set; }

        public IEnumerable<Customer> GetAllCustomers()
        {
            return new List<Customer> {
                new Customer { FirstName = "John", LastName = "Doe"},
                new Customer { FirstName = "Jane", LastName = "Smith" }
            };
        }
    }
}