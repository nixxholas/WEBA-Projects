using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WEBA_EF_CaseStudy2_Practise.Models
{
    public class Course
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public string CourseAbbreviation { get; set; }

        //Defining a List<Student> type Students navigation property
        //to tell the entity framework that there is a
        //one-to-many relationship with the Student entity.
        public List<Student> Students { get; set; }
        //You don't need to declare a foreign key
        //column property. StudentId to support
        //the navigation property, Students. (Doesn't make sense)

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
