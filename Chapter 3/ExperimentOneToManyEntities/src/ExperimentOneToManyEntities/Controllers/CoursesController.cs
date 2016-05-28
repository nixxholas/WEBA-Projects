using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
namespace ExperimentOneToManyEntities.Controllers
{
    public class CoursesController : Controller
    {
        // GET: /<Courses>/
        public IActionResult Index()
        {
            return View();
        }
		      public IActionResult ExperimentDataDrivenListBox()
		      {
			          return View();
													//The web application will know it needs to process the
													//ExperimentDataDrivenListBox.cshtml file.
		       }
								public IActionResult ExperimentViewCourseSummary() {
									    return View();
													//The web application will know it needs to process the
													//ExperimentViewCourseSummary.cshtml file.
								}
								public IActionResult ExperimentViewStudentsByCourse() {
								     return View();
								}
        public IActionResult Create()
        {
            return View();
        }
        public IActionResult Update()
        {
            return View();
        }
    }
}
