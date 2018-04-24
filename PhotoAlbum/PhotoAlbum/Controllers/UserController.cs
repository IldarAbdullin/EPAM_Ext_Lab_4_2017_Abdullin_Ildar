namespace PhotoAlbum.Controllers
{
    using DAL;
    using DAL.Models;
    using PhotoAlbum.Models;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.IO;
    using System.Web;
    using System.Web.Mvc;

    public class UserController : Controller
    {
        Dal dal = new Dal();

        // GET: User
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public RedirectToRouteResult Index(Authorization auth)
        {
            if ((auth.Login == null) || (auth.Pass == null))
            {
                ViewBag.ErrorMess = "Неверный логин и/или пароль";
                return RedirectToAction("Index", "User");
            }

            int? id = this.dal.Authorization(auth);
            ViewBag.ErrorMessage = string.Empty;

            if (id != 0)
            {
                return RedirectToAction("UserAccount", "User", new { iduser = id });
            }
            else
            {
                ViewBag.ErrorMessage = "Неверный логин и/или пароль";
                return RedirectToAction("Index", "User");
            }
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(UserViewModel model, HttpPostedFileBase image)
        {
            if ((model.Login == null) || (model.Pass == null) || (model.UserName == null))
            {
                string err = " Введенные некорректные данные";
                ViewBag.Err = err;
                return RedirectToAction("Create", "User");
            }
            else
            {
                if (model.ConfirmPass != model.Pass)
                {
                    string err = "Пароли не совпали";
                    ViewBag.Err = err;
                    return RedirectToAction("Create", "User");
                }
                else
                {
                    byte[] uploadedFile = new byte[image.ContentLength];
                    image.InputStream.Read(uploadedFile, 0, uploadedFile.Length);
                    model.Avatar = uploadedFile;
                    int id = this.dal.CreateUser(model);
                    return RedirectToAction("UserAccount", "User", new { iduser = id });
                }
            }
        }

        // GET: User
        public ActionResult UserAccount(int? idUser, int visitorId = 0)
        {
            ViewBag.Photos = this.dal.GetAllPhotos(idUser);
            ViewBag.Tags = this.dal.GetAllTagsUser(idUser);
            ViewBag.VisitorId = visitorId;
            User user = this.dal.GetUser(idUser);
            return View(user);
        }

        public ActionResult GetAllImage(int? id, int visitorId = 0)
        {
            ViewBag.idUser = id;
            ViewBag.VisitorId = visitorId;
            List<Photo> photos = this.dal.GetAllPhotos();
            ViewBag.Tags = this.dal.GetAllTags();
            return View(photos);
        }

        [HttpPost]
        public ActionResult AddImage(int IdUser, HttpPostedFileBase image, string tags)
        {
            if (image != null)
            {
                byte[] uploadedFile = new byte[image.ContentLength];
                image.InputStream.Read(uploadedFile, 0, uploadedFile.Length);
                string type = (Path.GetExtension(image.FileName)).Replace(".", "").ToLower();
                dal.UploadImg(uploadedFile, IdUser, type);
                String[] tags2 = tags.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                int idPhoto = this.dal.GetMaxPhoto();

                foreach (var tag in tags2)
                {
                    dal.UploadTag(idPhoto, tag);
                }
            }

            User user = this.dal.GetUser(IdUser);

            return RedirectToAction("UserAccount", "User", new { iduser = IdUser });
        }

        [HttpPost]
        public ActionResult Search(int idUser, string searchText, List<DAL.Models.Photo> photo, int visitorId)
        {
            List<DAL.Models.Photo> photos = this.dal.GetAllPhotos();
            List<DAL.Models.Photo> result = this.dal.Search(searchText, photos);
            ViewBag.idUser = idUser;
            ViewBag.VisitorId = visitorId;
            return View(result);
        }

        public ActionResult Delete(int idPhoto, int idUser, string actions, int visitorId)
        {
            dal.Delete(idPhoto);
            if (actions == "UserAccount")
            {
                return RedirectToAction("UserAccount", "User", new { iduser = idUser, visitorId = visitorId });
            }
            else
            {
                return RedirectToAction("GetAllImage", "User", new { id = idUser, visitorId = visitorId });
            }
        }
    }
}