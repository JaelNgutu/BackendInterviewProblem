using Application.Interfaces;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    
    public class ProductRepository : IProductRepository
    {
            private static List<Product> Products = new List<Product>
            {
            new Product { Id = 1, Name = "Laptop", Category = "Electronics", Price = 1000 },
            new Product { Id = 2, Name = "Smartphone", Category = "Electronics", Price = 800 },
            new Product { Id = 3, Name = "Book", Category = "Books", Price = 20 },
            new Product { Id = 4, Name = "Desk Chair", Category = "Furniture", Price = 150 },
            new Product { Id = 5, Name = "Coffee Maker", Category = "Appliances", Price = 50 },
            new Product { Id = 6, Name = "Headphones", Category = "Electronics", Price = 100 },
            new Product { Id = 7, Name = "T-Shirt", Category = "Clothing", Price = 25 },
            new Product { Id = 8, Name = "Backpack", Category = "Accessories", Price = 40 },
            new Product { Id = 9, Name = "Gaming Console", Category = "Electronics", Price = 300 },
            new Product { Id = 10, Name = "Sunglasses", Category = "Accessories", Price = 50 },
            new Product { Id = 11, Name = "Desk", Category = "Furniture", Price = 200 },
            new Product { Id = 12, Name = "Plant Pot", Category = "Home Decor", Price = 15 },
            new Product { Id = 13, Name = "Running Shoes", Category = "Footwear", Price = 80 },
            new Product { Id = 14, Name = "Toaster", Category = "Appliances", Price = 30 },
            new Product { Id = 15, Name = "Dress Shirt", Category = "Clothing", Price = 45 },
            };

        public async Task<IQueryable<Product>> GetAllProducts()
        {
            return Products.AsQueryable();
        }
    }
}
