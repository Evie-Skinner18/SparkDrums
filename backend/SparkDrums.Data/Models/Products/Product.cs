﻿using System;
using System.ComponentModel.DataAnnotations;

namespace SparkDrums.Data.Models.Products
{
    public class Product
    {
        public int Id { get; set; }

        [MaxLength(64)]
        public string Name { get; set; }

        public string Category { get; set; }

        [MaxLength(128)]
        public string Description { get; set; }

        public decimal Price { get; set; }

        public bool IsTaxable { get; set; }

        public bool IsArchived { get; set; }

        public bool IsOnSale { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime UpdatedOn { get; set; }
    }
}
