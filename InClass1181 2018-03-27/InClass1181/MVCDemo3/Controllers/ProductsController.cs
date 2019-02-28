using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

using DBModel;

using MVCDemo3.Repos;


namespace MVCDemo3.Controllers
{
    public class ProductsController : Controller
    {
        //private InClass1181_EFDemoDBEntities db = new InClass1181_EFDemoDBEntities();

        //ProductEFRepository Repo = new ProductEFRepository();


        private IProductRepository Repo;

        public ProductsController()
        {
            Repo =new ProductEFRepository();
        }

        public ProductsController(IProductRepository r)
        {
            Repo = r;
        }


        // GET: Products
        public ActionResult Index()
        {
            //return View(db.Products.ToList());
            //return View("Index", db.Products.ToList());
            return View("Index", Repo.GetAll());

        }

        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Product product = db.Products.Find(id);
            Product product = Repo.Get (Convert.ToInt32(id) );

            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Brand")] Product product)
        {
            if (ModelState.IsValid)
            {
                //db.Products.Add(product);
                //db.SaveChanges();

                Repo.Add(product);

                return RedirectToAction("Index");
            }

            return View(product);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Product product = db.Products.Find(id);
            Product product = Repo.Get(Convert.ToInt32(id));


            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Brand")] Product product)
        {
            if (ModelState.IsValid)
            {
               // db.Entry(product).State = EntityState.Modified;
               // db.SaveChanges();

                Repo.Update(product);

                return RedirectToAction("Index");
            }
            return View(product);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Product product = db.Products.Find(id);

            Product product = Repo.Get(Convert.ToInt32(id));

            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //Product product = db.Products.Find(id);
            //db.Products.Remove(product);
            //db.SaveChanges();

            Repo.Delete(id);


            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
               //Todo db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
