using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WEBA_EF_CaseStudy2_Practise.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public string FullName { get; set; }
        public string AdmissionId { get; set; }
        public string Email { get; set; }

        public string MobileContact { get; set; }

        public DateTime DateOfBirth { get; set; }

        //Defining a Course type navigation property, Course
        //to indicate tell Entity framework that there is a
        //one to one relationship with the Course entity.
        public Course Course { get; set; }

        //Define a Foreign Key column property, CourseId
        //to support the navigation property, Course.
        public int CourseId { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
