using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Entity.Metadata.Internal;
namespace WEBA_EF_CaseStudy3_Practise.Models
{
    public class Employee
    {
		   //Employee class contains 5 public properties to
		   //store employee id , full name , staff id, mobile contact number
		   public int EmployeeId { get; set; }
		   public string FullName { get; set; }
		   public string StaffId { get; set; }
		   public string Email { get; set; }
		   public string MobileContact { get; set; }

        //There is missing code here, to define a navigation
        //property EmployeeProjects so that EF knows that one Employee entity
        //can be related to more than one EmployeeProject entity.	
        public Project Project { get; set; } 	   
        
           public DateTime CreatedAt { get; set; }
		   public DateTime UpdatedAt { get; set; }
		   public DateTime? DeletedAt { get; set; }
	}//end of Employee class declaration
}
