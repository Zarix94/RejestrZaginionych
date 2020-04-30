using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RejestrZaginionych.Controllers {
    public class HomeController : Controller {

        public ActionResult Index() {
            ViewBag.Popupmessage = Session["message"];
            return View();
        }

        public ActionResult MissingPersonList() {
            ViewBag.Message = "Missing person list.";

            return RedirectToAction("Index", "MissingPerson");
        }


        public ActionResult Register() {
            ViewBag.Message = "Register page.";

            return View();
        }
    }
}