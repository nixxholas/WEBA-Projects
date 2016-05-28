using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Globalization;
using WEBA_EF_CaseStudy2_Practise.Models;
using Microsoft.Data.Entity;
using Microsoft.AspNet.Mvc;

namespace WEBA_EF_CaseStudy2_Practise.APIs
{
    [Route("api/[controller]")]
    public class StudentsController : Controller
    {
        //Declare a property called Database.
        //This Database property's data type is, ApplicationDbContext
        //Which means, this property is going to represent the database
        //in your SqlServer database engine.
        public ApplicationDbContext Database { get; }

        //Create a Constructor, so that the .NET engine can pass in the
        //ApplicationDbContext object
        //Which represents the database session.
        public StudentsController()
        {
            //When the Web application creates an object from this
            //Web API controller class, the Database property will be activatd
            //so that the code in any of the methods later (e.g. Post, Put) can use it
            //to manage the database records.
            Database = new ApplicationDbContext();
        }


        //This is the initial code Post has.
        //This code does nothing and hence IActionResult is needed.
        //POST api/values
        //[HttpPost]
        //public void Post([FromBody]string value)
        //{
        //}


        //This is an initial test method for POST.
        ////POST api/values
        //[HttpPost]
        //public IActionResult Post([FromBody]string value)
        //{
        //    var successMessageObject = new
        //    {
        //        Message = "EVERYTHING IS OKAY"
        //    };

        //    HttpOkObjectResult httpOkResult =
        //        new HttpOkObjectResult(successMessageObject);

        //    return httpOkResult;
        //}//End of Post() method

        //POST api/values

        //POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]string value)
        {
            string customMessage = "";
            Student newStud = new Student();
            //Convert the string data in JSON format into a usable object.
            //The reconstructed object is assigned to the newStudentInput object
            var newStudentInput = JsonConvert.DeserializeObject<dynamic>(value);

            newStud.FullName = newStudentInput.FullName.Value;
            newStud.Email = newStudentInput.Email.Value;
            newStud.AdmissionId = newStudentInput.AdmissionId.Value;
            newStud.MobileContact = newStudentInput.MobileContact.Value;

            //DateTime datatype is not that straightforward
            //Need to make a DateTime datatype conversion first because
            //the DateOfBirth of the foundOneStudent instance is DateTime datatype.
            newStud.DateOfBirth =
                DateTime.ParseExact(newStudentInput.DateOfBirth.Value,
                "d/M/yyyy", CultureInfo.InvariantCulture);
            newStud.CourseId = Convert.ToInt32(newStudentInput.CourseId.Value);
            try
            {
                Database.Add(newStud);
                Database.SaveChanges();
            }
            catch (Exception ex)
            {
                if (ex.InnerException.Message
                                    .Contains("Student_AdmissionId_UniqueConstraint") == true)
                {
                    customMessage = "Unable to save student record due " +
                        "to another record having the same admin id : " +
                        newStudentInput.AdmissionId.Value;
                    //Create a fail fail message anonymous object that has one property, Message.
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
                Message = "Saved student record"
            };
            //Create a HttpOkObjectResult class instance, httpOkResult.
            //When creating the object, provide the previous message object into it.
            HttpOkObjectResult httpOkResult =
                new HttpOkObjectResult(successRequestResultMessage);
            //Send the HttpOkObjectResult class object back to the client
            return httpOkResult;
        }//End of Post() method

        //GET api/students/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var oneStudent = Database.Students
                .Where(item => item.StudentId == id)
                .Include(p => p.Course).Single();

            var response = new
            {
                StudentId = oneStudent.StudentId,
                FullName = oneStudent.FullName,
                Email = oneStudent.Email,
                AdmissionId = oneStudent.AdmissionId,
                MobileContact = oneStudent.MobileContact,
                DateOfBirth = oneStudent.DateOfBirth,
                CourseId = oneStudent.CourseId,
            };//end of creation of the response object
            return new JsonResult(response);
        }//End of Get(id) method

       //PUT api/students/5
       [HttpPut("{Id}")]
       public IActionResult Put(int id, [FromBody]string value)
        {
            string customMessage = "";
            var studentChangeInput = JsonConvert.DeserializeObject<dynamic>(value);
            //
            var foundOneStudent = Database.Students
                     .Where(item => item.StudentId == id).FirstOrDefault();

            foundOneStudent.FullName = studentChangeInput.FullName.Value;
            foundOneStudent.Email = studentChangeInput.Email.Value;
            foundOneStudent.MobileContact = studentChangeInput.MobileContact.Value;
            foundOneStudent.AdmissionId = studentChangeInput.AdmissionId.Value;
            foundOneStudent.DateOfBirth =
                DateTime.ParseExact(studentChangeInput.DateOfBirth.Value,
                "d/M/yyyy", CultureInfo.InvariantCulture);
            foundOneStudent.CourseId = Convert.ToInt32(studentChangeInput.CourseId.Value);
            foundOneStudent.UpdatedAt = DateTime.Now;

            try
            {
                Database.Update(foundOneStudent);
                Database.SaveChanges();
            }
            catch (Exception ex)
            {
                if (ex.InnerException.Message
                        .Contains("Student_AdmissionId_UniqueConstraint") == true)
                {
                    customMessage = "Unable to save student record due " +
                        "to another record having the same admin id: " +
                   studentChangeInput.AdmissionId.Value;
                    //Create a fail message anonymous object that has one property, Message.
                    //This anonymous object's Message property contains a simple string message
                    object HttpFailRequestResultMessage = new { Message = customMessage };
                    //Return a bad http request message to the client
                    return HttpBadRequest(HttpFailRequestResultMessage);
                }
            }   //End of try .. catch block on saving data
                //Construct a custom message for the client
                //Create a success message anonymous object which has a
                //Message member variable (property)

            var successRequestResultMessage = new
            {
                Message = "Saved student record"
            };
            //Create a HttpOkObjectResult class instance, httpOkResult.
            //When creating the object, provide the previous message object into it
            HttpOkObjectResult httpOkResult = new HttpOkObjectResult(successRequestResultMessage);
            //Send the HttpOkObjectResult class object back to the client
            return httpOkResult;
        }//End of Put() method

        //DELETE api/Students/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            string customMessage = "";
            try
            {
                var foundOneStudent = Database.Students
                    .Single(eachStudent => eachStudent.StudentId == id);
                //Update the DeletedAt property with the current date and time
                foundOneStudent.DeletedAt = DateTime.Now;

                //Update the database model
                Database.Update(foundOneStudent);
                //Tell the db model to commit/persist the changes to the database.
                Database.SaveChanges();
            }
            catch (Exception ex)
            {
                customMessage = "Unable to delete student record.";
                object httpFailRequestResultMessage = new
                {
                    Message = customMessage
                };
                //Return a bad http request message to the client
                return HttpBadRequest(httpFailRequestResultMessage);
            }//End of try..catch block on manage data

            //Build a custom message for the client
            //Create a success message anonymous object which has a 
            //Message member variable (property)
            var successRequestResultMessage = new
            {
                Message = "Deleted student record"
            };

            //Create a HttpOkObjectResult class instance, httpOkResult.
            //When creating the object, provide the prvious message object into it.
            HttpOkObjectResult httpOkResult = new HttpOkObjectResult(successRequestResultMessage);
            //Send the HttpOkObjectResult class object back to the client.
            return httpOkResult;
        }//end of Delete() Web API method with /api/students/digit route

    }
}    
