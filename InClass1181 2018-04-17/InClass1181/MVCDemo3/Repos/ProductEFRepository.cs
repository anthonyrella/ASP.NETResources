using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using DBModel;


namespace MVCDemo3.Repos
{
    public class ProductEFRepository : IProductRepository
    {

        private InClass1181_EFDemoDBEntities db = new InClass1181_EFDemoDBEntities();

        public int  Add (Product p)
        {
            db.Products.Add(p);
            db.SaveChanges();
            return p.Id;
        }
        public int Update(Product p)
        {
            db.Entry(p).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return p.Id;
        }

        public Product Delete(int id)
        {
            //Product p = db.Products.Find(id);
            Product p = Get(id);
            db.Products.Remove(p);
            db.SaveChanges();
            return p;
        }

        public Product Get(int id)
        {
            Product p = db.Products.Find(id);
            return p;
        }

        public IEnumerable<Product> GetAll()
        {
            IEnumerable<Product> Products = db.Products.ToList();
            return Products;
        }

        public void Dispose()
        {
            db.Dispose();
        }

    }
}