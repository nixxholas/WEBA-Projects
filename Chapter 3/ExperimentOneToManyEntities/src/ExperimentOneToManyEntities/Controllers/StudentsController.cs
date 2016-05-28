using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;


namespace ExperimentOneToManyEntities.Controllers
{
    public class StudentsController : Controller
    {
        // GET: /Students/
        public IActionResult Index()
        {
            return View();
        }
								// GET: /Students/Update
		      public IActionResult Update()
        {
            return View();
        }
				    // GET: /Students/ViewStudentsGroupByCourse
        public IActionResult ViewStudentsGroupByCourse()
        {
            return View();
        }
    }
}
