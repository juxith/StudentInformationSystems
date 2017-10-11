using Exercises.Models.Data;
using Exercises.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Exercises.Controllers
{
    public class AdminController : Controller
    {
        [HttpGet]
        public ActionResult StatesPage()
        {
            var model = StateRepository.GetAll();
            return View(model.ToList());
        }

        [HttpGet]
        public ActionResult AddState()
        {
            return View(new State());
        }

        [HttpPost]
        public ActionResult AddState(State state)
        {
            if (string.IsNullOrEmpty(state.StateAbbreviation) || string.IsNullOrEmpty(state.StateName))
            {
                ModelState.AddModelError("StateAbbreviation", "Please enter state abbreviation");
                ModelState.AddModelError("StateName", "Please enter state name");

                return View(new State());
            }
            else
            {
                StateRepository.Add(state);
                return RedirectToAction("StatesPage");
            }
        }

        [HttpGet]
        public ActionResult DeleteState(string id)
        {
            var state = StateRepository.Get(id);
            return View(state);
        }

        [HttpPost]
        public ActionResult DeleteState(State state)
        {
            StateRepository.Delete(state.StateAbbreviation);
            return RedirectToAction("StatesPage");
        }


        [HttpGet]
        public ActionResult Majors()
        {
            var model = MajorRepository.GetAll();
            return View(model.ToList());
        }

        [HttpGet]
        public ActionResult AddMajor()
        {
            return View(new Major());
        }

        [HttpPost]
        public ActionResult AddMajor(Major major)
        {
            if (string.IsNullOrEmpty(major.MajorName))
            {
                return View(new Major());
            }
            else
            {
                MajorRepository.Add(major.MajorName);
                return RedirectToAction("Majors");
            }
        }

        [HttpGet]
        public ActionResult EditMajor(int id)
        {
            var major = MajorRepository.Get(id);
            return View(major);
        }

        [HttpPost]
        public ActionResult EditMajor(Major major)
        {
            if (string.IsNullOrEmpty(major.MajorName))
            {
                return View(major);
            }
            else
            {
                MajorRepository.Edit(major);
                return RedirectToAction("Majors");
            }
        }

        [HttpGet]
        public ActionResult DeleteMajor(int id)
        {
            var major = MajorRepository.Get(id);
            return View(major);
        }

        [HttpPost]
        public ActionResult DeleteMajor(Major major)
        {
            MajorRepository.Delete(major.MajorId);
            return RedirectToAction("Majors");
        }

        [HttpGet]
        public ActionResult CoursesPage()
        {
            var model = CourseRepository.GetAll();
            return View(model.ToList());
        }

        [HttpGet]
        public ActionResult AddCourse()
        {
            return View(new Course());

        }

        [HttpPost]
        public ActionResult AddCourse(Course course)
        {
            if (String.IsNullOrEmpty(course.CourseName))
            {
                return View(new Course());
            }
            else
            {
                CourseRepository.Add(course.CourseName);
                return RedirectToAction("CoursesPage");
            }
        }

        [HttpGet]
        public ActionResult EditCourse(int id)
        {
            var course = CourseRepository.Get(id);
            return View(course);
        }

        [HttpPost]
        public ActionResult EditCourse(Course course)
        {
            if (String.IsNullOrEmpty(course.CourseName))
            {
                return View(course);
            }
            else
            {
                CourseRepository.Edit(course);
                return RedirectToAction("CoursesPage");
            }
        }

        [HttpGet]
        public ActionResult DeleteCourse(int id)
        {
            var state = CourseRepository.Get(id);
            return View(state);
        }

        [HttpPost]
        public ActionResult DeleteCourse(Course course)
        {
            CourseRepository.Delete(course.CourseId);
            return RedirectToAction("CoursesPage");
        }

    }
}