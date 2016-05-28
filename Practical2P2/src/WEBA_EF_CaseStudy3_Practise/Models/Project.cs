using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace WEBA_EF_CaseStudy3_Practise.Models
{
public class Project
 {
	public int ProjectId { get; set; }
	public string ProjectName { get; set; }
	public DateTime ProjectStartDate { get; set; }
	public DateTime ProjectEndDate { get; set; }
    //There is a missing code here to define a foreign key
    //property, ProjectTypeId so that EF can tell the database
    //to create a ProjectTypeId column in the table.
    public int ProjectTypeId { get; set; }

    //There is a missing code here, to define a navigation property
    //so that EF knows that: This Project entity is linked to "one"
    //ProjectType entity.
    public ProjectType ProjectType { get; set; }

	public DateTime CreatedAt { get; set; }
	public DateTime UpdatedAt { get; set; }
	public DateTime? DeletedAt { get; set; }

    //There are missing code here to define a navigation property,
    //EmployeeProjects to tell EF that, one project can be related
    //to more than one EmployeeProject entity.

	}
}
