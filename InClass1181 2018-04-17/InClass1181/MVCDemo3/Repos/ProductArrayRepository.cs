using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DBModel;

namespace MVCDemo3.Repos
{
    public class ProductArrayRepository : IProductRepository
    {

        List<Product> products = new List<Product>();
        public ProductArrayRepository()
        {
            products.Add(new Product() { Id=1, Name = "Laptop",Brand = "Lenovo" });
            products.Add(new Product() { Id = 2, Name = "Mouse", Brand = "Logitech" });
            products.Add(new Product() { Id = 3, Name = "Monitor", Brand = "Samsung" });
            products.Add(new Product() { Id = 4, Name = "Laptop", Brand = "HP" });
            products.Add(new Product() { Id = 5, Name = "Keyboard", Brand = "Microsoft" });
        }


        public int Add(Product p)
        {
            throw new NotImplementedException();
        }

        public Product Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Product Get(int id)
        {
            return products.Where(p => p.Id == id).First();
        }

        public IEnumerable<Product> GetAll()
        {
            return products;
        }

        public int Update(Product p)
        {
            throw new NotImplementedException();
        }
    }
}