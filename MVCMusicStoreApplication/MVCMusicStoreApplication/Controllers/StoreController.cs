using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCMusicStoreApplication.Controllers
{
    public class StoreController : Controller
    {

        Models.MVCMusicStoreApplicationDB db = new Models.MVCMusicStoreApplicationDB();

                [HttpGet]
                public ActionResult Browse()
                {
                    var Genres = from m in db.Genres;
                    return View();
                }

                [HttpGet]
                public ActionResult Index()
                {
                    int Album = from m in db.Albums
                                where Genreid =("");
                    return View();
                }

                [HttpGet]
                public ActionResult Details()
                {
                    int Album = from m in db.Albums
                                where Albumid = ("");
                    return View();
                }
                // dont know
    }
}