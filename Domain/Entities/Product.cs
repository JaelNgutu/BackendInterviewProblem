using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Product : BaseEntity
    {

        /// <summary>
        /// Gets or sets the price of the product.
        /// </summary>
        public int Price { get; set; }

        /// <summary>
        /// Gets or sets the name of the product.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the category to which the product belongs.
        /// </summary>
        public string Category { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Product"/> class.
        /// </summary>
        public Product()
        {
            // Default constructor with no parameters.
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Product"/> class with specified values.
        /// </summary>
        /// <param name="id">The unique identifier for the product.</param>
        /// <param name="price">The price of the product.</param>
        /// <param name="name">The name of the product.</param>
        /// <param name="category">The category to which the product belongs.</param>
        public Product(int id, int price, string name, string category)
        {
            Id = id;
            Price = price;
            Name = name;
            Category = category;
        }
    }
}
