using RetailApp.Models;
using System.Security.Cryptography;

namespace RetailApp.Services
{
    public interface IProductservices
    {
        public IEnumerable<Product> GetAllProducts();
        public void CreateProduct(Product P);
        
    }
}
