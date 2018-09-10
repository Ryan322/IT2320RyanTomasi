using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab02.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Browse()
        {
            ViewBag.Message = "Browse displayed.";

            return View();
        }

        public ActionResult Details()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Location()
        {
            ViewBag.Message = "Location displayed for zip=44124.";

            return View();
        }

        //     public string Index()
        //     {
        //        return "Product/Index is displayed.";
        //   }

    }
}