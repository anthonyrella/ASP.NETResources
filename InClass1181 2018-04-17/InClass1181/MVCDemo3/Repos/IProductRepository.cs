using System.Collections.Generic;
using DBModel;

using System;

namespace MVCDemo3.Repos
{
    public interface IProductRepository:IDisposable
    {
        int Add(Product p);
        Product Delete(int id);
        Product Get(int id);
        IEnumerable<Product> GetAll();
        int Update(Product p);
    }
}