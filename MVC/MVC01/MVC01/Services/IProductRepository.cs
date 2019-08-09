using System.Collections.Generic;
using MVC01.Models;

namespace MVC01.Services
{
    public interface IProductRepository
    {
        void Add(Product product);
        void Delete(int productId);
        void Delete(Product product);
        List<Product> GetAll();
        Product GetById(int id);
        void Update(Product product);
    }
}