using NgocThuy_Lab4_3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NgocThuy_Lab4_3.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository productRepository = new ProductRepository();



        // GET: Product
        public ActionResult Index()
        {
            var products = productRepository.GetAllProducts();
            return View(products);

        }


        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                productRepository.AddProduct(product);
                return RedirectToAction("Index");
            }
            return View(product);
        }


        public ActionResult Details(string id)
        {
            var product = productRepository.GetProductById(id);
            return View(product);
        }


        public ActionResult Edit(string id)
        {
            var product = productRepository.GetProductById(id);
            return View(product);
        }


        [HttpPost]
        public ActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                productRepository.UpdateProduct(product);
                return RedirectToAction("Index");
            }
            return View(product);
        }


        // GET: Product/Delete/5
        public ActionResult Delete(string id)
        {
            var product = productRepository.GetProductById(id);
            if (product == null)
            {
                return HttpNotFound(); // Trả về 404 nếu không tìm thấy sản phẩm
            }
            return View(product); // Hiển thị view xác nhận xóa
        }

        // POST: Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            productRepository.DeleteProduct(id); // Xóa sản phẩm
            return RedirectToAction("Index"); // Chuyển hướng về danh sách sản phẩm
        }

    }
}


