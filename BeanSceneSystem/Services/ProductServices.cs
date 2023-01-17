using RetailApp.Models;
using RetailApp.Data;
using Microsoft.EntityFrameworkCore;

namespace RetailApp.Services
{
    public class ProductServices : IProductservices
    {

        RetailAppDbContext Db;
        public ProductServices(RetailAppDbContext _Db)
        {
            Db = _Db;
        }
        public IEnumerable<Product> GetAllProducts()
        {
            return Db.Product.Select(u => u).ToList();
        }
        public void CreateProduct(Product P)
        {

            Db.Product.Add(P);

            Db.SaveChanges();
            
            Db.ChangeTracker.Clear();
        }
    }
}
