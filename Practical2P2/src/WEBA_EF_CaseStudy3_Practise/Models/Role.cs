using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WEBA_EF_CaseStudy3_Practise.Models
{
    public class Role
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        //There is missing code here, to define a navigation
        //property EmployeeProjects so that EF knows that one Role entity
        //can be related to more than one EmployeeProject entity.		   
        public EmployeeProject EmployeeProject { get; set; }

    	public DateTime CreatedAt { get; set; }
		public DateTime UpdatedAt { get; set; }
		public DateTime? DeletedAt { get; set; }
	}
}
