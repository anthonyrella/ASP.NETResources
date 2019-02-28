using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.Net;
using MVCDemoB.Models;


namespace MVCDemoB.Controllers
{
    public class MembersController : Controller
    {
        private GameClub1181Entities DB = new GameClub1181Entities();
        // GET: Members
        public ActionResult Index()
        {
            return View(DB.Members.ToList());
        }

        public ActionResult Detail(int? Id)
        {
            //if no id, bad request
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            // id submitted, no entry match found ,not found
            Member m = DB.Members.Find(Id);
            if (m == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }

            // display details

            return View(m);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create([Bind(Include = "Id,Name")]Member m)
        {
            if (ModelState.IsValid)
            {
                DB.Members.Add(m);
                DB.SaveChanges();
                return RedirectToAction("Index");

            }
            else
                return View(m);
        }


        public ActionResult Edit(int? Id)
        {
            if (Id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            Member m = DB.Members.Find(Id);

            if (m == null)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            return View(m);
        }

        [HttpPost]
        public ActionResult Edit([Bind(Include = "Id,Name")] Member m)
        {
            if (ModelState.IsValid)
            {
                DB.Entry(m).State = System.Data.Entity.EntityState.Modified;
                DB.SaveChanges();
                return RedirectToAction("Index");
            }
            else
                return View(m);
        }

        public ActionResult Delete(int? Id)
        {
            if (Id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            Member m = DB.Members.Find(Id);

            if (m == null)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            return View(m);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int Id)
        {
            Member m = DB.Members.Find(Id);
            DB.Members.Remove(m);
            DB.SaveChanges();
            return RedirectToAction("Index");

        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                DB.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}