﻿namespace E_Commerce_App.Core.Entities
{
    public class ProductCategory
    {
        public string ProductId { get; set; }
        public Product Product { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
