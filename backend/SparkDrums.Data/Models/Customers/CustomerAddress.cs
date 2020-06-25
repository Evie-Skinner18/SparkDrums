using System;
using System.ComponentModel.DataAnnotations;

namespace SparkDrums.Data.Models.Customers
{
    // making distinction because we might need business address aswell
    public class CustomerAddress
    {
        public int Id { get; set; }

        [MaxLength(100)]
        public string Line1 { get; set; }

        [MaxLength(100)]
        public string Line2 { get; set; }

        [MaxLength(100)]
        public string Line3 { get; set; }

        [MaxLength(100)]
        public string City { get; set; }

        [MaxLength(50)]
        public string Region { get; set; }

        [MaxLength(10)]
        public string Postcode { get; set; }

        [MaxLength(50)]
        public string Country { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime UpdatedOn { get; set; }
    }
}
