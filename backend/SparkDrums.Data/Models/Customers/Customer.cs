using System;

namespace SparkDrums.Data.Models.Customers
{   
    public class Customer
    {
        public int Id { get; set; }

        public string GivenName { get; set; }

        public string Surname { get; set; }

        public CustomerAddress PrimaryAddress { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime UpdatedOn { get; set; }
    }
}
