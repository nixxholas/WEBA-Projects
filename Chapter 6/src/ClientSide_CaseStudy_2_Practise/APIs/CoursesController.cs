using ClientSide_CaseStudy_2_Practise.Models;
using Microsoft.AspNet.Mvc;
using Microsoft.Data.Entity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientSide_CaseStudy_2_Practise.APIs
{
    [Route("api/[controller]")]
    public class CoursesController : Controller
    {

        public ApplicationDbContext Database { get; }


        //Create a Constructor, so that the .NET engine can pass in the 
        //ApplicationDbContext object which represents the database session.
        public CoursesController()
        {
            Database = new ApplicationDbContext();
        }

        //So what are all the codes here? Let me begin explaining them part by part.
        // GET: api/Courses/GetCoursesForControls
        [HttpGet("GetCoursesForControls")] // Basically once a HTTP request equals to 
                                           // http://localhost:63079/API/Courses/GetCoursesForControls
                                           // The CourseController Object that was created will jump
                                           // Straight to this segment of this WHOLE class.
                                           // So now that the object finds what its looking
                                           // for, lets go down.
        public JsonResult GetCoursesForControls()
        {
            //Create a List object, courseList which can store anonymous objects later.
            //Basically, before we convert the object properties/variables into
            //respective "Viewable" content, we need to store them into set 
            //in order to make it easier for us to convert.
            //
            // Let me toss you an example
            //
            // objects --> Apple a1, a2, a3
            // I need to println their brand names
            // 
            // So this is a bad example
            // System.out.println(a1.BrandName);
            // System.out.println(a2.BrandName);
            // System.out.println(a3.BrandName);
            //
            // The easier way is to obviously toss them into a list of apples
            //
            // So,
            // List<Apple> appleList = new ArrayList<Apple>();
            // From here, we'll be able to toss a loop to toss all the apples
            // inside.

            List<object> courseList = new List<object>();
            
            // Simple abbreviation for this? Let's say your database name is appledb
            // I'll write a pseudo code for you. (Pseudo code means a human-readable
            // code format if you have forgotten what pseudo code means...)
            //
            // for each apples in the database appledb ==== IN CODE ITS ===> 
            // var applesQueryResult = Database.Apples
            // 
            // where each apple is not deleted
            //  .Where(eachApple => eachApple.DeletedAt == null);
            var coursesQueryResult = Database.Courses
                 .Where(eachCourse => eachCourse.DeletedAt == null);
            //Loop through each Course entity in  the coursesQueryResult's
            //internal List of Course entities. Create an anoymous object which
            //has 2 properties, CourseId, CourseAbbreviation

            return new JsonResult(coursesQueryResult);
        }//end of GetCoursesForControls()

        // GET: api/Courses/GetCoursesSummary
        [HttpGet("GetCoursesSummary")]
        public JsonResult GetCoursesSummary()
        {
            var coursesQueryResult = Database.Courses
                 .Where(eachCourse => eachCourse.DeletedAt == null)
                                .Include(eachCourse => eachCourse.Students)
                                .Select(eachCourse => new { CourseId = eachCourse.CourseId, CourseAbbreviation = eachCourse.CourseAbbreviation, NumOfStudents = eachCourse.Students.Count });

            return new JsonResult(coursesQueryResult);
        }//end of GetCoursesSummary()



        [HttpGet]
        public JsonResult Get()
        {
            List<object> courseList = new List<object>();
            var courses = Database.Courses
              .Where(eachCourse => eachCourse.DeletedAt == null);
            foreach (var oneCourse in courses)
            {
                courseList.Add(new
                {
                    CourseId = oneCourse.CourseId,
                    CourseName = oneCourse.CourseName,
                    CourseAbbreviation = oneCourse.CourseAbbreviation,
                    CreatedAt = oneCourse.CreatedAt,
                    UpdatedAt = oneCourse.UpdatedAt
                });
            }//end of foreach
            return new JsonResult(courseList);
        }//end of Get()

        // GET api/Courses/5
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            List<object> courseList = new List<object>();
            var foundOneCourse = Database.Courses
                 .Where(eachCourse => eachCourse.CourseId == id).Single();
            //Create an Anonymous object to build a new JsonResult type object
            //to send back information to the client.
            var response = new
            {
                CourseId = foundOneCourse.CourseId,
                CourseName = foundOneCourse.CourseName,
                CourseAbbreviation = foundOneCourse.CourseAbbreviation,
                CreatedAt = foundOneCourse.CreatedAt,
                UpdatedAt = foundOneCourse.UpdatedAt
            };//end of creation of the anonymous response object


            return new JsonResult(response);
        }

        // PUT api/Courses/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]string value)
        {
            string customMessage = "";
            var courseChangeInput = JsonConvert.DeserializeObject<dynamic>(value);
            //After reconstructing the object from the JSON string residing in the input parameter variable,
            //value:
            //To obtain the course Abbreviation information, use courseChangeInput.CourseAbbreviation.Value
            //To obtain the course name information, use courseChangeInput.CourseName.Value
            var oneCourse = Database.Courses
                .Where(courseEntity => courseEntity.CourseId == id).Single();
            oneCourse.CourseAbbreviation = courseChangeInput.CourseAbbreviation.Value;
            oneCourse.CourseName = courseChangeInput.CourseName.Value;
            oneCourse.UpdatedAt = DateTime.Now;
            try
            {
                Database.SaveChanges();
            }
            catch (Exception ex)
            {
                if (ex.InnerException.Message
                                      .Contains("Course_CourseAbbreviation_UniqueConstraint") == true)
                {
                    customMessage = "Unable to save course record due " +
                                      "to another record having the same name as : " +
                    courseChangeInput.CourseAbbreviation.Value;
                    //Create an anonymous object that has one property, Message.
                    //This anonymous object's Message property contains a simple string message
                    object httpFailRequestResultMessage = new { Message = customMessage };
                    //Return a bad http request message to the client
                    return HttpBadRequest(httpFailRequestResultMessage);
                }
            }//End of try .. catch block on saving data
             //Construct a custom message for the client
             //Create a success message anonymous object which has a 
             //Message member variable (property)
            var successRequestResultMessage = new
            {
                Message = "Saved course record"
            };

            //Create a HttpOkObjectResult class instance, httpOkResult.
            //When creating the object, provide the previous message object into it.
            HttpOkObjectResult httpOkResult =
                                                          new HttpOkObjectResult(successRequestResultMessage);
            //Send the HttpOkObjectResult class object back to the client.
            return httpOkResult;
        }//End of Put() Web API method

        // POST api/Courses
        [HttpPost]
        public IActionResult Post([FromBody]string value)
        {
            string customMessage = "";
            //Reconstruct a useful object from the input string value. 
            dynamic courseNewInput = JsonConvert.DeserializeObject<dynamic>(value);
            Course newCourse = new Course();
            try
            {
                //Copy out all the course data into the new Course instance,
                //new.
                newCourse.CourseAbbreviation = courseNewInput.CourseAbbreviation.Value;
                newCourse.CourseName = courseNewInput.CourseName.Value;
                //When I add this Course instance, newCourse into the
                //Courses Entity Set, it will turn into a Course entity waiting to be mapped
                //as a new record inside the actual Course table.
                Database.Courses.Add(newCourse);
                Database.SaveChanges();//Telling the database model to save the changes
            }
            catch (Exception exceptionObject)
            {
                if (exceptionObject.InnerException.Message
                    .Contains("Course_CourseAbbreviation_UniqueConstraint") == true)
                {
                    customMessage = "Unable to save course record due " +
                                  "to another record having the same abbreviation : " +
                                  courseNewInput.CourseAbbreviation.Value;
                    //Create an anonymous object that has one property, Message.
                    //This anonymous object's Message property contains a simple string message
                    object httpFailRequestResultMessage = new { Message = customMessage };
                    //Return a bad http request message to the client
                    return HttpBadRequest(httpFailRequestResultMessage);
                }
            }//End of Try..Catch block

            //If there is no runtime error in the try catch block, the code execution
            //should reach here. Sending success message back to the client.

            //******************************************************
            //Construct a custom message for the client
            //Create a success message anonymous object which has a 
            //Message member variable (property)
            var successRequestResultMessage = new
            {
                Message = "Saved course record"
            };
            //Create a HttpOkObjectResult class instance, httpOkResult.
            //When creating the object, provide the previous message object into it.
            HttpOkObjectResult httpOkResult =
                                        new HttpOkObjectResult(successRequestResultMessage);
            //Send the HttpOkObjectResult class object back to the client.
            return httpOkResult;

        }//End of POST api

        // DELETE api/Courses/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            string customMessage = "";
            try
            {
                var foundOneCourse = Database.Courses
                    .Single(eachCourse => eachCourse.CourseId == id);
                foundOneCourse.DeletedAt = DateTime.Now;
                //Tell the db model to commit/persist the changes to the database, 
                Database.SaveChanges();
            }
            catch (Exception ex)
            {
                customMessage = "Unable to delete course record.";
                object httpFailRequestResultMessage = new { Message = customMessage };
                //Return a bad http request message to the client
                return HttpBadRequest(httpFailRequestResultMessage);
            }//End of try .. catch block on manage data

            //Build a custom message for the client
            //Create a success message anonymous object which has a 
            //Message member variable (property)
            var successRequestResultMessage = new
            {
                Message = "Deleted course record"
            };

            //Create a HttpOkObjectResult class instance, httpOkResult.
            //When creating the object, provide the previous message object into it.
            HttpOkObjectResult httpOkResult =
                                            new HttpOkObjectResult(successRequestResultMessage);
            //Send the HttpOkObjectResult class object back to the client.
            return httpOkResult;
        }//end of Delete() Web API method with /apis/Courses/digit route

    }//End of Courses Web API controller
}//End of namespace
