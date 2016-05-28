using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WEBA_EF_CaseStudy3_Practise.Models
{
    public class ProjectType
    {
		public int ProjectTypeId { get; set; }
		public string ProjectTypeName { get; set; }
        //There is missing code here, to define a List navigation
        //property Projects so that EF knows that one ProjectType entity
        //has a relationship with "more than one" Project entity.	
        public List<ProjectType> ProjectTypes { get; set; }

        public DateTime CreatedAt { get; set; }
		public DateTime UpdatedAt { get; set; }
		public DateTime? DeletedAt { get; set; }
	}
}
