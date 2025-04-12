using Accenture.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Accenture.Controllers
{
    public class HomeController : Controller
    {
        Entities db = new Entities();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        #region Student Data
        public ActionResult StudentList()
        {
            var data = db.Students.ToList();
            return View(data);
        }
        [HttpGet]
        public ActionResult Student_Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Student_Create(Student model)
        {
            if (ModelState.IsValid)
            {
                var data = new Student
                {
                    Name = model.Name,
                    Email = model.Email,
                    Age = model.Age
                };
                db.Students.Add(data);
                db.SaveChanges();
                return RedirectToAction("StudentList");

            }
            return View(model);

        }
        public ActionResult Student_Update(int StudentId)
        {
            var edit = db.Students.Find(StudentId);
            if (edit != null)
            {
                return View(edit);
            }
            return View();
        }
        [HttpPost]
        public ActionResult Student_Update(Student model)
        {

            if (ModelState.IsValid)
            {
                var data = db.Students.Find(model.StudentId);
                data.Name = string.IsNullOrWhiteSpace(model.Name) ? data.Name : model.Name;
                data.Email = string.IsNullOrWhiteSpace(model.Email) ? data.Email : model.Email;
                data.Age = (model.Age == 0) ? data.Age : model.Age;
                db.SaveChanges();
                return RedirectToAction("StudentList");
            }
            return View(model);
        }
        public ActionResult Student_Delete(int StudentId)
        {
            var data = db.Students.Find(StudentId);
            if (data != null)
            {
                db.Students.Remove(data);
                db.SaveChanges();

            }
            return RedirectToAction("StudentList");
        }

        #endregion



    }
}