using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AL_LAB2Model;

namespace AL_LAB3.Models
{
    public class CourseRepository : IDisposable, ICourseRepository
    {
        private Model1 _db = new Model1();

        public int Add(Course c)
        {
            _db.Courses.Add(c);
            _db.SaveChanges();
            return c.Id;
        }

        public int Edit(Course c)
        {
            _db.Entry(c).State = System.Data.Entity.EntityState.Modified;
            _db.SaveChanges();
            return c.Id;
        }

        public Course Delete(int id)
        {
            Course c = _db.Courses.Find(id);
            _db.Courses.Remove(c);
            _db.SaveChanges();
            return c;
        }

        public Course Detail(int id)
        {
            Course c = _db.Courses.Find(id);
            return c;
        }

        public IEnumerable<Course> All()
        {
            return _db.Courses.ToList();
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}