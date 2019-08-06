using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVC01.Models;

namespace MVC01.Services
{
    /// <summary>
    /// Repository class for products.
    /// </summary>
    public class ProductRepository
    {
        /// <summary>
        /// Returns all products from repository.
        /// </summary>
        /// <returns>A list with all products.</returns>
        public List<Product> GetAll()
        {
            return Products;
        }

        /// <summary>
        /// Returns a product based on the product id.
        /// </summary>
        /// <param name="id">Product id.</param>
        /// <returns>A product or null if the product id didn't exist.</returns>
        public Product GetById(int id)
        {
            var selectedProduct = 
                Products.FirstOrDefault(prod => prod.Id.Equals(id));

            return selectedProduct;
        }

        /// <summary>
        /// Adds a product to the product list.
        /// </summary>
        /// <param name="product">The product to be added.</param>
        public void Add(Product product)
        {

        }

        /// <summary>
        /// Updates a product in the repository.
        /// </summary>
        /// <param name="product">The product to be updated.</param>
        public void Update(Product product)
        {

        }

        /// <summary>
        /// Deletes a product from the repository.
        /// </summary>
        /// <param name="product">The product to be deleted.</param>
        public void Delete(Product product)
        {

        }

        /// <summary>
        /// Deletes a product from the repository.
        /// </summary>
        /// <param name="productId">Product id of to product be deleted.</param>
        public void Delete(int productId)
        {

        }

        /// <summary>
        /// Get all products internally.
        /// </summary>
        private List<Product> Products
        {
            get
            {
                return new List<Product> {
                    new Product {
                        Id = 123,
                        Name = "Strumpor",
                        Description = "Super socks for super men and women. Yay, hooray, fantastic today!",
                        ProductNumber = "ABC9897"
                    },
                    new Product {
                        Id = 456,
                        Name = "Skjorta",
                        Description = "Super shirt for super men and women. Yay, hooray, fantastic today!",
                        ProductNumber = "CDE7481"
                    },
                    new Product {
                        Id = 458,
                        Name = "Byxor",
                        Description = "Super pants for super men and women. Yay, hooray, fantastic today!",
                        ProductNumber = "CDE9781"
                    },
                    new Product {
                        Id = 897,
                        Name = "Mössa",
                        Description = "Super cap for super men and women. Yay, hooray, fantastic today!",
                        ProductNumber = "QWE6767"
                    },
                };
            }
        }
    }
}
