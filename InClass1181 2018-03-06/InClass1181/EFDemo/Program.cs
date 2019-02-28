using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDemo
{
    class Program
    {
        static void Main(string[] args)
        {


            //Product p = new Product();
            //p.Name = "Monitor";
            //p.Brand = "Samsung";


            //using (DBModelContainer db = new DBModelContainer())
            //{
            //    db.Products.Add(p);
            //    db.SaveChanges();

            //}

            using (DBModelContainer db = new DBModelContainer())
            {
                //List<Product> PList = (from p in db.Products select p).ToList();
                
                //var q = from p in db.Products select p;
                //List<Product> PList = q.ToList();
                
                //foreach (Product p in PList)

                var q = from p in db.Products select p;
                foreach (Product p in q)
                
                {
                    Console.WriteLine  ($"{p.Id} - {p.Name} {p.Brand}");
                }

                Console.ReadKey();

            }







        }
    }
}
