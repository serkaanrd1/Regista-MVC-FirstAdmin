using Microsoft.AspNetCore.Mvc;

namespace RegistaMVC.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
