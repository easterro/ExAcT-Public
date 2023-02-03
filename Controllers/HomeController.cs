using ExtracurricularActivitiyLog.Data;
using Microsoft.Extensions.Logging;
using ExtracurricularActivitiyLog.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using DocumentFormat.OpenXml.Spreadsheet;

namespace ExtracurricularActivitiyLog.Controllers
{

    //Putting the [Authorize(Roles=...)] at the top of the controller will require all users to log in.
    // the three roles listed here: Staff_Users_ESG, Faculty_Users_ESG, Student_Users_ESG will let all Staff, Faculty, and Students log in
    [Authorize(Roles = "Staff_Users_ESG,Faculty_Users_ESG")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly SchoolContext _context;
        public HomeController(ILogger<HomeController> logger, SchoolContext context)
        {
            _logger = logger;
            _context = context;

        }


        
        public IActionResult Index()
        {
            var test = HttpContext.User.Claims;
            var Username = HttpContext.User.Identity.Name;

            //If the username is Mr. Easterday, Nhan Ton, or Mrs. Talbot, return the homepage. Otherwise redirect users to the NotAuthorized page. 
            //You can add this code to any page to enforce this. I'd reccommend moving this logic into it's own function so it's easier to call and maintain.
            //if (Username == "400920@culver.org" || Username == "643526@culver.org" || Username == "590867@culver.org")
            //{
                return View();
            //}
            //else 
            //{
            //    return RedirectToAction("NotAuthorized");
            //}
        }

        public IActionResult NotAuthorized() 
        {

            return View();
        }


        [Authorize]
        public IActionResult Claims()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
