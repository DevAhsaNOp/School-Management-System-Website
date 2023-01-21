using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System;
using System.Net;
using System.Web.Mvc;
using BLL.Repositories;
using BOL.Validation_Classes;

namespace WebApp.Controllers
{
    public class StudentController : Controller
    {
        private StudentRepo RepoObj;

        public StudentController()
        {
            RepoObj = new StudentRepo();
        } 

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else
            {
                var reas = RepoObj.GetStudentByID(id.Value);
                if (reas == null)
                    return HttpNotFound();
                else
                    return View(reas);
            }
        }

        public ActionResult Create()
        {
            ViewBag.Classes = RepoObj.GetAllClasses();
            ViewBag.Genders = RepoObj.GetAllGenders();
            return View();
        }

        [HttpPost]
        public ActionResult Create(ValidateStudent student)
        {
            if (ModelState.IsValid)
            {
                var reas = RepoObj.InsertStudent(student);
                if (reas)
                {
                    TempData["SuccessMsg"] = "New student added Successfully!";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["ErrorMsg"] = "Error on adding new student please try again!";
                    return RedirectToAction("Index");
                }
            }

            ViewBag.Classes = RepoObj.GetAllClasses();
            ViewBag.Genders = RepoObj.GetAllGenders();
            return View(student);
        }

        // GET: Student/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else
            {
                var reas = RepoObj.GetStudentByID(id.Value);
                if (reas == null)
                    return HttpNotFound();
                else
                {
                    ViewBag.Classes = RepoObj.GetAllClasses();
                    ViewBag.Genders = RepoObj.GetAllGenders();
                    return View(reas);
                }
            }
        }

        [HttpPost]
        public ActionResult Edit(ValidateStudent student)
        {
            if (ModelState.IsValid)
            {
                var reas = RepoObj.UpdateStudent(student);
                if (reas)
                {
                    TempData["SuccessMsg"] = "Student record updated Successfully!";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["ErrorMsg"] = "Error on updating student record please try again!";
                    return RedirectToAction("Index");
                }
            }
            ViewBag.Classes = RepoObj.GetAllClasses();
            ViewBag.Genders = RepoObj.GetAllGenders();
            return View(student);
        }

        [AcceptVerbs(HttpVerbs.Post | HttpVerbs.Get)]
        public ActionResult Index(string searchBy, string searchValue)
        {
            IEnumerable<ValidateStudent> reas = RepoObj.GetAllStudents();
            if (string.IsNullOrEmpty(searchValue) && string.IsNullOrEmpty(searchBy))
            {
                TempData["resetF"] = null;
                return View(reas);
            }
            else if (string.IsNullOrEmpty(searchValue))
            {
                TempData["resetF"] = null;
                TempData["InfoMessage"] = "Please provide search value.";
                return View(reas);
            }
            else
            {
                if (searchBy.ToLower() == "std_name")
                {
                    reas = RepoObj.GetAllStudentsFilter(searchValue.ToLower(), null, null);
                    TempData["resetF"] = "data";
                    return View(reas);
                }
                else if (searchBy.ToLower() == "std_phone")
                {
                    reas = RepoObj.GetAllStudentsFilter(null, searchValue.ToLower(), null);
                    TempData["resetF"] = "data";
                    return View(reas);
                }
                else if (searchBy.ToLower() == "classname")
                {
                    reas = RepoObj.GetAllStudentsFilter(null, null, searchValue.ToLower());
                    TempData["resetF"] = "data";
                    return View(reas);
                }
            }
            return View(reas);
        }
    }
}
