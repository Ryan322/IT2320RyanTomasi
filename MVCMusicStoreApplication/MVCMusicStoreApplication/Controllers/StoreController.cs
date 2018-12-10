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
        // MVCMusicStoreDB db = new MVCMusicStoreDB();
        
                [HttpGet]
                public ActionResult Browse()
                {
                   var genres = Models.MVCMusicStoreApplicationDB.Genres.ToList();
                   return View(genres);

                }

                [HttpGet]
                public ActionResult Details()
                {
                    int Album = from m in db.Album
                                where Genreid =("");
                    return View();
                }

                [HttpGet]
                public ActionResult Index(int id)
                {
                    var album = MVCMusicStoreApplicationDB.Albums.Find(id);

                    return View(album);
                }
                
    }
}