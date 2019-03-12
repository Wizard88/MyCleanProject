using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Student
    {
        public Guid ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public Sex Sex { get; set; }
        public List<Course> ListCources { get; set; }

        public Student()
        {
            ListCources = new List<Course>();
        }

        public void EnrollCourse(Course course)
        {
            if (ListCources.Any(x => x.ID == course.ID)) throw new InvalidOperationException();
            else ListCources.Add(course);
        }
    }
}
