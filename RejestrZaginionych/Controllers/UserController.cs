using System;
using System.Configuration;
using System.Diagnostics;
using System.Web.Mvc;
using RejestrZaginionych.Models;

namespace RejestrZaginionych.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public ActionResult RegisterUser([Bind(Exclude = "Id,EmailVeryfied,VeryfiedCode,Password,Active,UserType")]User User) {
            ViewBag.Message = "Niepoprawna rejestracja, spróbuj ponownie";
            if (ModelState.IsValid) {
                User.registerUser();
                Session["message"] = "Zarejestrowano, proszę czekać na aktywacje konta przez administratora serwisu";
                return RedirectToAction("Index", "Home");
            } else 
            return View();
        }

        public ActionResult LoginView() {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserLogin User) {
            User user = User.authorize();
            if (user != null) {
                Session["user"] = user;

                return RedirectToAction("Index", "Home");
            } else {
                ModelState.AddModelError("Login", new Exception("Nieprawidłowy login lub hasło"));
                ModelState.AddModelError("PasswordString", new Exception("Nieprawidłowy login lub hasło"));

                return View("LoginView", User);
            }
        }

        public ActionResult Logout() {
            Session["user"] = null;

            return RedirectToAction("Index", "Home");
        }

        public ActionResult UserList() {
            
            ViewBag.UserList = Models.User.getUserList();
            return View();
        }

        [HttpGet]
        public ActionResult ChangeActive(int userId) {
            User user = (User) Session["user"];

            if (user != null && user.UserType == Int32.Parse(ConfigurationManager.AppSettings["ADMIN_USER"])) {
                Models.User.changeUserActiveStatus(userId);
                return RedirectToAction("UserList", "User");
            }
            else
                return View("Error");
        }

        public ActionResult ChangeType(int userId) {
            User user = (User)Session["user"];

            if (user != null && user.UserType == Int32.Parse(ConfigurationManager.AppSettings["ADMIN_USER"])) {
                Models.User.changeUserType(userId);
                return RedirectToAction("UserList", "User");
            }
            else
                return View("Error");
        }


    }
}