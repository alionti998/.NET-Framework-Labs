using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using AL_LAB2Model;

namespace AL_LAB2.Models
{
    public class StudentEnrollmentVM
    {
        public Student student { get; set; }

        public List<CoursesEnroll> coursesEnroll { get; set; }

        public StudentEnrollmentVM()
        {
            coursesEnroll = new List<CoursesEnroll>();
        }
    }

    public class CoursesEnroll
    {
        public int Id { get; set; }
        public string CourseCode { get; set; }
        public string CourseName { get; set; }
        public string Number_of_Credits { get; set; }
        public bool isEnroll { get; set; }

    }
}