﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using MVC01.Models;
using Newtonsoft.Json;

namespace MVC01.Services
{
    /// <summary>
    /// Repository class for products.
    /// </summary>
    public class ProductRepository : IProductRepository
    {
        IHostingEnvironment _environment;
        List<Product> _products;

        public ProductRepository(IHostingEnvironment environment)
        {
            _environment = environment;
            _products = LoadProducts();
        }

        /// <summary>
        /// Returns all products from repository.
        /// </summary>
        /// <returns>A list with all products.</returns>
        public List<Product> GetAll()
        {
            return _products;
        }

        /// <summary>
        /// Returns a product based on the product id.
        /// </summary>
        /// <param name="id">Product id.</param>
        /// <returns>A product or null if the product id didn't exist.</returns>
        public Product GetById(int id)
        {
            var selectedProduct =
                _products.FirstOrDefault(prod => prod.Id.Equals(id));

            return selectedProduct;
        }

        /// <summary>
        /// Adds a product to the product list.
        /// </summary>
        /// <param name="product">The product to be added.</param>
        public void Add(Product product)
        {
            _products.Add(product);

            SaveProducts();
        }

        /// <summary>
        /// Updates a product in the repository.
        /// </summary>
        /// <param name="product">The product to be updated.</param>
        public void Update(Product product)
        {
            if (product == null)
            {
                throw new ApplicationException("Product cannot be null if it should be updated.");
            }

            var productId = product.Id;

            var updateProduct =
                _products.FirstOrDefault(a => a.Id.Equals(productId));

            if (updateProduct == null)
            {
                throw new ApplicationException("Product doesn't exist in ProductRepository.");
            }

            _products.Remove(updateProduct);

            _products.Add(product);

            SaveProducts();
        }

        /// <summary>
        /// Deletes a product from the repository.
        /// </summary>
        /// <param name="product">The product to be deleted.</param>
        public void Delete(Product product)
        {
            var productId = product.Id;

            Delete(productId);
        }

        /// <summary>
        /// Deletes a product from the repository.
        /// </summary>
        /// <param name="productId">Product id of to product be deleted.</param>
        public void Delete(int productId)
        {
            var deleteProduct =
                _products.FirstOrDefault(a => a.Id.Equals(productId));

            if (deleteProduct == null)
            {
                return;
            }

            _products.Remove(deleteProduct);

            SaveProducts();
        }

        /// <summary>
        /// Save all products as JSON data in a text file.
        /// </summary>
        private void SaveProducts()
        {
            var contentRootPath = _environment.ContentRootPath;
            var filePath = Path.Combine(contentRootPath, "Data", "products.json");

            var productData = JsonConvert.SerializeObject(_products);

            File.WriteAllText(filePath, productData);
        }

        /// <summary>
        /// Load all products from text file.
        /// </summary>
        /// <returns>A list of product objects.</returns>
        private List<Product> LoadProducts()
        {
            var contentRootPath = _environment.ContentRootPath;
            var filePath = Path.Combine(contentRootPath, "Data", "products.json");

            var productData = File.ReadAllText(filePath);

            var products = JsonConvert.DeserializeObject<List<Product>>(productData);

            return products;
        }

        /// <summary>
        /// Get all products internally.
        /// </summary>
        //private List<Product> Products
        //{
        //    get
        //    {
        //        return new List<Product> {
        //            new Product {
        //                Id = 123,
        //                Name = "Strumpor",
        //                Description = "Super socks for super men and women. Yay, hooray, fantastic today!",
        //                ProductNumber = "ABC9897"
        //            },
        //            new Product {
        //                Id = 456,
        //                Name = "Skjorta",
        //                Description = "Super shirt for super men and women. Yay, hooray, fantastic today!",
        //                ProductNumber = "CDE7481"
        //            },
        //            new Product {
        //                Id = 458,
        //                Name = "Byxor",
        //                Description = "Super pants for super men and women. Yay, hooray, fantastic today!",
        //                ProductNumber = "CDE9781"
        //            },
        //            new Product {
        //                Id = 897,
        //                Name = "Mössa",
        //                Description = "Super cap for super men and women. Yay, hooray, fantastic today!",
        //                ProductNumber = "QWE6767"
        //            },
        //        };
        //    }
        //    set { }
        //}
    }
}
