using NgocThuy_Lab6.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NgocThuy_Lab6.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
       NgocThuy_Lab06Entities2 db = new NgocThuy_Lab06Entities2 ();
        public ActionResult Index()
        {
            var products = db.Products.ToList(); 
            return View(products); 
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product)
        {
            if (ModelState.IsValid) 
            {
                db.Products.Add(product); 
                db.SaveChanges(); 
                return RedirectToAction("Index"); 
            }
            return View(product); 
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int id)
        {
            var product = db.Products.Find(id); 
            if (product == null)
            {
                return HttpNotFound(); 
            }
            return View(product); 
        }

        // POST: Product/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product product)
        {
            if (ModelState.IsValid) 
            {
                db.Entry(product).State = System.Data.Entity.EntityState.Modified; 
                db.SaveChanges(); 
                return RedirectToAction("Index"); 
            }
            return View(product); 
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
            var product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product); 
        }

        // POST: Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var product = db.Products.Find(id); 
            db.Products.Remove(product); 
            db.SaveChanges(); 
            return RedirectToAction("Index"); 
        }

        // GET: Product/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }

            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }

            return View(product);
        }
    }
}
