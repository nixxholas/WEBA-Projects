using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using ExperimentOneToManyEntities.Models;
using Microsoft.Data.Entity;
using Newtonsoft.Json;
using System.Globalization;


namespace ExperimentOneToManyEntities.APIs
{
    [Route("api/[controller]")]
    public class StudentsController : Controller
    {
        //Create a property Database so that the code in the API methods
        //can use this property to communicate with the database. Note that, this Database
        //property is required in every controller. The property is initiatialized in the Controller's
        //Constructor. (In this case, the public StudentsController() constructor has been created
        //so that the Database property is instantiated as an ApplicationDbContext type property.
        public ApplicationDbContext Database { get; }

        //Create a Constructor, so that the .NET engine can pass in the dbContext object
        //which represents the database session.
        public StudentsController()
        {
            Database = new ApplicationDbContext();
        }

		      // GET: api/Students
        [HttpGet]
        public JsonResult Get()
        {
			            List<object> studentList = new List<object>();
															//These are just dummy code so that the method
															//can deliver a JSON structure content to the client.
															//-----------------------------------------------------------------------
												   //Replace the following dummy code with proper code to complete
												   //exercise 1.
															//-----------------------------------------------------------------------
				              studentList.Add(new {
						             StudentId = "1000",
						             FullName = "AH TAN",
						             AdmissionId = "888888",
						             CourseAbbreviation = "ILOVECODE",
						             DateOfBirth = "1971-02-19T00:00:00",
						             Email = "ahtan@sleep.com",
						             MobileContact = "88888888"
						            });
            return new JsonResult(studentList);
        }//end of Get()

        // GET api/Students/5
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
															//-----------------------------------------------------------------------
												   //In subsequent practicals, you will work on the code in 
												   //Get(id) method. Or you can do it by referring to the Get(id) method
															//in the Courses Web API controller.
															//-----------------------------------------------------------------------
            var response = new
            {
                   StudentId = 1000,
						             FullName = "AH TAN",
						             AdmissionId = "888888",
						             CourseAbbreviation = "ILOVECODE",
						             DateOfBirth = "1971-02-19T00:00:00",
						             Email = "ahtan@sleep.com",
						             MobileContact = "88888888"
            };//end of creation of the response object
            return new JsonResult(response);
		    }//End of Get(id) method

	      // GET: api/Students/GetStudentsGroupByCourse
       [HttpGet("GetStudentsGroupByCourse")]
        public JsonResult GetStudentsGroupByCourse()
        {
			         List<object> studentList = new List<object>();
												//These are dummy code to produce a dummy result set
												//to the client side JavaScript logic. 
												//-----------------------------------------------------------------------
												//Replace the following dummy code with proper code to complete
												//exercise 2.
												//-----------------------------------------------------------------------
              studentList.Add(new
												          {
												          StudentId = 1000,
												          FullName = "AH TAN",
												          AdmissionId = "888888",
												          CourseAbbreviation = "ILOVECODE"
												          });
			         return new JsonResult(studentList);
     }//End of GetStudentsGroupByCourse()

        // PUT api/Students/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]string value)
        {
            var studentChangeInput = JsonConvert.DeserializeObject<dynamic>(value);
            string fullName = studentChangeInput.FullName.Value;
            string email = studentChangeInput.Email.Value;
            string admissionId = studentChangeInput.AdmissionId.Value;
            string mobileContact = studentChangeInput.MobileContact.Value;
            //DateTime datatype is not that straightforward.
            //Need to make a DateTime datatype conversion first because
            //the DateOfBirth of the foundOneStudent instance is DateTime datatype.
            DateTime dateOfBirth =DateTime.ParseExact(studentChangeInput.DateOfBirth.Value, "d/M/yyyy", CultureInfo.InvariantCulture);
            string courseId = studentChangeInput.CourseId.Value;
            

            var successRequestResultMessage = new
            {
                Message = string.Format("Server side has received the data. For example, full name is {0} email is {1} courseId is {2}. The logic in this Put() method are all dummy code. You will need to do it in the subsequent practical exerices." , fullName, email, courseId )
            };

            //Create a HttpOkObjectResult class instance, httpOkResult.
            //When creating the object, provide the previous message object into it.
            HttpOkObjectResult httpOkResult = 
				                                          new HttpOkObjectResult(successRequestResultMessage);
            //Send the HttpOkObjectResult class object back to the client.
            return httpOkResult;

        }

        // DELETE api/Students/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {

			//Build a custom message for the client
			//Create a success message anonymous object which has a 
			//Message member variable (property)
            var successRequestResultMessage = new
            {
                Message = string.Format("Server side Delete() Web API method of Students Web API controller object has received the id {0} which you want to delete. You need to code the Delete() method in subsequent practical exericises", id.ToString())
            };
            
			         //Create a HttpOkObjectResult class instance, httpOkResult.
            //When creating the object, provide the previous message object into it.
            HttpOkObjectResult httpOkResult = 
				                            new HttpOkObjectResult(successRequestResultMessage);
            //Send the HttpOkObjectResult class object back to the client.
            return httpOkResult;
        }//end of Delete() Web API method with /apis/students/digit route

		// GET: api/Students/GetStudentListByCourse/5
		[HttpGet("GetStudentListByCourse/{inCourseId}")]
		public JsonResult GetStudentListByCourse(int inCourseId)
		{
			List<object> studentList = new List<object>();
			object dataSummary = new object();
			//The following command will create an object, foundOneCourse
			//which represents the Course entity which matches the given course id
			//provided by the input parameter, inCourseId.
			//This foundOneCourse object is needed because the Course Abbreviation name is required
			//in the custom JSON content resultset.
			var foundOneCourse = Database.Courses
						.Where(eachCourse => eachCourse.CourseId == inCourseId).AsNoTracking().Single();

			//The following command will create an object, studentsQueryResult
			//which will only have one internal list of Student entities.
			//These Student entities has CourseId property which meets the search
			//criteria given by the inCourseId input parameter.
			var studentsQueryResult = Database.Students
								.Where(eachStudent => (eachStudent.DeletedAt == null) && (eachStudent.CourseId == inCourseId))
								.Include(eachStudent => eachStudent.Course);
			//The following foreach loop aims to create a
			//into a single List of anonymous objects, studentList.        
			foreach (var eachStudent in studentsQueryResult) {
				//Create new anonymous object and add into the studentList
				//container.
				studentList.Add(new
				{
					StudentId = eachStudent.StudentId,
					FullName = eachStudent.FullName,
					AdmissionId = eachStudent.AdmissionId,
					MobileContact = eachStudent.MobileContact,
					CourseAbbreviation = eachStudent.Course.CourseAbbreviation
				});
			}//end of the foreach block
			if (studentsQueryResult.ToList().Count == 0) {
				dataSummary = new {
					CourseAbbreviation = foundOneCourse.CourseAbbreviation,
					StudentList = studentList,
					Message = "There are no students found for this course."
				};
			} else {
				dataSummary = new {
					CourseAbbreviation = foundOneCourse.CourseAbbreviation,
					StudentList = studentList,
					Message = string.Format("There are {0} students associated to {1} course.",
															studentList.Count.ToString(), foundOneCourse.CourseAbbreviation)
			  };
			}//end if
			return new JsonResult(dataSummary);
			}//End of GetStudentListByCourse()
			
   


    }//End of Students Web API controller class
}//End of namespace
