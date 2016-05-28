using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Builder;
using Microsoft.Data.Entity;
using Microsoft.Extensions.DependencyInjection;
using System.Globalization;

namespace WEBA_EF_CaseStudy2_Practise.Models
{
    public static class DataSeeder
    {
        public static async void SeedData(this IApplicationBuilder app)
        {
            var db = app.ApplicationServices.GetService<ApplicationDbContext>();
            try
            {
                db.Database.Migrate();

                //Add course records into the course table
                Course ditCourse, dbitCourse, dismCourse;

                ditCourse = new Course()
                {
                    CourseAbbreviation = "DIT",
                    CourseName = "DIPLOMA IN INFORMATION TECHNOLOGY"
                    };
                db.Courses.Add(ditCourse);
                dbitCourse = new Course()
                {
                    CourseAbbreviation = "DBIT",
                    CourseName = "DIPLOMA IN BUSINESS INFORMATION TECHNOLOGY"
                };

                dismCourse = new Course()
                {
                    CourseAbbreviation = "DISM",
                    CourseName = "DIPLOMA IN INFOCOMM SECURITY MANAGEMENT"
                };
                db.Courses.Add(dismCourse);
                //Add Student records into the Student table
                //Declaring the Student objects and assign it to null.
                //Need to assign null first so that the annoying using unassigned variable
                //error is not surfaced by Visual Studio.

                Student georgeStudent = null, amyStudent = null,
                    johnStudent = null, rachelStudent = null;

                georgeStudent = new Student()
                {
                    FullName = "GEORGE",
                    AdmissionId = "0208881",
                    MobileContact = "98888881",
                    Email = "GEORGE@EMU.COM",
                    DateOfBirth = DateTime.ParseExact("19/05/1995",
                    "dd/MM/yyyy", CultureInfo.InvariantCulture),
                    CourseId = ditCourse.CourseId
                };
                db.Students.Add(georgeStudent);
                amyStudent = new Student()
                {
                    FullName = "AMY",
                    AdmissionId = "0208882",
                    MobileContact = "98888882",
                    Email = "AMY@EMU.COM",
                    DateOfBirth = DateTime.ParseExact("24/01/1995",
                    "dd/MM/yyyy", CultureInfo.InvariantCulture),
                    CourseId = ditCourse.CourseId
                };
                db.Students.Add(amyStudent);
                johnStudent = new Student()
                    {
                        FullName = "JOHN",
                        AdmissionId = "0208883",
                        MobileContact = "98888883",
                        Email = "JOHN@EMU.COM",
                        DateOfBirth = DateTime.ParseExact("30/03/1995",
                    "dd/MM/yyyy", CultureInfo.InvariantCulture),
                        CourseId = ditCourse.CourseId
                    };
                db.Students.Add(johnStudent);
                rachelStudent = new Student()
                {
                    FullName = "RACHEL",
                    AdmissionId = "0208884",
                    MobileContact = "98888884",
                    Email = "RACHEL@EMU.COM",
                    DateOfBirth = DateTime.ParseExact("15/05/1995",
                    "dd/MM/yyyy", CultureInfo.InvariantCulture),
                    CourseId = dbitCourse.CourseId
                };
                db.Students.Add(rachelStudent);
                db.SaveChanges();

            }
            catch(Exception exception) {

                return;
            }
            return;
        }

    }
}
