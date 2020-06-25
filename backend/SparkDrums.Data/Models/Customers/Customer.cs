using System;

namespace SparkDrums.Data.Models.Customers
{
    /*
     * Entity models:
     * general product class with name e.g 'DW Collector Series Drumkit', 'Vic Firth American Classic sticks'.
     * product will have prop called category or something that will tell you e.g this is drumkit/percussion/accessory
     * 
     * 
     */

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
