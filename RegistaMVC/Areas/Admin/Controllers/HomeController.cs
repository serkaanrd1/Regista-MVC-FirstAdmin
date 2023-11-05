using Microsoft.AspNetCore.Mvc;
using RegistaMVC.Areas.Admin.Filters;

namespace RegistaMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [SessionControlAspect]
    public class HomeController : Controller
    {
        [LogAspect]
        public IActionResult Index()
        {
            return View();
        }


    }
}
