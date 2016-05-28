using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.Mvc;
using WEBA_EF_CaseStudy1.Models;
using Microsoft.Data.Entity;
using Newtonsoft.Json;
using System;
// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WEBA_EF_CaseStudy1.APIs
{
    [Route("api/[controller]")]
    public class CompanyController : Controller
    {
        //Create a property Database so that the code in the Action Methods
        //can use this property to communicate with the database. Note that, this Database
        //property is required in every controller. The property is initiatialized in the Controller's
        //Constructor. (In this case, the public CompanyController() constructor has been coded
        //so that the Database property is instantiated as an ApplicationDbContext instance.
        public ApplicationDbContext Database { get; }


        //Create a Constructor 
        //When the .NET runtime instantiates this API Controller,
        //CompanyController, it will instantiate a database session by
        //creating a new ApplicationDbContext class object.
        //The property, Database in this CompanyController will eventually
        //reference (represent) the connected database.
        public CompanyController()
        {
            Database = new ApplicationDbContext();
        }



        // GET: api/Company
        [HttpGet]
        public JsonResult Get()
        {
            List<object> companyList = new List<object>();
            var companies = Database.Companies
                 .Where(item => item.DeletedAt == null);
            //After obtaining all the Company type entity rows (records) from the database,
            //the companies variable will become an Array holding these Company type entity rows.
            //I need to loop through each  Company instance inside companies
            //to construct a JSON structured data, to return back to the client web browser.
            foreach (var company in companies)
            {
                companyList.Add(new
                {
                    CompanyId = company.CompanyId,
                    CompanyName = company.CompanyName,
                    Address = company.Address,
                    PostalCode = company.PostalCode,
                    CreatedAt = company.CreatedAt,
                    UpdatedAt = company.UpdatedAt
                });
            }//end of foreach loop which builds the companyList .
            return new JsonResult(companyList);
        }//end of Get()

        // GET api/values/5
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
           
            //The include() feature requires Microsoft Data Entity for now.
            var oneCompany = Database.Companies
                 .Where(item => item.CompanyId == id).Single();

            var response = new
            {
                CompanyId = oneCompany.CompanyId,
                CompanyName = oneCompany.CompanyName,
                CourseAbbreviation = oneCompany.Address,
                CreatedAt = oneCompany.CreatedAt,
                UpdatedAt = oneCompany.UpdatedAt 
            };//end of creation of the response object


            return new JsonResult(response);
        }//End of Get API/values/5
        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]string value)
        {
            var company = JsonConvert.DeserializeObject<dynamic>(value);

            //To obtain the company name information, use company.CompanyName.value
            //To obtain the address information, use company.Address.value
            //Create a new Company type instance, oneCompany
            Company oneCompany = new Company();
            //Use the following 3 lines to supply user provided values
            //into the oneCompany's respective properties 
            oneCompany.CompanyName = company.CompanyName.Value;
            oneCompany.Address = company.Address.Value;
            oneCompany.PostalCode = company.PostalCode.Value;
            //The object Database represents the database. The Database object has a property, Companies
            //which references the Company entity (table) in the database.
            //Calling the Add() method to add the filled Company type instance, oneCompany
            Database.Companies.Add(oneCompany);
            try
            {
                //Tell the Database object which references the database to begin committing the
                //changes. Calling the SaveChanges() method will persist the new company data
                //in the database.
                Database.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                string messageToUser = "";
                //Code to return the message to the user informing him that he is entering a duplicate company name
                if (ex.InnerException.Message.Contains("Company_CompanyName_UniqueConstraint") == true)
                {
                    messageToUser = "Unable to save company record due to another record having the same name as : " +
                            company.CompanyName.Value;
                }
                var errorResponse = new { Status = "fail", Message = messageToUser };
                return new JsonResult(errorResponse);
            }

            var successResponse = new { Status = "success", Message = "Saved company record." };
            return new JsonResult(successResponse);
        }//End of Post API (// POST api/values)

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]string value)
        {
            string message = "";
            var companyChangeInput = JsonConvert.DeserializeObject<dynamic>(value);
            bool status = true; //This variable is used to track the overall success of all the database operations
            object response;
            //Database is our database context set in this controller.
            //To obtain the company name information, use oneCompany.CompanyName.value
            //To obtain the address information, use oneCompany.Address.value
            // var oneCompany = Database.Companies
            //    .Where(item => item.CompanyId == id).FirstOrDefault();
            var oneCompany = Database.Companies
                           .Single(item => item.CompanyId == id);
            oneCompany.CompanyName = companyChangeInput.CompanyName;
            oneCompany.Address = companyChangeInput.Address.Value;
            oneCompany.PostalCode = companyChangeInput.PostalCode.Value;
            oneCompany.UpdatedAt = DateTime.Now;
            try
            {

                //To commit the changes to the database, 
                //I use the following command.
                Database.Update(oneCompany);

                Database.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                if (ex.InnerException.Message.Contains("Company_CompanyName_UniqueConstraint") == true)
                {
                    message = "Unable to save company record due to another record having the same name as : " +
                    companyChangeInput.CompanyName.Value;
                }
                status = false;
            }//End of try .. catch block on saving data
            if (status == true)
            {
                response = new { Status = "success", Message = "Saved company record." };
            }
            else {
                response = new { Status = "fail", Message = message };
            }
            return new JsonResult(response);
        }//End of PUT api      (// PUT api/values/5)

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }


    }
}
