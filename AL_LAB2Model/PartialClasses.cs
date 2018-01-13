using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace AL_LAB2Model
{

    [MetadataType(typeof(MemberMeta))]
    public partial class Course
    {
        public class MemberMeta
        {
            [Display(Name = "Course Code")]
            [Required(ErrorMessage = "{0} required.")]
            public string CourseCode { get; set; }

            [Required(ErrorMessage = "{0} required.")]
            [Display(Name = "Course Name")]
            public string CourseName { get; set; }

            [Required(ErrorMessage = "{0} required.")]
            [Range(1, 10, ErrorMessage = "Can only be between 1 .. 10")]
            [Display(Name = "Number of Credits")]
            public string Number_of_Credits { get; set; }
        }
    }

    [MetadataType(typeof(MemberMeta))]
    public partial class Student
    {
        public class MemberMeta
        {
            [Display(Name = "First Name")]
            [Required(ErrorMessage = "{0} required.")]
            public string FirstName { get; set; }

            [Required(ErrorMessage = "{0} required.")]
            [Display(Name = "Last Name")]
            public string LastName { get; set; }

            [Required(ErrorMessage = "{0} required.")]
            [StringLength(10, MinimumLength = 5, ErrorMessage = "{0} must be minimum {2} and maximum {1} ")]
            [Display(Name = "Student Number")]
            public string Student_Number { get; set; }
        }
    }
}
