using System;
using System.Linq;
using Microsoft.AspNet.Builder;
using Microsoft.Data.Entity;
using Microsoft.Extensions.DependencyInjection;
using System.Globalization;
using WEBA_EF_CaseStudy3_Practise.Models;
namespace WEBA_EF_CaseStudy3_Practise.Models
{
    public static class DataSeeder
    {
        public static async void SeedData(this IApplicationBuilder app)
        {
            var db = app.ApplicationServices.GetService<ApplicationDbContext>();
            try
            {
                //Caution: Clear all the tables in the database first.
                db.Database.Migrate();
                //If there are employee records inside the Employees table, I will avoid the seeding logic
                if (db.Employees.Any() == false)
                {
                    //Employee and Role entities are added using the var "quick technique".
                    //Begin seeding Role table records
                    var businessAnalystRole = new Role { RoleName = "BUSINESS ANALYST" };
                    db.Roles.Add(businessAnalystRole);
                    var systemAnalystRole = new Role { RoleName = "SYSTEM ANALYST" };
                    db.Roles.Add(systemAnalystRole);
                    var leadDeveloperRole = new Role { RoleName = "LEAD DEVELOPER" };
                    db.Roles.Add(leadDeveloperRole);
                    var projectManagerRole = new Role { RoleName = "PROJECT MANAGER" };
                    db.Roles.Add(projectManagerRole);
                    var usabilityAnalystRole = new Role { RoleName = "USABILITY ANALYST" };
                    db.Roles.Add(usabilityAnalystRole);
                    //Begin seeding Employee table records
                    var danielEmployee = new Employee
                    {
                        StaffId = "88881",
                        Email = "DANIEL@EMU.COM",
                        FullName = "DANIEL",
                        MobileContact = "98888801"
                    };
                    db.Employees.Add(danielEmployee);
                    var davidEmployee = new Employee { StaffId = "88882",
                        Email = "DAVID@EMU.COM", FullName = "DAVID", MobileContact = "98888802" };
                    db.Employees.Add(davidEmployee);
                    var cindyEmployee = new Employee
                    {
                        StaffId = "88883",
                        Email = "CINDY@EMU.COM",
                        FullName = "CINDY",
                        MobileContact = "98888803"
                    };
                    db.Employees.Add(cindyEmployee);
                    var candyEmployee = new Employee
                    {
                        StaffId = "88884",
                        Email = "CANDY@EMU.COM",
                        FullName = "CANDY",
                        MobileContact = "98888804"
                    };
                    db.Employees.Add(candyEmployee);
                    var loriEmployee = new Employee
                    {
                        StaffId = "88885",
                        Email = "LORI@EMU.COM",
                        FullName = "LORI",
                        MobileContact = "98888805"
                    };
                    db.Employees.Add(loriEmployee);
                    var thomasEmployee = new Employee
                    {
                        StaffId = "88886",
                        Email = "THOMAS@EMU.COM",
                        FullName = "THOMAS",
                        MobileContact = "98888806"
                    };
                    db.Employees.Add(thomasEmployee);
                    var jasmineEmployee = new Employee { StaffId = "88887", Email = "JASMINE@EMU.COM", FullName = "JASMINE", MobileContact = "98888807" };
                    db.Employees.Add(jasmineEmployee);
                    var ivanEmployee = new Employee
                    {
                        StaffId = "88888",
                        Email = "IVAN@EMU.COM",
                        FullName = "IVAN",
                        MobileContact = "98888808"
                    };
                    db.Employees.Add(ivanEmployee);
                    var timEmployee = new Employee
                    {
                        StaffId = "88889",
                        Email = "TIM@EMU.COM",
                        FullName = "TIM",
                        MobileContact = "98888809"
                    };
                    db.Employees.Add(timEmployee);
                    var tomEmployee = new Employee
                    {
                        StaffId = "88810",
                        Email = "TOM@EMU.COM",
                        FullName = "TOM",
                        MobileContact = "98888810"
                    };
                    db.Employees.Add(tomEmployee);
                    var peterEmployee = new Employee
                    {
                        StaffId = "88811",
                        Email = "PETER@EMU.COM",
                        FullName = "PETER",
                        MobileContact = "98888811"
                    };
                    db.Employees.Add(peterEmployee);
                    var alanEmployee = new Employee
                    {
                        StaffId = "88812",
                        Email = "ALAN@EMU.COM",
                        FullName = "ALAN",
                        MobileContact = "98888812"
                    };
                    db.Employees.Add(alanEmployee);
                    var benEmployee = new Employee
                    {
                        StaffId = "88813",
                        Email = "BEN@EMU.COM",
                        FullName = "BEN",
                        MobileContact = "98888813"
                    };
                    db.Employees.Add(benEmployee);
                    var randyEmployee = new Employee { StaffId = "88814", Email = "RANDY@EMU.COM", FullName = "RANDY", MobileContact = "98888814" };
                    db.Employees.Add(randyEmployee);
                    var susanEmployee = new Employee
                    {
                        StaffId = "88815",
                        Email = "SUSAN@EMU.COM",
                        FullName = "SUSAN",
                        MobileContact = "98888815"
                    };
                    db.Employees.Add(susanEmployee);
                    var rizaEmployee = new Employee
                    {
                        StaffId = "88816",
                        Email = "RIZA@EMU.COM",
                        FullName = "RIZA",
                        MobileContact = "98888816"
                    };
                    db.Employees.Add(rizaEmployee);
                    var nickEmployee = new Employee
                    {
                        StaffId = "88817",
                        Email = "NICK@EMU.COM",
                        FullName = "NICK",
                        MobileContact = "98888817"
                    };
                    db.Employees.Add(nickEmployee);
                    var leslieEmployee = new Employee { StaffId = "88818", Email = "LESLIE@EMU.COM", FullName = "LESLIE", MobileContact = "98888818" };
                    db.Employees.Add(leslieEmployee);
                    var jasonEmployee = new Employee
                    {
                        StaffId = "88819",
                        Email = "JASON@EMU.COM",
                        FullName = "JASON",
                        MobileContact = "98888819"
                    };
                    db.Employees.Add(jasonEmployee);
                    var richardEmployee = new Employee
                    {
                        StaffId = "88820",
                        Email = "RICHARD@EMU.COM",
                        FullName = "RICHARD",
                        MobileContact = "98888820"
                    };
                    db.Employees.Add(richardEmployee);
                    //Begin seeding ProjectType table records
                    ProjectType researchProjectType, softwareDevelopmentProjectType, mobileAppProjectType;
                    researchProjectType = new ProjectType()
                    {
                        ProjectTypeName = "RESEARCH"
                    };
                    db.ProjectTypes.Add(researchProjectType);
                    softwareDevelopmentProjectType = new ProjectType()
                    {
                        ProjectTypeName = "SOFTWARE DEVELOPMENT"
                    }; db.ProjectTypes.Add(softwareDevelopmentProjectType);
                    mobileAppProjectType = new ProjectType()
                    {
                        ProjectTypeName = "MOBILE APP"
                    };
                    db.ProjectTypes.Add(mobileAppProjectType);
                    //Begin seeding Project table records
                    Project projectAProject, projectBProject, projectCProject, projectDProject, projectEProject;
                    projectAProject = new Project()
                    {
                        ProjectName = "PROJECT A",
                        ProjectStartDate = DateTime.ParseExact("20/05/2016", "d/M/yyyy",
                    CultureInfo.InvariantCulture),
                        ProjectEndDate = DateTime.ParseExact("08/11/2016", "d/M/yyyy",
                    CultureInfo.InvariantCulture),
                        ProjectTypeId = mobileAppProjectType.ProjectTypeId
                    };
                    db.Projects.Add(projectAProject);
                    projectBProject = new Project()
{
        ProjectName = "PROJECT B",
                                ProjectStartDate = DateTime.ParseExact("10/03/2016", "d/M/yyyy",
        CultureInfo.InvariantCulture),
                                ProjectEndDate = DateTime.ParseExact("27/05/2016", "d/M/yyyy",
        CultureInfo.InvariantCulture),
                                ProjectTypeId = researchProjectType.ProjectTypeId
                    };
                    db.Projects.Add(projectBProject);
                    projectCProject = new Project()
                    {
                        ProjectName = "PROJECT C",
                        ProjectStartDate = DateTime.ParseExact("20/12/2016", "d/M/yyyy",
                    CultureInfo.InvariantCulture),
                        ProjectEndDate = DateTime.ParseExact("21/08/2017", "d/M/yyyy",
                    CultureInfo.InvariantCulture),
                        ProjectTypeId = mobileAppProjectType.ProjectTypeId
                    };
                    db.Projects.Add(projectCProject);
                    projectDProject = new Project()
                    {
                        ProjectName = "PROJECT D",
                        ProjectStartDate = DateTime.ParseExact("26/04/2017", "d/M/yyyy",
                    CultureInfo.InvariantCulture),
                        ProjectEndDate = DateTime.ParseExact("30/07/2017", "d/M/yyyy",
                    CultureInfo.InvariantCulture),
                        ProjectTypeId = researchProjectType.ProjectTypeId
                    };
                    db.Projects.Add(projectDProject);
                    projectEProject = new Project()
{
ProjectName = "PROJECT E",
                        ProjectStartDate = DateTime.ParseExact("11/12/2016", "d/M/yyyy",
CultureInfo.InvariantCulture),
                        ProjectEndDate = DateTime.ParseExact("30/02/2017", "d/M/yyyy",
CultureInfo.InvariantCulture),
                        ProjectTypeId = softwareDevelopmentProjectType.ProjectTypeId
                    };
                    db.Projects.Add(projectEProject);
                    //Add five entities which describes Project B member combination
                    EmployeeProject employeeProject = new EmployeeProject()
                    {
                        EmployeeId = davidEmployee.EmployeeId,
                        ProjectId = projectBProject.ProjectId,
                        RoleId = businessAnalystRole.RoleId
                    };
                    db.EmployeeProjects.Add(employeeProject);
                    employeeProject = new EmployeeProject()
                    {
                        EmployeeId = loriEmployee.EmployeeId,
                        ProjectId = projectBProject.ProjectId,
                        RoleId = usabilityAnalystRole.RoleId
                    };
                    db.EmployeeProjects.Add(employeeProject);
                    employeeProject = new EmployeeProject()
                    {
                        EmployeeId = peterEmployee.EmployeeId,
                        ProjectId = projectBProject.ProjectId,
                        RoleId = projectManagerRole.RoleId
                    };
                    employeeProject = new EmployeeProject()
                    {
                        EmployeeId = benEmployee.EmployeeId,
                        ProjectId = projectBProject.ProjectId,
                        RoleId = leadDeveloperRole.RoleId
                    };
                    employeeProject = new EmployeeProject()
                    {
                        EmployeeId = leslieEmployee.EmployeeId,
                        ProjectId = projectBProject.ProjectId,
                        RoleId = systemAnalystRole.RoleId
                    };
                    
                    //Add five entities which describes Project A member combination
                    employeeProject = new EmployeeProject()
                    {
                        EmployeeId = susanEmployee.EmployeeId,
                        ProjectId = projectAProject.ProjectId,
                        RoleId = businessAnalystRole.RoleId
                    };
                    db.EmployeeProjects.Add(employeeProject);
                    employeeProject = new EmployeeProject()
                    {
                        EmployeeId = tomEmployee.EmployeeId,
                        ProjectId = projectAProject.ProjectId,
                        RoleId = usabilityAnalystRole.RoleId
                    };
                    db.EmployeeProjects.Add(employeeProject);
                    employeeProject = new EmployeeProject()
                    {
                        EmployeeId = randyEmployee.EmployeeId,
                        ProjectId = projectAProject.ProjectId,
                        RoleId = projectManagerRole.RoleId
                    };
                    employeeProject = new EmployeeProject()
                    {
                        EmployeeId = rizaEmployee.EmployeeId,
                        ProjectId = projectAProject.ProjectId,
                        RoleId = leadDeveloperRole.RoleId
                    }; employeeProject = new EmployeeProject()
                    {
                        EmployeeId = alanEmployee.EmployeeId,
                        ProjectId = projectAProject.ProjectId,
                        RoleId = systemAnalystRole.RoleId
                    };
                    //Add five entities which describes Project C member combination
                    employeeProject = new EmployeeProject()
                    {
                        EmployeeId = jasonEmployee.EmployeeId,
                        ProjectId = projectCProject.ProjectId,
                        RoleId = businessAnalystRole.RoleId
                    };
                    db.EmployeeProjects.Add(employeeProject);

                    employeeProject = new EmployeeProject()
                    {
                        EmployeeId = richardEmployee.EmployeeId,
                        ProjectId = projectCProject.ProjectId,
                        RoleId = projectManagerRole.RoleId
                    };
                    db.EmployeeProjects.Add(employeeProject);
                    db.SaveChanges();
                }//end of checking whether there are employee records in Employee table.
            }
            catch (Exception ex)
            {
                //I did not spend time thinking about the necessary code
                //need here because my intention was just to ensure
                //the tables will not be repopulated with the same data twice.
            }
            return;
        }//End of SeedData() method
    }//End of DataSeeder class
}//End of namespace