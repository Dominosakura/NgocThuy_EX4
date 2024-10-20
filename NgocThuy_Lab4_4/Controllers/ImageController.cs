using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NgocThuy_Lab4_4.Models;

namespace NgocThuy_Lab4_4.Controllers
{
    public class ImageController : Controller
    {
        // GET: Image
       
        private string imagesPath = Path.Combine(System.Web.Hosting.HostingEnvironment.MapPath("~/Content/Images"));
        public ActionResult Index()
        {
            var images = Directory.GetFiles(imagesPath).Select(f => new Image { ImagePath = Path.GetFileName(f) }).ToList();

            // Kiểm tra số lượng ảnh
            ViewBag.CanUploadMoreImages = images.Count < 15;

            return View(images);
        }

        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase file, string description)
        {
            var images = Directory.GetFiles(imagesPath).ToList();

            if (images.Count >= 15)
            {
                TempData["Message"] = "Bạn chỉ có thể tải lên tối đa 15 ảnh.";
                return RedirectToAction("Index");
            }

            if (file != null && file.ContentLength > 0)
            {
                var fileName = Path.GetFileName(file.FileName);
                var path = Path.Combine(imagesPath, fileName);
                file.SaveAs(path);
            }
            return RedirectToAction("Index");
        }


        public ActionResult Delete(string fileName)
        {
            var path = Path.Combine(imagesPath, fileName);
            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }
            return RedirectToAction("Index");
        }
    }
}