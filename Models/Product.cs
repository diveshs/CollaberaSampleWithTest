using System;
using System.Collections.Generic;
using System.Text;

namespace CollaberaSampleApplicationWithTest.Models
{
    public class Product
    {
        public string SKUId { get; set; }
        public int Price { get; set; }
    }

    public class Products
    {
        public List<Product> ProductList = new List<Product>() {
            new Product(){SKUId="A", Price=50},
            new Product(){SKUId="B", Price=30},
            new Product(){SKUId="C", Price=20},
            new Product(){SKUId="D", Price=15}
        };
    }
}
