using NgocThuy_Lab4_4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace NgocThuy_Lab4_4.Controllers
{
    public class NhaHangController : Controller
    {

        private IRestaurantRepository restaurantRepository = new RestaurantRepository();

        // GET: NhaHang
        public ActionResult Index(string categoryId)
        {
            var categories = restaurantRepository.GetAllCategories();
            if (!string.IsNullOrEmpty(categoryId))
            {

                var products = restaurantRepository.GetProductsByCategory(categoryId);
                ViewBag.Products = products;
            }

            return View(categories);
        }



        public ActionResult ProductDetails(string productId)
        {
            var product = restaurantRepository.GetProductById(productId);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }


        // GET: NhaHang/CreateProduct
        public ActionResult CreateProduct(string categoryId)
        {

            var categories = restaurantRepository.GetAllCategories();
            ViewBag.Categories = categories;
            ViewBag.CategoryId = categoryId;
            return View();
        }

        // POST: NhaHang/CreateProduct
        [HttpPost]
        public ActionResult CreateProduct(string categoryId, Product product)
        {
            if (ModelState.IsValid)
            {

                restaurantRepository.AddProduct(categoryId, product);
                return RedirectToAction("Index", new { id = categoryId });
            }


            ViewBag.Categories = restaurantRepository.GetAllCategories();
            ViewBag.CategoryId = categoryId;
            return View(product);
        }

        public ActionResult EditProduct(string productId)
        {
            var product = restaurantRepository.GetProductById(productId);

            if (product == null)
            {
                return HttpNotFound($"Product with Id: {productId} not found.");
            }

            var categories = restaurantRepository.GetAllCategories();
            ViewBag.Categories = categories;
            return View(product);
        }

        [HttpPost]
        public ActionResult EditProduct(Product product)
        {
            if (ModelState.IsValid)
            {
                restaurantRepository.UpdateProduct(product);
                return RedirectToAction("Index");
            }

            var categories = restaurantRepository.GetAllCategories();
            ViewBag.Categories = categories;
            return View(product);
        }



        public ActionResult DeleteProduct(string productId, string categoryId)
        {
            var product = restaurantRepository.GetProductById(productId);

            if (product == null)
            {
                return HttpNotFound();
            }

           
            ViewBag.CategoryId = categoryId;

            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteProductConfirmed(string productId, string categoryId)
        {
            System.Diagnostics.Debug.WriteLine("DeleteProductConfirmed POST called with productId: " + productId + " and categoryId: " + categoryId);

            restaurantRepository.DeleteProduct(productId,categoryId);

            // Redirect to Index action, passing the categoryId if needed
            return RedirectToAction("Index", new { categoryId = categoryId });
        }

    }
}
