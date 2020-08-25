using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Webscraper.Models
{
    public class ProductListing
    {
        
        public ProductListing(int id, string name, decimal cost, Category category)
        {
            Id = id;
            ProductName = name;
            ProductCost = cost;
            ProductCategory = category;
        }

        public int Id { get; set; }
        public string ProductName { get; set; }
        public decimal ProductCost { get; set; }
        public Category ProductCategory { get; set; }
    }
    public enum Category
    {
        Fashion,
        Beauty,
        Home
    }
}
