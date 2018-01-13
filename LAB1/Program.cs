using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB1
{
    class Program
    {
        static void Main(string[] args)
        {
            Test();
        }

        private static void Test()
        {
            DropAllCourseRegistrations();
            Console.WriteLine();
            AddCourseRegistration("991358460", "PROG1234");
            AddCourseRegistration("123456789", "PROG1234");
            AddCourseRegistration("123456789", "MATH1234");
            AddCourseRegistration("987654321", "MATH1234");
            AddCourseRegistration("963258741", "PROG1234");
            AddCourseRegistration("963258741", "MATH1234");

            Console.WriteLine();

            DisplayCourseRegistrations();
            DisplayCourseRegistrationsCourse("991358460");
            DisplayCourseRegistrationsStudent("PROG1234");
            Console.WriteLine();

            DropRegistration("123456789", "PROG1234");
            Console.WriteLine();

            DisplayCourseRegistrations();
            Console.WriteLine();

            DisplayCourseRegistrationsStudent("PROG1234");


            Console.ReadKey();

        }

        private static void AddCourseRegistration(string studentNum, string courseCode)// a.
        {

            using (SRS1179Entities db = new SRS1179Entities())
            {

                Student s = db.Students.Where(st => st.StudentNum == studentNum).First();
                Course c = db.Courses.Where(cr => cr.CourseCode == courseCode).First();

                s.Courses.Add(c);
                db.SaveChanges();
                Console.WriteLine($"Course registration added: {s.FirstName} -> {c.CourseName}");

            }

        }

        private static void DropRegistration(string studentNum, string courseCode)// b.
        {
            using (SRS1179Entities db = new SRS1179Entities())
            {

                Student s = db.Students.Where(st => st.StudentNum == studentNum).First();
                Course c = db.Courses.Where(cr => cr.CourseCode == courseCode).First();
                s.Courses.Remove(c);

                db.SaveChanges();
                Console.WriteLine($"Registration dropped: {s.FirstName} -> {c.CourseName}");

            }
        }

        private static void DisplayCourseRegistrations()// c.
        {
            using (SRS1179Entities db = new SRS1179Entities())
            {

                List<Course> courses = db.Courses.ToList();
                foreach (Course c in courses)
                {
                    List<Student> StudentEnrollCourses = c.Students.ToList();
                    Console.WriteLine($"{c.CourseName} - {c.CourseCode}:");

                    foreach (Student s in StudentEnrollCourses)
                    {
                        Console.WriteLine($"{s.FirstName} {s.LastName}");
                    }
                    Console.WriteLine();
                }
            }
        }

        private static void DisplayCourseRegistrationsCourse(string sn) //d.
        {

            using (SRS1179Entities db = new SRS1179Entities())
            {

                Student s = db.Students.Where(st => st.StudentNum.Equals(sn)).First();
                Console.WriteLine($"Course registration for {s.FirstName} {s.LastName}:");

                foreach (Course c in s.Courses)
                {
                    Console.WriteLine($"{c.CourseName} - {c.CourseCode}");

                }

            }

        }

        private static void DisplayCourseRegistrationsStudent(string cn)// e.
        {

            using (SRS1179Entities db = new SRS1179Entities())
            {

                Course c = db.Courses.Where(cr => cr.CourseCode.Equals(cn)).First();
                Console.WriteLine($"Student registration for {c.CourseCode} {c.CourseName}:");

                foreach (Student s in c.Students)
                {
                    Console.WriteLine($"{s.FirstName} - {s.LastName}");

                }

            }

        }


        private static void DropAllCourseRegistrations()// f.
        {

            using (SRS1179Entities db = new SRS1179Entities())
            {

                List<Course> courses = db.Courses.ToList();
                foreach (Course c in courses)
                {
                    c.Students.Clear();
                }

                db.SaveChanges();
                Console.WriteLine("All course registrations dropped");

            }

        }

    }
}
