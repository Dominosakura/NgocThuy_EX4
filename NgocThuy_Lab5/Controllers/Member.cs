using System;
using System.Web.Mvc;
using NgocThuy_Lab5.Models;

namespace NgocThuy_Lab5.Controllers
{
    public class MemberController : Controller
    {
        // GET: /Member/CreateOne
        public ActionResult CreateOne()
        {
            return View();
        }

        // POST: /Member/CreateOne
        [HttpPost]
        public ActionResult CreateOne(Member m)
        {
            // Validate the model state
            if (ModelState.IsValid)
            {
                return RedirectToAction("Details", m);
            }

            return View(m);
        }

        // GET: /Member/CreateTwo
        public ActionResult CreateTwo()
        {
            return View();
        }

        // POST: /Member/CreateTwo
        [HttpPost]
        public ActionResult CreateTwo(Member m)
        {
            // Validate the model state
            if (ModelState.IsValid)
            {
                return RedirectToAction("Details", m);
            }

            return View(m);
        }

        // GET: /Member/CreateThree
        public ActionResult CreateThree()
        {
            return View();
        }

        // POST: /Member/CreateThree
        [HttpPost]
        public ActionResult CreateThree(Member m)
        {
            // Validate the model state
            if (ModelState.IsValid)
            {
                return RedirectToAction("Details", m);
            }

            return View(m);
        }

        // GET: /Member/Details
        public ActionResult Details(Member member)
        {
            return View(member);
        }
    }
}
