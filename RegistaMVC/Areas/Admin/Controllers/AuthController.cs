using Microsoft.AspNetCore.Mvc;

namespace RegistaMVC.Areas.Admin.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
