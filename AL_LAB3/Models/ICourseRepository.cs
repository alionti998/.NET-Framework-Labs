using System.Collections.Generic;
using AL_LAB2Model;

namespace AL_LAB3.Models
{
    public interface ICourseRepository
    {
        int Add(Course c);
        IEnumerable<Course> All();
        Course Delete(int id);
        Course Detail(int id);
        int Edit(Course c);
    }
}