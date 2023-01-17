using RetailApp.Models;

namespace RetailApp.Services
{
    public interface ICategoryService
    {
        public bool Add(Category model);

        public bool Update(Category model);

        public Category GetById(int id);

        public bool Delete(int id);

        public IQueryable<Category> List();
    }
}
