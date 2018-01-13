using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AL_LAB2Model;

namespace AL_LAB3.Models
{
    public class LocalCourseRepository : ICourseRepository
    {
        List<Course> _courses;

        public LocalCourseRepository()
        {
            _courses = new List<Course>();

            _courses.Add(new Course()
            {
                Id = 1,
                CourseCode = "abc123",
                CourseName = "test1",
                Number_of_Credits = "2"
            });

            _courses.Add(new Course()
            {
                Id = 2,
                CourseCode = "def456",
                CourseName = "test2",
                Number_of_Credits = "4"
            });
        }

        public int Add(Course c)
        {
            c.Id = _courses.Max(x => x.Id) + 1;
            _courses.Add(c);

            return c.Id;
        }

        public IEnumerable<Course> All()
        {
            return _courses.ToList();
        }

        public Course Delete(int id)
        {
            Course c = _courses.Find(x => x.Id == id);
            _courses.Remove(c);
            return c;
        }

        public Course Detail(int id)
        {
            return _courses.Find(x => x.Id == id);
        }

        public int Edit(Course c)
        {
            Course cr = _courses.Find(x => x.Id == c.Id); ;
            cr.CourseCode = c.CourseCode;
            cr.CourseName = c.CourseName;
            cr.Number_of_Credits = c.Number_of_Credits;
            return cr.Id;
        }
    }
}