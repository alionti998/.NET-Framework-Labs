using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AL_LAB2Model;
using AL_LAB2.Models;

namespace AL_LAB2.Controllers
{
    public class StudentsController : Controller
    {
        private Model1 db = new Model1();

        // GET: Students
        public ActionResult Index()
        {
            return View(db.Students.ToList());
        }

        // GET: Students/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }

            StudentEnrollmentVM sevm = new StudentEnrollmentVM();
            sevm.student = student;

            List<Course> courses = db.Courses.ToList();

            foreach (Course c in student.Courses)
            {
                sevm.coursesEnroll.Add(new CoursesEnroll()
                {

                    Id = c.Id,
                    CourseCode = c.CourseCode,
                    CourseName = c.CourseName,
                    Number_of_Credits = c.Number_of_Credits

                });
            }

            return View(sevm);
        }

        // GET: Students/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName,Student_Number")] Student student)
        {
            if (ModelState.IsValid)
            {
                db.Students.Add(student);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(student);
        }

        // GET: Students/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        public ActionResult EditPlus(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }

            StudentEnrollmentVM sevm = new StudentEnrollmentVM();
            sevm.student = student;

            List<Course> courses = db.Courses.ToList();

            foreach (Course c in courses)
            {
                sevm.coursesEnroll.Add(new CoursesEnroll()
                {

                    Id = c.Id,
                    CourseCode = c.CourseCode,
                    CourseName = c.CourseName,
                    Number_of_Credits = c.Number_of_Credits,
                    isEnroll = student.Courses.Contains(c)


                });
            }

            return View(sevm);
        }

        [HttpPost]
        public ActionResult EditPlus(StudentEnrollmentVM sevm)
        {
            if (ModelState.IsValid)
            {
                Student s = db.Students.Find(sevm.student.Id);

                db.Entry(s).State = EntityState.Modified;

                foreach (CoursesEnroll ce in sevm.coursesEnroll)
                {
                    if (ce.isEnroll)
                        s.Courses.Add(db.Courses.Find(ce.Id));
                    else
                        s.Courses.Remove(db.Courses.Find(ce.Id));
                }

                db.SaveChanges();

                return RedirectToAction("Index");
            }
            else
                return View(sevm);

        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,Student_Number")] Student student)
        {
            if (ModelState.IsValid)
            {
                db.Entry(student).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(student);
        }

        // GET: Students/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Student student = db.Students.Find(id);
            db.Students.Remove(student);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
