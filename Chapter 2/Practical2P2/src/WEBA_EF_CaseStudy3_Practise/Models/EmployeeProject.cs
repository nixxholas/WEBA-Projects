using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//Reference:
//http://stackoverflow.com/questions/29442493/how-to-create-a-many-to-many-relationship-with-latest-nightly-builds-of-ef7
namespace WEBA_EF_CaseStudy3_Practise.Models
{   //EmployeeProject class is created, to map an associative table
    //to an entity. Put it in another way, I am creating an 
    //EmployeeProject class to model a associative table (junction table) 
    //for many-to-many relationships.
    public class EmployeeProject
    {
        public int EmployeeProjectId { get; set; }

        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }

        public int ProjectId { get; set; }

        public int RoleId { get; set; }
        public Role Role { get; set; }

    }
}
