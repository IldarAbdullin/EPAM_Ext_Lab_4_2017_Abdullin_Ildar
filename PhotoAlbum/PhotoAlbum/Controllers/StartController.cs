using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PhotoAlbum.Controllers
{
    public class StartController : Controller
    {
        // GET: Start
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetAllImage()
        {
            Dal dal = new Dal();
            List<byte[]> images = Dal.GetAllImage();
            ViewBag.Tags = dal.GetAllTags();
            return View(images);
        }

    }
}