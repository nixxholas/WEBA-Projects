﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using ExperimentOneToManyEntities.Models;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace ExperimentOneToManyEntities.APIs
{
    [Route("api/[controller]")]
    public class CompanyTypesController : Controller
    {
        //Create a property Database so that the code in the methods
        //can use this property to communicate with the database.
        //By having the Database property of type ApplicationDbContext
        //you are bringing in a database model which represents the actual database.
        //Of course, you need the property to be "activated".
        //The Database property is initiatialized in the Controller's
        //Constructor. (In this case, the public CompanyTypesController() constructor has been created
        //so that the Database property is instantiated as an ApplicationDbContext instance.
      public ApplicationDbContext Database { get; }

        public CompanyTypesController()
        {
            Database = new ApplicationDbContext();
        }




       [HttpGet]
       [HttpGet]
        public JsonResult Get()
        {
			         List<object> companyTypeList = new List<object>();
            var companyTypes = Database.CompanyTypes
                 .Where(eachCompanyType => eachCompanyType.DeletedAt == null);

																 foreach(var oneCompanyType in companyTypes) {
				            companyTypeList.Add(new
                 {
                    CompanyTypeId = oneCompanyType.CompanyTypeId,
                    TypeName = oneCompanyType.TypeName,
																				CreatedAt = oneCompanyType.CreatedAt,
																				UpdatedAt = oneCompanyType.UpdatedAt
                 });
			             }//end of foreach
            return new JsonResult(companyTypeList);
        }//end of Get()

		      // GET api/CompanyTypes/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try {
                var foundOneCompanyType = Database.CompanyTypes
                     .Where(eachCompanyType => eachCompanyType.CompanyTypeId == id)
																					.Single();
                var response = new
                {
                    CompanyTypeId = foundOneCompanyType.CompanyTypeId,
                    TypeName = foundOneCompanyType.TypeName,
                    CreatedAt = foundOneCompanyType.CreatedAt,
                    UpdatedAt = foundOneCompanyType.UpdatedAt
                };//end of creation of the response object
                return new JsonResult(response);
            } catch (Exception exceptionObject)
            {
				       //Create a fail message anonymous object
			       	//This anonymous object only has one Message property 
				      //which contains a simple string message
                object httpFailRequestResultMessage = 
					                new { Message = "Unable to obtain company type information." };
                //Return a bad http response message to the client
                return HttpBadRequest(httpFailRequestResultMessage);
            }
        }//End of Get(id) Web API method

        // PUT api/Courses/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]string value)
        {
			         string customMessage = "";
            var companyTypeChangeInput = JsonConvert.DeserializeObject<dynamic>(value);
            //After reconstructing the object from the JSON string residing in the input parameter variable,
            //value:
            //To obtain the Type Name information, use companyTypeChangeInput.TypeName.Value
            var foundOneCompanyType = Database.CompanyTypes
                .Where(eachCompanyType => eachCompanyType.CompanyTypeId == id).Single();
            foundOneCompanyType.TypeName = companyTypeChangeInput.TypeName.Value;
            foundOneCompanyType.UpdatedAt = DateTime.Now;
			         try {
            Database.SaveChanges();
			         }catch (Exception ex)
            {
                if (ex.InnerException.Message
					                  .Contains("CompanyType_TypeName_UniqueConstraint") == true)
                {
                    customMessage = "Unable to save company type record due " +
						              "to another record having the same type name as : " +
                    companyTypeChangeInput.TypeName.Value;
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
                Message = "Saved company type record"
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
            dynamic companyTypeNewInput = JsonConvert.DeserializeObject<dynamic>(value);
            CompanyType  newCompanyType = new CompanyType();
            try
            {
				        //Copy out all the course data into the new CompanyType instance,
				        //new.
				        newCompanyType.TypeName = companyTypeNewInput.TypeName.Value;

				        //When I add this CompanyType instance, newCompanyType into the
												//CompanyType Entity Set, it will turn into a CompanyType entity waiting to be mapped
												//as a new record inside the actual CompanyType table.
				        Database.CompanyTypes.Add(newCompanyType);
				        Database.SaveChanges();//Telling the database model to save the changes
			         }
			         catch (Exception exceptionObject)
            {
				          if (exceptionObject.InnerException.Message
																								.Contains("CompanyType_TypeName_UniqueConstraint") == true)
				          {
					           customMessage = "Unable to save company type record due " +
					                         "to another record having the same type name : " +
					                         companyTypeNewInput.TypeName.Value;
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
			   	Message = "Saved company type record"
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
          var foundOneCompanyType = Database.CompanyTypes
                  .Single(eachCompanyType => eachCompanyType.CompanyTypeId == id);
                foundOneCompanyType.DeletedAt = DateTime.Now;
                //Tell the db model to commit/persist the changes to the database, 
                //I use the following command.
                Database.SaveChanges();
            }
            catch (Exception ex)
            {
                customMessage = "Unable to delete company type record.";
                object httpFailRequestResultMessage = new { Message = customMessage };
                //Return a bad http request message to the client
                return HttpBadRequest(httpFailRequestResultMessage);
            }//End of try .. catch block on manage data

			//Build a custom message for the client
			//Create a success message anonymous object which has a 
			//Message member variable (property)
            var successRequestResultMessage = new
            {
                Message = "Deleted company type record"
            };
            
			         //Create a HttpOkObjectResult class instance, httpOkResult.
            //When creating the object, provide the previous message object into it.
            HttpOkObjectResult httpOkResult = 
				                            new HttpOkObjectResult(successRequestResultMessage);
            //Send the HttpOkObjectResult class object back to the client.
            return httpOkResult;
        }//end of Delete() Web API method with /apis/CompanyTypes/digit route
		[HttpGet("GetCompanyTypesForControls")]
        public JsonResult GetCompanyTypesForControls()
        {
            var companyTypeList = Database.CompanyTypes
                 .Where(eachCompanyType => eachCompanyType.DeletedAt == null)
																 .Select(eachCompanyType=>new
                {
                    CompanyTypeId = eachCompanyType.CompanyTypeId,
                    TypeName = eachCompanyType.TypeName
                });
            return new JsonResult(companyTypeList);
        }//end of GetCompanyTypesForControls()
    }//End of CompanyTypes Web API	 controller
}//End of namespace
