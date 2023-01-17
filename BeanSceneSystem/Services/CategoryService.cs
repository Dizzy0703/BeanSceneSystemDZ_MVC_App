using RetailApp.Data;
using RetailApp.Models;
namespace RetailApp.Services
{
    public class CategoryService : ICategoryService

    {
        RetailAppDbContext Dbx;
        public CategoryService(RetailAppDbContext _Dbx)
        {
            this.Dbx = _Dbx;
        }
        public bool Add(Category model)
        {
            try
            {
                Dbx.Category.Add(model);
                Dbx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        public bool Delete(int id)
        {
            try
            {
                Outer_Category Outer = new Outer_Category();

                
                // Accessing static method1
                // of inner class
               var data= Outer.Inner.GetCategoryById(id);
                // var data = this.GetById(id);


                if (data == null)
                    return false;
                Dbx.Category.Remove(data);
                Dbx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Category GetById(int id)
        {
            
            return Dbx.Category.Find(id);
        }

        public IQueryable<Category> List()
        {
            var data = Dbx.Category.AsQueryable();
            return data;
        }

        public bool Update(Category model)
        {
            try
            {
                Dbx.Category.Update(model);
                Dbx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

       
    }
}

public class Outer_Category
{
    public Inner_Category Inner { get; set; }

    // Constructor to establish link between
    // instance of Outer_class to its
    // instance of the Inner_class
    public Outer_Category()
    {
        this.Inner = new Inner_Category(this);
    }



    public class Inner_Category
    {
        RetailAppDbContext Dbx;
        private Outer_Category obj;
        public Inner_Category(RetailAppDbContext _Dbx)
        {
            this.Dbx = _Dbx;
           
        }
        public Inner_Category(Outer_Category outer)
        {
           
            this.obj = outer;
        }

        public Category GetCategoryById(int id)
        {
            return Dbx.Category.Find(id);
        }

    }
}

