using RejestrZaginionych.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RejestrZaginionych.Controllers
{
    public class MissingPersonController : Controller
    {
        // GET: MissingPerson
        public ActionResult Index() {
            ViewBag.MissingPersonList = Models.MissingPerson.getList();

            return View("MissingPersonList");
        }

        public ActionResult AddMissingPerson() {
            return View();
        }

        [HttpPost]
        public ActionResult AddMissingPerson([Bind(Exclude = "ImagePath")]MissingPerson missingPerson) {
            if (ModelState.IsValid == true) { 
                string FileName = Path.GetFileNameWithoutExtension(missingPerson.ImageFile.FileName);
                string FileExtension = Path.GetExtension(missingPerson.ImageFile.FileName);
                FileName = Guid.NewGuid().ToString() + FileExtension;
                string UploadPath = ConfigurationManager.AppSettings["UserImagePath"].ToString();
                missingPerson.ImagePath = UploadPath + FileName;
                missingPerson.ImageFile.SaveAs(Server.MapPath(missingPerson.ImagePath));

                User user = (User) Session["User"];
                missingPerson.AddedByUserId = user.Id;
                missingPerson.addMissingPerson();
                Debug.WriteLine("DZIALA");

                ViewBag.MissingPersonList = Models.MissingPerson.getList();

                return View("MissingPersonList");
            }
            else
                return View();
        }

        [HttpPost]
        public ActionResult GetPopUpData(int personId) {
            MissingPerson person = MissingPerson.getPopUpInfo(personId);
            return Json(person);
        }
    }
}