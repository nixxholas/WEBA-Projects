using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace ClientSide_CaseStudy_2_Practise.Controllers
{
    // The moment the browser calls for ANY method within this class,
    // TAKE NOTE
    //  ----------------------------
    // ExperimentJavaScriptController will create an object of itself in
    // order to execute it.
    public class ExperimentJavaScriptController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        //Executes View(), which in turns executes the combination of 
        //the cshtml we created earlier, also called "ExperimentDOMManipulation.cshtml".
        //It will combine ExperimentDOMManipulation and _Layout and eventually
        //Show that page.
        public IActionResult ExperimentDOMManipulation()
        {
            return View();
        }
    }
}
