using Microsoft.AspNetCore.Mvc;

namespace YummyApp.Controllers
{
    public class ChefController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
