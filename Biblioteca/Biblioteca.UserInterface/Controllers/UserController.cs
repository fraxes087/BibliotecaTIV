using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Biblioteca.UserInterface.Models;
using Biblioteca.UserInterface.Helpers;
using System.Web.Security;

namespace Biblioteca.UserInterface.Controllers
{
    public class UserController : Controller
    {
        #region Field
        private BusinessLogic.UserManager userManager;
        private BusinessLogic.GenderManager genderManager;
        public UserController() {
            this.userManager = new BusinessLogic.UserManager();
            this.genderManager = new BusinessLogic.GenderManager();
        }
        #endregion

        //
        // GET: /User/

        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated) {
                return RedirectToAction("Home", "User");
            }
            return View();
        }

        [HttpPost]
        public ActionResult Index(User ActUser, bool Remember) {
            Helper help = new Helper();
            Entities.User entUser = new Entities.User();
            User user = new User();
            entUser = this.userManager.FindUserByUserName(ActUser.username);
            if (entUser != null)
            {
                user = help.EntitiesToModel(entUser);
                if (user.password == ActUser.password)
                {
                    var UserCookie = new HttpCookie("UserCookie");
                    FormsAuthentication.SetAuthCookie(user.username, Remember);
                    return RedirectToAction("Index", "Book");
                }
            }
            ViewBag.ErrMessage = "User or/and Pass are wrong!";
            return View();
        }
        
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "User");

        }

        public ActionResult register(){
            List<Gender> genderList = new List<Gender>();
            Helper helper = new Helper();
             foreach (var curGender in this.genderManager.getAllGenders()) {
                 genderList.Add(helper.EntitiesToModel(curGender));
             }

             ViewBag.genderList = new SelectList(genderList, "id_gender", "description");
            return View();
        }

        [HttpPost]
        public ActionResult register(User user, int genderId)
        {
            try
            {
                user.gender.id_gender = genderId;
                Helper helper = new Helper();
                if (this.userManager.registerNewUser(helper.ModelToEntities(user)))
                {
                    return RedirectToAction("Index", "Book");
                }
                else
                {
                    ViewBag.Error = "The user already exists";
                    List<Gender> genderList = new List<Gender>();
                    foreach (var curGender in this.genderManager.getAllGenders())
                    {
                        genderList.Add(helper.EntitiesToModel(curGender));
                    }
                    ViewBag.genderList = new SelectList(genderList, "id_gender", "description");
                    return View();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public ActionResult Profile() {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Home", "User");
            }
            Helper helper = new Helper();
            User modUser = helper.EntitiesToModel(userManager.FindUserByUserName(User.Identity.Name));

            return View(modUser);
        }

        

        public ActionResult EditProfile(string userName)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Home", "User");
            }
            Helper helper = new Helper();
            User user = helper.EntitiesToModel(this.userManager.FindUserByUserName(userName));
            user.valPass = user.password;
            List<Gender> genderList = new List<Gender>();
            foreach (var curGender in this.genderManager.getAllGenders())
            {
                genderList.Add(helper.EntitiesToModel(curGender));
            }

            ViewBag.genderList = new SelectList(genderList, "id_gender", "description");
            return View(user);
        }

        [HttpPost]
        public ActionResult EditProfile(User user, int genderId)
        {
            Helper helper = new Helper();
            user.gender.id_gender = genderId;
            if (this.userManager.editUser(helper.ModelToEntities(user)))
            {
                return RedirectToAction("Profile", "User");
            }
            else
            {
                List<Gender> genderList = new List<Gender>();
                foreach (var curGender in this.genderManager.getAllGenders())
                {
                    genderList.Add(helper.EntitiesToModel(curGender));
                }

                ViewBag.genderList = new SelectList(genderList, "id_gender", "description");
                ViewBag.Error = "An unexpected error has occurred";
            }
            return View(user);
        }


        

        public ActionResult UserProfile() {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "User");
            }

            Helper helper = new Helper();
            User user = helper.EntitiesToModel(this.userManager.FindUserByUserName(User.Identity.Name));
            return View(user);
        }

        public ActionResult UserList() {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "User");
            }
            Helper helper = new Helper();
            var userList = this.userManager.getAllUsers();
            List<User> modUserList = new List<User>();
            foreach (var curUser in userList) {
                modUserList.Add(helper.EntitiesToModel(curUser));
            }
            return View(modUserList);

        }


        [HttpPost]
        public JsonResult userNameAlreadyExists(string username)
        {
            try {
                return Json(this.userManager.userNameAlreadyExists(username));
            }
            catch(Exception ex){
                ViewBag.Error = ex.Message;
                return Json(ex.Message);
            }
            
        }

        [HttpPost]
        public JsonResult mailAlreadyExists(string mail)
        {
            try
            {
                return Json(this.userManager.mailAlreadyExists(mail));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return Json(ex.Message);
            }

        }

    }
}
