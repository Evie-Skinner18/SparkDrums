using System;

namespace SparkDrums.Services.Models.Customers
{
    public class CustomerAddress
    {
        public int Id { get; set; }

        public string Line1 { get; set; }

        public string Line2 { get; set; }

        public string Line3 { get; set; }

        public string City { get; set; }

        public string Region { get; set; }

        public string Postcode { get; set; }

        public string Country { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime UpdatedOn { get; set; }
    }
}
