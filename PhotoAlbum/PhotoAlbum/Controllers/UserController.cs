namespace PhotoAlbum.Controllers
{
    using DAL;
    using DAL.Models;
    using PhotoAlbum.Models;
    using System.Collections.Generic;
    using System.Web;
    using System.Web.Mvc;

    public class UserController : Controller
    {
        Dal dal = new Dal();

        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public RedirectToRouteResult Index(Authorization auth)
        {
            int? id = dal.Authorization(auth);
            ViewBag.ErrorMessage = string.Empty;
            if (id != 0)
            {
                return RedirectToAction("UserAccount", "User", new { iduser = id });
                //return RedirectToRoute(new
                //{
                //    controller = "User",
                //    action = "UserAccount",
                //    id = id
                //});
            }
            else
            {
                //ViewBag.ErrorMessage = "Неверный логин и/или пароль";
                return RedirectToAction("Index", "User");
            }
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(UserViewModel model)
        {
            //Dal dal = new Dal();
            dal.CreateUser(model);
            return RedirectToAction("GetAllImage","Start");
        }

        //[HttpPost]

        // GET: User
        public ActionResult UserAccount(int? idUser)
        {
            ViewBag.Photos = dal.GetAllPhotos(idUser);
            ViewBag.Tags = dal.GetAllTagsUser(idUser);
            User user = dal.GetUser(idUser);
            return View(user);
        }

        //[HttpPost]
        //public ActionResult AddImage(int IdUser,HttpPostedFileBase image)
        //{
        //    string fileName = image.FileName;
        //    return View("Index");
        //}
    }
}